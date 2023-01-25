using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
            var isFileExists = File.Exists("saved.dat");

            if (isFileExists)
            {
                var serializable = new BinaryFormatter();
                using (var reader = new FileStream("saved.dat", FileMode.Open))
                {
                    var result = (SaveLoad)serializable.Deserialize(reader);
                    if (result != null)
                    {
                        _listFilmService.FilmsList = new List<Films>(result.Films);
                        _changeFilmService.Change = result.Change;

                        return result;
                    }
                }
            }

            return new SaveLoad();
        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        public void Save()
        {
            var films = _listFilmService.FilmsList;

            _saveLoad.Films = films;
            _saveLoad.Change = _changeFilmService.Change;

            if (_saveLoad != null)
            {
                var serializer = new BinaryFormatter();
                using (var writer = new FileStream("saved.dat", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(writer, _saveLoad);
                }
            }
        }
    }
}
