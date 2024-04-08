using System.Linq;
using Extension.Attribute;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(DropDownListStringAttribute))]
    public class DropDownListStringAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var attr = attribute as DropDownListStringAttribute;
            if (attr == null) return;

            var strings = attr.ListStringSettingAsset.strings;

            if (strings.Length == 0)
            {
                EditorGUI.LabelField(position, label.text, "No strings in the list.");
                return;
            }

            var index = strings.ToList().IndexOf(property.stringValue);
            var newIndex = EditorGUI.Popup(position, label.text, index, strings);

            if (newIndex != index)
            {
                property.stringValue = strings[newIndex];
            }
        }
    }
}