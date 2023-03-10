using System.Linq;
using FilmsChanger.Enums;
using FilmsChanger.Models;

namespace FilmsChanger.Service
{
    /// <summary>
    /// Сервис вкладки "Статистика"
    /// </summary>
    public class StatsFilmService
    {
        private readonly ListFilmService _listFilmService;
        public StatsFilmService(ListFilmService listFilmService)
        {
            _listFilmService = listFilmService;
        }

        /// <summary>
        /// Получить статистику
        /// </summary>
        public Stats GetStats()
        {
            if (_listFilmService.FilmsList != null && _listFilmService.FilmsList.Count == 0)
            {
                return new Stats();
            }

            var list = _listFilmService.FilmsList;
            if (list != null)
            {
                var stats = new Stats
                {
                    TotalCount = list.Count,
                    FilmCount = list.Count(x => x.TypeEnum == TypeEnum.IsFilm),
                    AnimeCount = list.Count(x => x.TypeEnum == TypeEnum.IsAnime),
                    ViewAnimeCount = list.Count(x => x.TypeEnum == TypeEnum.IsAnime && x.IsView),
                    ViewFilmCount = list.Count(x => x.TypeEnum == TypeEnum.IsFilm && x.IsView),
                };

                return stats;
            }

            return new Stats();
        }
    }
}
