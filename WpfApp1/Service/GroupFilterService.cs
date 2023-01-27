using System;
using System.Collections.Generic;
using System.Linq;
using FilmsChanger.Enums;
using FilmsChanger.Models;

namespace FilmsChanger.Service
{
    /// <summary>
    /// Сервис для работы с фильтром
    /// </summary>
    public class GroupFilterService
    {
        private List<MultiFilter> _filters;

        public Predicate<object> Filter { get; private set; }

        public GroupFilterService()
        {
            _filters = new List<MultiFilter>();
            Filter = InternalFilter;
        }

        private bool InternalFilter(object o)
        {
            foreach (var filter in _filters)
            {
                if (filter.Filter != null && !filter.Filter(o))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Добавить фильтр
        /// </summary>
        public void AddFilter(FilterEnum name,Predicate<object> filter)
        {
            var filt = new MultiFilter()
            {
                Name = name,
                Filter = filter
            };

            _filters.Add(filt);
        }

        /// <summary>
        /// Удалить фильтр
        /// </summary>
        public void RemoveFilter(FilterEnum name)
        {
            var filt = _filters.SingleOrDefault(x => x.Name == name);
            if (filt != null)
            {
                _filters.Remove(filt);
            }
        }
    }

}
