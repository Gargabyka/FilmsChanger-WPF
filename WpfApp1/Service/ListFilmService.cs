using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FilmsChanger.Enums;
using FilmsChanger.Models;

namespace FilmsChanger.Service
{
    /// <summary>
    /// Сервис для работы с вкладкой "Список"
    /// </summary>
    public class ListFilmService
    {
        public List<Films>? FilmsList = new List<Films>();

        /// <summary>
        /// Удалить фильм
        /// </summary>
        public void DeleteFilms(Films films)
        {
            try
            {
                if (FilmsList != null)
                {
                    var filmRemove = FilmsList.SingleOrDefault(x => x.Id == films.Id);
                    if (filmRemove != null)
                    {
                        var filmName = filmRemove.FilmName;
                        var isAnime = filmRemove.TypeEnum;
                        var isAnimeStr = isAnime == TypeEnum.IsAnime ? "Аниме" : "Фильм";

                        FilmsList.Remove(filmRemove);

                        MessageBox.Show($"{isAnimeStr}:{filmName} успешно удален",
                            "Удаление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Не удалось удалить фильмы/аниме{Environment.NewLine}Ошибка:{e.InnerException}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
