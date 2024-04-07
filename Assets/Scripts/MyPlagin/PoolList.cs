using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolList<T> where T : Component
{
    private readonly List<T> pool;

    private Transform _parent;
    private Vector2 _position = Vector2.zero;
    private Quaternion _rotate = Quaternion.identity;
    private T _prefab;
    private Action<T> _reset;

    #region Init

    public PoolList() => pool = new();
    public PoolList(int size) => pool = new(size);
    public PoolList(IReadOnlyList<T> list) => pool = new(list);

    #endregion

    #region RX

    public PoolList<T> SetParent(Transform parent)
    {
        _parent = parent;
        return this;
    }

    public PoolList<T> SetSpawnPosition(Vector2 pos)
    {
        _position = pos;
        return this;
    }

    public PoolList<T> SetRotate(Quaternion rotate)
    {
        _rotate = rotate;
        return this;
    }

    public PoolList<T> SetPrefab(T obj)
    {
        _prefab = obj;
        return this;
    }

    public PoolList<T> SetResetMethod(Action<T> reset)
    {
        _reset = reset;
        return this;
    }

    #endregion

    public T Create()
    {
        T obj;
        if (pool.Count > 0)
        {
            obj = pool.First();
            pool.Remove(obj);

            obj.gameObject.SetActive(true);
            obj.transform.position = _position;
            obj.transform.rotation = _rotate;
            obj.transform.parent = _parent;
            _reset?.Invoke(obj);
            return obj;
        }

        obj = MonoBehaviour.Instantiate(_prefab, _position, _rotate);
        obj.transform.parent = _parent;
        _reset?.Invoke(obj);
        return obj;
    }

    public void Destroy(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Add(obj);
    }
}