using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour, IResettable where T : MonoBehaviour
{
    [SerializeField] private T _prefabs;
    [SerializeField] private Transform _container;

    private Queue<T> _pool;

    public IEnumerable<T> PoolObject => _pool;

    private void Awake() => _pool = new Queue<T>();

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            T newObject = Instantiate(_prefabs, _container);

            return newObject;
        }

        return _pool.Dequeue();
    }

    public void ReturnObject(T newObject)
    {
        ResetObject(newObject );
        _pool.Enqueue(newObject);
        newObject.gameObject.SetActive(false);
    }

    public void Reset() => _pool.Clear();

    private void ResetObject(T obj) => (obj as IResettable)?.Reset();
}
