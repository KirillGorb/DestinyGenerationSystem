using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Node
{
    [StringList] public string Key;
    [TextArea] public string Valye;

    [StringList] public List<string> Keys;

    public bool IsEnd => Keys.Count <= 0;
}