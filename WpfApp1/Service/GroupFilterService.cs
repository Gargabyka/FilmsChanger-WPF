using System;
using System.Collections.Generic;
using System.Linq;
using FilmsChanger.Models;

namespace FilmsChanger.Service
{
    /// <summary>
    /// Сервис для работы с фильтром
    /// </summary>
    public class GroupFilterService
    {
        //private List<MultiFilter<object>> _filters;

        private List<MultiFilter> _filters;

        public Predicate<object> Filter { get; private set; }

        public GroupFilterService()
        {
            //_filters = new List<MultiFilter<object>>();
            _filters = new List<MultiFilter>();
            Filter = InternalFilter;

        }

        private bool InternalFilter(object o)
        {
            foreach (var filter in _filters)
            {
                if (!filter.Filter(o))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Добавить фильтр
        /// </summary>
        public void AddFilter(string name,Predicate<object> filter)
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
        public void RemoveFilter(string name)
        {
            var filt = _filters.Where(x => x.Name.Contains(name)).SingleOrDefault();
            if (filt != null)
            {
                _filters.Remove(filt);
            }
        }
    }

}
