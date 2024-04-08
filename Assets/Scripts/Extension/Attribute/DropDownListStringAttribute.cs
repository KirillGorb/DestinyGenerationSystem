using System;
using UnityEngine;

namespace Extension.Attribute
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class DropDownListStringAttribute : PropertyAttribute
    {
        public readonly ListStringSetting ListStringSettingAsset = Resources.Load<ListStringSetting>("ListStringSetting");
    }
}