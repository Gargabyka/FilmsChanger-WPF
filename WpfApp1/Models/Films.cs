using System;

namespace FilmsChanger.Models
{
    [Serializable]
    public class Films
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название фильма/аниме
        /// </summary>
        public string? FilmName { get; set; }

        /// <summary>
        /// Признак просмотра
        /// </summary>
        public bool IsView { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public string Type => IsAnime ? "Аниме" : "Фильм";

        /// <summary>
        /// Признак аниме
        /// </summary>
        public bool IsAnime { get; set; }
    }
}
