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
        public int TotalCount { get; set; }

        public string TotalCountStr
        {
            get { return $"Всего фильмов/аниме: {TotalCount}"; }
        }

        /// <summary>
        /// Всего фильмов
        /// </summary>
        public int FilmCount { get; set; }
        public string FilmCountStr
        {
            get { return $"Фильмов: {FilmCount}"; }
        }

        /// <summary>
        /// Всего аниме
        /// </summary>
        public int AnimeCount { get; set; }
        public string AnimeCountStr
        {
            get { return $"Аниме: {AnimeCount}"; }
        }

        /// <summary>
        /// Кол-во просмотренных фильмов
        /// </summary>
        public int ViewFilmCount { get; set; }
        public string ViewFilmCountStr
        {
            get { return $"Просмотрено: {ViewFilmCount}"; }
        }

        /// <summary>
        /// Кол-во просмотренных аниме
        /// </summary>
        public int ViewAnimeCount { get; set; }
        public string ViewAnimeCountStr
        {
            get { return $"Просмотрено: {ViewAnimeCount}"; }
        }

    }
}
