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
        private int animeCount;
        private int filmCount;
        private string name;
        private string nameDb;


        /// <summary>
        /// Id фильма/аниме
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Кол-во аниме
        /// </summary>
        public int AnimeCount
        {
            get { return animeCount; }
            set
            {
                animeCount = value;
                OnPropertyChanged("AnimeCount");
            }
        }

        /// <summary>
        /// Кол-во фильмов
        /// </summary>
        public int FilmCount
        {
            get { return filmCount; }
            set
            {
                filmCount = value;
                OnPropertyChanged("FilmCount");
            }
        }

        /// <summary>
        /// Наименование фильма/аниме
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Наименование базы
        /// </summary>
        public string NameDb
        {
            get { return nameDb; }
            set
            {
                nameDb = value;
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
