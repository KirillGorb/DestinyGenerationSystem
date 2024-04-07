using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CorrectSequence", menuName = "Node/CorrectSequence", order = 0)]
public class CorrectSequence : ScriptableObject
{
    [SerializeField, StringList] private string person;
    [SerializeField, StringList] private List<string> sequence;

    public string Key => person;

    public int Size => sequence.Count;

    public bool IsCorrect(IReadOnlyList<string> value)
    {
        if (value.Count < Size)
            return false;
        int i = 0;
        foreach (var item in sequence)
            if (item != value[i++])
                return false;


        return true;
    }
}