using DoubleScroll.Scripts;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(NestedScroll))]
    public class NestedScrollEditor : ScrollRectEditor
    {
        private SerializedProperty _parentScrollRectProp;
        private GUIContent _parentScrollRectGUIContent = new GUIContent("Parent ScrollRect");
 
        protected override void OnEnable()
        {
            base.OnEnable();
            _parentScrollRectProp = serializedObject.FindProperty("_parentScrollRect");
        }
 
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUILayout.PropertyField(_parentScrollRectProp, _parentScrollRectGUIContent);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
