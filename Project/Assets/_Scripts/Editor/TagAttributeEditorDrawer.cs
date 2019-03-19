using UnityEngine;
using UnityEditor;

namespace Steamy.Editor
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    class TagAttributeEditorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
    }
}
