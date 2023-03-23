using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GUIAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MinAttribute : MultiPropertyAttribute
    {
        private int Min { get; }

        public MinAttribute(int min)
        {
            Min = min;
        }

#if UNITY_EDITOR
        public override float? GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return GetDefaultPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Integer)
            {
                int newValue = EditorGUI.DelayedIntField(position, label, property.intValue);
                property.intValue = Math.Max(newValue, Min);
            }
            else if (property.propertyType == SerializedPropertyType.Float)
            {
                float newValue = EditorGUI.DelayedFloatField(position, label, property.intValue);
                property.floatValue = Mathf.Max(newValue, Min);
            }
        }
#endif
    }
}