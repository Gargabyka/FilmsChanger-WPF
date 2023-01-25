using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FilmsChanger.Models;

namespace FilmsChanger.Service
{
    /// <summary>
    /// Сервис для работы с вкладкой "Список"
    /// </summary>
    public class ListFilmService
    {
        public List<Films> FilmsList = new List<Films>();

        /// <summary>
        /// Удалить фильм
        /// </summary>
        public void DeleteFilms(Films films)
        {
            try
            {
                var filmRemove = FilmsList.Where(x => x.Id == films.Id).SingleOrDefault();
                if (filmRemove != null)
                {
                    var filmName = filmRemove.FilmName;
                    var isAnime = filmRemove.IsAnime;
                    var isAnimeStr = isAnime ? "Аниме" : "Фильм";

                    FilmsList.Remove(filmRemove);

                    MessageBox.Show($"{isAnimeStr}:{filmName} успешно удален",
                        "Удаление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось удалить фильмы/аниме ?",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
