using System;

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
        public Predicate<Object> Filter { get; set; }

        /// <summary>
        /// Имя фильтра
        /// </summary>
        public string Name { get; set; }
    }
}
