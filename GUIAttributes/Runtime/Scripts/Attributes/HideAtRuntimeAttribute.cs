using UnityEngine;

namespace GUIAttributes
{
    public class HideAtRuntimeAttribute : MultiPropertyAttribute
    {
#if UNITY_EDITOR
        public override bool IsVisible(UnityEditor.SerializedProperty property)
        {
            return !Application.isPlaying;
        }
#endif
    }
}
