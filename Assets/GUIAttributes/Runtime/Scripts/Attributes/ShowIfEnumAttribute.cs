using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GUIAttributes
{
    public class ShowIfEnumAttribute : MultiPropertyAttribute
    {
        private string PropertyName { get; }
        private int Value { get; }

        public ShowIfEnumAttribute(string propertyName, int value)
        {
            PropertyName = propertyName;
            Value = value;
        }

#if UNITY_EDITOR
        public override bool IsVisible(SerializedProperty property)
        {
            return IsConditionallyEnabled(property);
        }

        public override float? GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        private bool IsConditionallyEnabled(SerializedProperty property)
        {
            string propertyPath = property.propertyPath;
            string conditionPath = propertyPath.Replace(property.name, PropertyName);
            SerializedProperty dependentProperty = property.serializedObject.FindProperty(conditionPath);

            return dependentProperty != null && dependentProperty.propertyType == SerializedPropertyType.Enum ? dependentProperty.intValue == Value : false;
        }
#endif
    }
}
