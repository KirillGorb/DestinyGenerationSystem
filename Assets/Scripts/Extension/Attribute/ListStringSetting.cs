using UnityEngine;

namespace Extension.Attribute
{
    [CreateAssetMenu(fileName = "ListStringSetting", menuName = "Node/ListStringSetting", order = 0)]
    public class ListStringSetting : ScriptableObject
    {
        public string[] strings;
    }
}