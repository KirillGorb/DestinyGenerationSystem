using System.Collections.Generic;
using UnityEngine;

namespace Node
{
    [CreateAssetMenu(fileName = "ContainerNodes", menuName = "Node/ContainerNodes", order = 0)]
    public class ContainerNodes : ScriptableObject
    {
        [SerializeField] private List<Node> matrixNodes;

        private Dictionary<string, Node> _nodes;

        public void Init()
        {
            _nodes = new();
            foreach (var item in matrixNodes)
                _nodes.Add(item.Key, item);
        }

        public Node GetNode(string key) => _nodes[key];
        public IReadOnlyList<string> Value(string key) => _nodes[key].Keys;
    }
}