using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Shop
{
    internal class ShoppingCartList<T> : IEnumerable<T>
        where T : Item
    {
        private readonly Collection<T> _internalStorage;

        public ShoppingCartList()
        {
            _internalStorage = new Collection<T>();
        }

        public void Add(T t)
        {
            _internalStorage.Add(t);
        }

        public void Remove(T t)
        {
            _internalStorage.Remove(t);
        }

        public void Remove(int index)
        {
            _internalStorage.RemoveAt(index);
        }

        public double CalculatePrice()
        {
            return _internalStorage.Sum(t => t.Price);
        }

        public T GetMostExpensiveItem()
        {
            var mostExpensiveItem = _internalStorage[0];

            foreach (var t in _internalStorage)
            {
                if (t.Price > mostExpensiveItem.Price)
                {
                    mostExpensiveItem = t;
                }
            }

            return mostExpensiveItem;
        }

        public void Clear()
        {
            _internalStorage.Clear();
        }

        public IOrderedEnumerable<T> SortPriceAscending()
        {
            return _internalStorage.OrderBy(x => x.Price);
        }

        public IOrderedEnumerable<T> SortPriceDescending()
        {
            return _internalStorage.OrderByDescending(x => x.Price);
        }

        public IEnumerable<T> GetUniqueItems()
        {
            return _internalStorage.Distinct();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _internalStorage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}