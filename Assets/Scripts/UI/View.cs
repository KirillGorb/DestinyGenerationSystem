using System;
using System.Collections.Generic;
using Node;
using Extension;
using Extension.Attribute;
using TMPro;
using UnityEngine;

namespace UI
{
    public class View : MonoBehaviour
    {
        [SerializeField] private ContainerNodes nodes;

        [SerializeField] private Transform parentGrid;
        [SerializeField] private ButtonCheck prefab;
        [SerializeField] private TMP_Text textDescription;

        [SerializeField, DropDownListString("ListStringSetting")]
        private string initKey;

        private PoolList<ButtonCheck> _pool;
        private readonly List<ButtonCheck> _activeObjs = new();

        public event Action<string> DataValidation;
        public event Action<ButtonCheck> HandlingButtonStateAfterSpawning;

        private void Awake()
        {
            _pool = new PoolList<ButtonCheck>().SetParent(parentGrid).SetPrefab(prefab)
                .SetResetMethod(e => e.ResetState());
            nodes.Init();
        }

        private void Start()
        {
            textDescription.text = initKey;
            Generate(initKey);
        }

        private void Review(string key)
        {
            DataValidation?.Invoke(key);
            Clear();
            LogicGenerate(key);
        }

        private void LogicGenerate(string key)
        {
            if (nodes.GetNode(key).IsEnd)
            {
                Generate(initKey);
                textDescription.text = initKey;
            }
            else
            {
                Generate(key);
                textDescription.text = key;
            }
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
                b.AddClick(Review);
                _activeObjs.Add(b);
                HandlingButtonStateAfterSpawning?.Invoke(b);
            }
        }
    }
}