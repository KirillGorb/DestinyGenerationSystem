using System;
using System.Collections.Generic;
using Extension.Attribute;
using UnityEngine;

namespace Node
{
    [Serializable]
    public struct Node
    {
        [SerializeField, DropDownListString] private string key;
        [SerializeField, TextArea] private string description;

        [SerializeField, DropDownListString] private List<string> keys;

        public bool IsEnd => keys.Count <= 0;

        public string Key => key;
        public string Value => description;
        public IReadOnlyList<string> Keys => keys;
    }
}