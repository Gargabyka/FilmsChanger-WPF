using System;
using System.Collections.Generic;

namespace FilmsChanger.Models
{
    /// <summary>
    /// DTO загрузки/сохранения
    /// </summary>
    [Serializable]
    public class SaveLoad
    {
        /// <summary>
        /// Фильмы
        /// </summary>
        public List<Films> Films { get; set; }

        /// <summary>
        /// Выбор
        /// </summary>
        public Change Change { get; set; }
    }
}
