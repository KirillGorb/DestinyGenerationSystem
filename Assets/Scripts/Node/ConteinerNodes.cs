using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConteinerNodes", menuName = "Node/ConteinerNodes", order = 0)]
public class ConteinerNodes : ScriptableObject
{
    [SerializeField] private List<Node> matrexNodes;

    private Dictionary<string, Node> _nodes;

    public void Init()
    {
        _nodes = new();
        foreach (var item in matrexNodes)
            _nodes.Add(item.Key, item);
    }

    public Node GetNode(string key) => _nodes[key];
    public IReadOnlyList<string> Value(string key) => _nodes[key].Keys;
}