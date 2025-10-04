using UnityEngine;
using UnityEditor;

public class BuildSettingsEkle : EditorWindow
{
    [MenuItem("Tools/Build Settings'e Ekle")]
    static void Ekle()
    {
        EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[1];
        scenes[0] = new EditorBuildSettingsScene("Assets/Scenes/BlackSea.unity", true);
        EditorBuildSettings.scenes = scenes;
        
        Debug.Log("BlackSea sahnesi Build Settings'e eklendi!");
    }
}
