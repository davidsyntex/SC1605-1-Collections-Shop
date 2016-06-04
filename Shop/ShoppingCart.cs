using System;

namespace Shop
{
    internal class ShoppingCart<T>
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


            // Testa skiten
            foreach (var stuff in _internalStorage)
            {
                Console.WriteLine(stuff.ToString());
            }
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
                if (_internalStorage[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}