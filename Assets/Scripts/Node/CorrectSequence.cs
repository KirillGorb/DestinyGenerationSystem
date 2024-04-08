using System.Collections.Generic;
using Extension.Attribute;
using UnityEngine;

namespace Node
{
    [CreateAssetMenu(fileName = "CorrectSequence", menuName = "Node/CorrectSequence", order = 0)]
    public class CorrectSequence : ScriptableObject
    {
        [SerializeField, DropDownListString("ListStringSetting")] private string person;
        [SerializeField, DropDownListString("ListStringSetting")] private List<string> sequence;

        [SerializeField, TextArea] private string finalDescription;

        public string Key => person;
        public string FinalDescription => finalDescription;

        public bool IsCorrect(IReadOnlyList<string> value)
        {
            if (value.Count < sequence.Count)
                return false;
            int i = 0;
            foreach (var item in sequence)
                if (item != value[i++])
                    return false;


            return true;
        }
    }
}