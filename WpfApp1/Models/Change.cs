using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FilmsChanger.Models
{
    /// <summary>
    /// DTO вкладки "Выбор"
    /// </summary>
    [Serializable]
    public class Change : INotifyPropertyChanged
    {
        private int _animeCount;
        private int _filmCount;
        private string? _name;
        private string? _nameDb;


        /// <summary>
        /// Id фильма/аниме
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Кол-во аниме
        /// </summary>
        public int AnimeCount
        {
            get { return _animeCount; }
            set
            {
                _animeCount = value;
                OnPropertyChanged("AnimeCount");
            }
        }

        /// <summary>
        /// Кол-во фильмов
        /// </summary>
        public int FilmCount
        {
            get { return _filmCount; }
            set
            {
                _filmCount = value;
                OnPropertyChanged("FilmCount");
            }
        }

        /// <summary>
        /// Наименование фильма/аниме
        /// </summary>
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Наименование базы
        /// </summary>
        public string? NameDb
        {
            get { return _nameDb; }
            set
            {
                _nameDb = value;
                OnPropertyChanged("NameDb");
            }
        }

        /// <summary>
        /// Признак аниме
        /// </summary>
        public bool IsAnime { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
