using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Shop
{
    internal class ShoppingCart<T> : IEnumerable<T>
        where T : Item
    {
        private int _firstOpenSlot;
        private T[] _internalStorage;

        public ShoppingCart()
        {
            _internalStorage = new T[1];
            _firstOpenSlot = 0;
        }

        public void Add(T t)
        {
            if (_internalStorage.Length - 1 == _firstOpenSlot)
            {
                _internalStorage[_firstOpenSlot] = t;
                _firstOpenSlot = GetNextEmptySlotIndex();
            }
            else
            {
                Debug.WriteLine($"There was no empty spot in: {_firstOpenSlot}");
                IncreaseInternalStorageByOne();
                _internalStorage[_firstOpenSlot] = t;
                _firstOpenSlot = _internalStorage.Length;
            }
        }

        public void Remove(T t)
        {
            for (var i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(t))
                {
                    _internalStorage[i] = default(T);
                    break;
                }
            }
            _firstOpenSlot = GetNextEmptySlotIndex();
        }

        public void Remove(int index)
        {
            try
            {
                _internalStorage[index] = default(T);
            }
            catch (Exception)
            {
                Debug.WriteLine($"The chosen index: {index} was out of bounds");
            }
            _firstOpenSlot = GetNextEmptySlotIndex();
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
            for (var index = 0; index < _internalStorage.Length; index++)
            {
                _internalStorage[index] = default(T);
            }
        }

        public T[] SortPriceAscending()
        {
            return _internalStorage.OrderBy(x => x.Price).ToArray();
        }

        public T[] SortPriceDescending()
        {
            return _internalStorage.OrderByDescending(x => x.Price).ToArray();
        }

        public T[] GetUniqueItems()
        {
            return _internalStorage.Distinct().ToArray();
        }

        private void IncreaseInternalStorageByOne()
        {
            var extendedInternalStorage = new T[_internalStorage.Length + 1];
            _internalStorage.CopyTo(extendedInternalStorage, 0);
            _internalStorage = extendedInternalStorage;
            _firstOpenSlot = _internalStorage.GetUpperBound(0);
        }

        private int GetNextEmptySlotIndex()
        {
            for (var i = 0; i < _internalStorage.Length - 1; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_internalStorage[i], default(T)))
                {
                    return i;
                }
            }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var t in _internalStorage)
            {
                yield return t;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}