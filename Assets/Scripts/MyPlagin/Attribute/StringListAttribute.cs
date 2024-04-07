using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class StringListAttribute : PropertyAttribute
{
    public StringList stringListAsset = Resources.Load<StringList>("StringList");
}