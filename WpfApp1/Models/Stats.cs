using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsChanger.Models
{
    /// <summary>
    /// DTO статистики
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Общее кол-во фильмов/аниме
        /// </summary>
        public string TotalCount { get; set; }

        /// <summary>
        /// Всего фильмов
        /// </summary>
        public string FilmCount { get; set; }

        /// <summary>
        /// Всего аниме
        /// </summary>
        public string AnimeCount { get; set; }

        /// <summary>
        /// Кол-во просмотренных фильмов
        /// </summary>
        public string ViewFilmCount { get; set; }

        /// <summary>
        /// Кол-во просмотренных аниме
        /// </summary>
        public string ViewAnimeCount { get; set; }

    }
}
