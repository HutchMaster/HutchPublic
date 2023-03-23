using UnityEditor;
using UnityEngine;

namespace GUIAttributes
{
    public class HideUntilRuntimeAttribute : MultiPropertyAttribute
    {
#if UNITY_EDITOR
        public override bool IsVisible(SerializedProperty property)
        {
            return Application.isPlaying;
        }
#endif
    }
}
