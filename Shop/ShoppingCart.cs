using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Shop
{
    internal class ShoppingCart<T> : IEnumerable<T>
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
                SetNextFirstOpenSlot();
            }
            else
            {
                Console.WriteLine("Fanns ingen ledig plats");
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
            SetNextFirstOpenSlot();
        }

        public void Remove(int index)
        {
            try
            {
                _internalStorage[index] = default(T);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"The chosen index: {index} was out of bounds");
            }
            SetNextFirstOpenSlot();
        }

        private void SetNextFirstOpenSlot()
        {
            var nextOpenSlot = GetNextEmptySlotIndex();

            if (nextOpenSlot == -1)
            {
                IncreaseInternalStorageByOne();
            }
            else
            {
                _firstOpenSlot = nextOpenSlot;
            }
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
            for (int index = 0; index < _internalStorage.Length; index++)
            {
                yield return _internalStorage[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}