using UnityEngine;
using UnityEditor;

public class BuildSettingsGuncelle : EditorWindow
{
    [MenuItem("Tools/Build Settings Guncelle")]
    static void Guncelle()
    {
        EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[2];
        scenes[0] = new EditorBuildSettingsScene("Assets/Scenes/AnaMenu.unity", true);
        scenes[1] = new EditorBuildSettingsScene("Assets/Scenes/BlackSea.unity", true);
        EditorBuildSettings.scenes = scenes;
        
        Debug.Log("Build Settings guncellendi! Sahne sirasi:");
        Debug.Log("0. AnaMenu (Ana menu)");
        Debug.Log("1. BlackSea (Oyun sahnesi)");
    }
}
