using System.Collections.Generic;
using UnityEngine;

namespace Node
{
    [CreateAssetMenu(fileName = "ListCorrect", menuName = "Node/ListCorrect", order = 0)]
    public class ListCorrect : ScriptableObject
    {
        [SerializeField] private List<CorrectSequence> correctList;

        public CorrectSequence GetSequence(string personKey)
        {
            foreach (var item in correctList)
                if (item.Key == personKey)
                    return item;

            return null;
        }
    }
}