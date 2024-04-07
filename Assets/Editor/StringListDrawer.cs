using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(StringListAttribute))]
public class StringListAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var attr = attribute as StringListAttribute;
        var strings = attr.stringListAsset.strings;

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