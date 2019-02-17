using UnityEngine;
using UnityEditor;

namespace Steamy.Editor
{
    [CustomPropertyDrawer(typeof(LayerAttribute))]
    class LayerAttributeEditorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        { 
            property.intValue = EditorGUI.LayerField(position, label, property.intValue);
        }
    }
}
