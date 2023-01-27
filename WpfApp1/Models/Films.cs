using System;
using FilmsChanger.Enums;

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
        public string Type => TypeEnum == TypeEnum.IsAnime ? "Аниме" : "Фильм";

        /// <summary>
        /// Тип аниме/фильм
        /// </summary>
        public TypeEnum TypeEnum { get; set; }
    }
}
