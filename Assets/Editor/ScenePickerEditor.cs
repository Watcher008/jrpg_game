using UnityEditor;

namespace JS.SceneManagement
{
    /// <summary>
    /// Displays ScenePicker file path as a Unity Scene object.
    /// </summary>
    [CustomEditor(typeof(ScenePicker), true)]
    public class ScenePickerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var picker = target as ScenePicker;
            var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.ScenePath);

            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            var newScene = EditorGUILayout.ObjectField("Scene", oldScene, typeof(SceneAsset), false) as SceneAsset;

            if (EditorGUI.EndChangeCheck())
            {
                var newPath = AssetDatabase.GetAssetPath(newScene);
                var scenePathProperty = serializedObject.FindProperty("ScenePath");
                scenePathProperty.stringValue = newPath;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}