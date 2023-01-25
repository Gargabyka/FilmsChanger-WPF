using System.Linq;
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
            if (_listFilmService.FilmsList.Count == 0)
            {
                return new Stats();
            }

            var list = _listFilmService.FilmsList;
            var stats = new Stats
            {
                TotalCount = $"Всего фильмов/аниме: {list.Count}",
                FilmCount = $"Фильмов: {list.Count(x => !x.IsAnime)}",
                AnimeCount = $"Аниме: {list.Count(x => x.IsAnime)}",
                ViewAnimeCount = $"Просмотрено: {list.Count(x => x.IsAnime && x.IsView)}",
                ViewFilmCount = $"Просмотрено: {list.Count(x => !x.IsAnime && x.IsView)}",
            };

            return stats;
        }
    }
}
