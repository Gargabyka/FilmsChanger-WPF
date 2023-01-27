using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using FilmsChanger.Models;

namespace FilmsChanger.Service
{
    /// <summary>
    /// Сервис для работы с сериализацией/десериализацией данных
    /// </summary>
    public class SaveLoadService
    {
        private readonly ListFilmService _listFilmService;
        private readonly ChangeFilmService _changeFilmService;
        private readonly SaveLoad _saveLoad;

        public SaveLoadService(ListFilmService listFilmService, ChangeFilmService changeFilmService)
        {
            _listFilmService = listFilmService;
            _changeFilmService = changeFilmService;
            _saveLoad = LoadFile();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private SaveLoad LoadFile()
        {
            var result = new SaveLoad();
            try
            {
                var isFileExists = File.Exists("saved.json");

                if (isFileExists)
                {
                    using (FileStream fs = new FileStream("saved.json", FileMode.OpenOrCreate))
                    {
                        result =  JsonSerializer.Deserialize<SaveLoad>(fs);
                        if (result != null)
                        {
                            _listFilmService.FilmsList = new List<Films>(result.Films ?? new List<Films>());
                            _changeFilmService.Change = result.Change ?? new Change();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Не удалось загрузить сохраненные данные!{Environment.NewLine}Ошибка:{e.InnerException}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }

            return new SaveLoad();
        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        public void Save()
        {
            try
            {
                var films = _listFilmService.FilmsList;

                _saveLoad.Films = films;
                _saveLoad.Change = _changeFilmService.Change;

                using (FileStream fs = new FileStream("saved.json", FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, _saveLoad);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Не удалось сохранить данные!{Environment.NewLine}Ошибка:{e.InnerException}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
