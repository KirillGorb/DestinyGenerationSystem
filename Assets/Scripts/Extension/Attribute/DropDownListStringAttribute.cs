using System;
using UnityEngine;

namespace Extension.Attribute
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class DropDownListStringAttribute : PropertyAttribute
    {
        public readonly ListStringSetting ListStringSettingAsset;

        public DropDownListStringAttribute(string namePath)
        {
            ListStringSettingAsset = Resources.Load<ListStringSetting>(namePath);
        }
    }
}