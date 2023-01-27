using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FilmsChanger.Models;

namespace FilmsChanger.Service
{
    /// <summary>
    /// Сервис вкладки "Выбор"
    /// </summary>
    public class ChangeFilmService
    {
        private readonly ListFilmService _listFilmService;
        public Change Change { get; set; }
        public bool IsFilm { get; set; } = true;

        public ChangeFilmService(ListFilmService listFilmService)
        {
            _listFilmService = listFilmService;
            Change = new Change();
        }

        /// <summary>
        /// Выбор фильма/аниме
        /// </summary>
        public Change ChangeFilms()
        {
            var result = new Change();

            if (_listFilmService.FilmsList != null && _listFilmService.FilmsList.Count == 0)
            {
                return new Change();
            }

            if (_listFilmService.FilmsList != null)
            {
                var listFilms = _listFilmService.FilmsList.Where(x => !x.IsAnime && !x.IsView).ToList();
                var listAnime = _listFilmService.FilmsList.Where(x => x.IsAnime && !x.IsView).ToList();

                result = IsFilm
                    ? GetRandom(listFilms, listAnime.Count, listFilms.Count)
                    : GetRandom(listAnime, listAnime.Count, listFilms.Count);


                IsFilm = IsFilmOrAnime(listFilms.Count, listAnime.Count);
            }

            Change = result;

            return result;
        }

        /// <summary>
        /// Получить рандомный фильм/аниме
        /// </summary>
        private Change GetRandom(List<Films> list, int animeCount, int filmCount)
        {
            if (list.Count != 0)
            {
                var random = new Random();
                var isFilmStr = IsFilm ? "Фильм" : "Аниме";

                var film = list.ElementAt(random.Next(list.Count));

                var result = new Change
                {
                    Id = film.Id,
                    AnimeCount = animeCount,
                    FilmCount = filmCount,
                    Name = film.FilmName,
                    NameDb = isFilmStr,
                    IsAnime = IsFilm
                };


                return result;
            }

            return new Change{Name = "Фильм/аниме не найден" };
        }

        /// <summary>
        /// Выбор фильма
        /// </summary>
        public bool SetFilm(Guid id)
        {
            if (_listFilmService.FilmsList != null)
            {
                var film = _listFilmService.FilmsList.SingleOrDefault(x => x.Id == id);
                var isFilmStr = !IsFilm ? "фильм" : "аниме";

                if (film == null)
                {
                    MessageBox.Show("Не удалось найти фильмы/аниме",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return false;
                }

                if (MessageBox.Show($"Выбрать для просмотра {isFilmStr} - {film.FilmName} ?",
                        "Выбор",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return false;
                }

                film.IsView = true;

                MessageBox.Show($"Выбран {isFilmStr} - {film.FilmName}",
                    "Выбор",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            return true;
        }

        /// <summary>
        /// Получить актуальную информацию 
        /// </summary>
        public void GetActualInformation()
        {
            var change = new Change();

            if (_listFilmService.FilmsList != null)
            {
                var film = _listFilmService.FilmsList.SingleOrDefault(x => x.Id == change.Id);

                change.AnimeCount = _listFilmService.FilmsList.Count(x => x.IsAnime && !x.IsView);
                change.FilmCount = _listFilmService.FilmsList.Count(x => !x.IsAnime && !x.IsView);
                change.Name = film?.FilmName ?? "Фильм/аниме не найден";
            }

            Change = change;
        }

        private bool IsFilmOrAnime(int countFilm, int countAnime)
        {
            if (countAnime == 0)
            {
                return true;
            }

            if (countFilm == 0)
            {
                return false;
            }

            return !IsFilm;
        }
    }
}

