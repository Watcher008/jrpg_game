using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class QuickStartEditor
{
    // click command-0 to go to the prelaunch scene and then play

    [MenuItem("Edit/Play-Unplay, But From Prelaunch Scene %0")]
    public static void PlayFromPrelaunchScene()
    {
        if (EditorApplication.isPlaying == true)
        {
            EditorApplication.isPlaying = false;
            return;
        }
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(
                    "Assets/Scenes/Game Scenes/Background Elements/BootStraps.unity");
        EditorApplication.isPlaying = true;
    }
}