using UnityEngine;

namespace PLib.Pool
{
    /// <summary>
    /// Easy object pool pattern realization
    /// </summary>
    public sealed class ObjectPool<T> where T : UnityEngine.Object
    {
        private T[] _pool;
        private int _count;
        private int _currentItemIndex = 0;
        private GameObject _poolContainer;

        public int Count => _count;
        public int CurrentItemIndex => _currentItemIndex;
        public T CurrentItem => _pool[_currentItemIndex];

        /// <summary>
        /// Create pool container as parrent and instantiate items by count
        /// </summary>
        /// <param name="poolName">Default name: ObjectPoolContainer</param>
        public ObjectPool(T objectPrefab, int count, string poolName = "PoolContainer")
        {
            _count = count;
            _pool = new T[count];

            _poolContainer = new GameObject();
            _poolContainer.name = objectPrefab.name + poolName;

            Init(objectPrefab, _poolContainer.transform);

        }

        /// <summary>
        /// Instantiate items by count, use specified Transform as parrent
        /// </summary>
        public ObjectPool(T objectPrefab, int count, Transform parent)
        {
            _count = count;
            _pool = new T[count];
            _poolContainer = parent.gameObject;

            Init(objectPrefab, parent);

        }

        private void Init(T objectPrefab, Transform parent)
        {
            for (int i = 0; i < _count; i++)
            {
                _pool[i] = Object.Instantiate(objectPrefab, parent);
            }
        }

        /// <summary>
        /// Return item by id and set as current item <br/>
        /// id &gt; pool.Count : return last item <br/>
        /// id &lt; 0 : return first (id: 0) item
        /// </summary>
        public T GetByID(int id)
        {
            id = id < 0 ? 0 : id >= _count ? _count - 1 : id;
            _currentItemIndex = id;

            return _pool[_currentItemIndex];
        }

        /// <summary>
        /// Return next item <br/>
        /// Cyclically
        /// </summary>
        public T GetNext()
        {
            _currentItemIndex++;
            if (_currentItemIndex >= _count) _currentItemIndex = 0;
            return _pool[_currentItemIndex];
        }

        /// <summary>
        /// Clear pool, destroy pool container
        /// </summary>
        public void Clear()
        {
            if (_poolContainer)
                Object.Destroy(_poolContainer);
            _pool = null;
            _count = 0;
            _currentItemIndex = 0;
        }
    }
}
