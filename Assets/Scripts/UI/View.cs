using System;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private ConteinerNodes nodes;

    [SerializeField] private Transform parentGrid;
    [SerializeField] private ButtonCheck prefab;
    [SerializeField, StringList] private string initKey;

    private PoolList<ButtonCheck> _pool;
    private readonly List<ButtonCheck> _activeObjs = new();

    public event Action<ButtonCheck> ResetButton;
    public event Action<ButtonCheck> SpawnButton;

    private void Awake()
    {
        _pool = new PoolList<ButtonCheck>().SetParent(parentGrid).SetPrefab(prefab)
            .SetResetMethod(e =>
            {
                ResetButton?.Invoke(e);
                e.AddClick(Review);
            });

        nodes.Init();
    }

    private void Start()
    {
        Generate(initKey);
    }

    private void Review(string key)
    {
        Clear();
        Generate(nodes.GetNode(key).IsEnd ? initKey : key);
    }

    private void Clear()
    {
        foreach (var item in _activeObjs)
            _pool.Destroy(item);
        _activeObjs.Clear();
    }

    private void Generate(string key)
    {
        foreach (var item in nodes.Value(key))
        {
            var b = _pool.Create().SetKey(nodes.GetNode(item));
            _activeObjs.Add(b);
            SpawnButton?.Invoke(b);
        }
    }
}