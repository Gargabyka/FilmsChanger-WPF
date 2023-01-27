using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FilmsChanger.Enums;
using FilmsChanger.Models;

namespace FilmsChanger.Service
{
    /// <summary>
    /// Сервис для работы с вкладкой "Добавить"
    /// </summary>
    public class AddFilmService
    {
        private readonly ListFilmService _listFilmService;
        public AddFilmService(ListFilmService listFilmService)
        {
            _listFilmService = listFilmService;
        }
        /// <summary>
        /// Добавить фильм
        /// </summary>
        public bool AddFilms(string films, bool isFilm)
        {
            var filmList = films.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var newFilmsList = new List<Films>();
            var isFilmStr = isFilm ? "фильмов" : "аниме";
            if (_listFilmService.FilmsList != null)
            {
                var filmName = _listFilmService.FilmsList
                    .Where(x=>x.TypeEnum == TypeEnum.IsFilm)
                    .Select(x => x.FilmName?.ToLower())
                    .ToList();

                var dublicateCount = 0;
                string dublicateStr;

                if (string.IsNullOrEmpty(films))
                {
                    MessageBox.Show("Не добавлены фильмы/аниме",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return false;
                }

                try
                {
                    foreach (var film in filmList)
                    {
                        if (filmName.Contains(film.ToLower()))
                        {
                            dublicateCount++;
                            continue;
                        }

                        var newFilm = new Films
                        {
                            Id = Guid.NewGuid(),
                            FilmName = film,
                            TypeEnum = !isFilm ? TypeEnum.IsAnime : TypeEnum.IsFilm
                        };
                        newFilmsList.Add(newFilm);
                    }

                    _listFilmService.FilmsList.AddRange(newFilmsList);

                    dublicateStr = dublicateCount == 0 ? string.Empty : $"Найдено дубликатов: {dublicateCount}";

                    MessageBox.Show($"Добавлено {newFilmsList.Count} новых {isFilmStr}. {Environment.NewLine}{dublicateStr}",
                        "Добавлено",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Не удалось добавить фильмы/аниме{Environment.NewLine}Ошибка:{e.InnerException}",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return false;
                }
            }

            return false;
        }
    }
}
