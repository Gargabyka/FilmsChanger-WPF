using System;
using FilmsChanger.Enums;

namespace FilmsChanger.Models
{
    /// <summary>
    /// Класс для фильтрации данных
    /// </summary>
    public class MultiFilter
    {
        /// <summary>
        /// Фильтр
        /// </summary>
        public Predicate<object>? Filter { get; set; }

        /// <summary>
        /// Имя фильтра
        /// </summary>
        public FilterEnum Name { get; set; }
    }
}
