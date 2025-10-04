using UnityEngine;
using UnityEditor;

public class Quest3Ayarlari : EditorWindow
{
    [MenuItem("Tools/Quest 3 Icin Ayarla")]
    static void Ayarla()
    {
        Debug.Log("=== QUEST 3 AYARLARI YAPILIYOR ===");
        
        // Android platform secili mi kontrol et
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
        {
            Debug.LogWarning("Platform Android degil! File > Build Settings > Android > Switch Platform yapmaniz gerekiyor.");
        }
        else
        {
            Debug.Log("✓ Platform: Android");
        }
        
        // Player Settings ayarlari
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel23;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
        
        Debug.Log("✓ Min SDK: Android 6.0 (API 23)");
        Debug.Log("✓ Scripting Backend: IL2CPP");
        Debug.Log("✓ Target Architecture: ARM64");
        
        // Company ve Product name
        PlayerSettings.companyName = "BlackSeaVR";
        PlayerSettings.productName = "BlackSea";
        
        Debug.Log("✓ Product Name: BlackSea");
        
        Debug.Log("");
        Debug.Log("=== SIMDI YAPIN ===");
        Debug.Log("1. Edit > Project Settings > XR Plug-in Management");
        Debug.Log("2. Android tab'ina tiklayin");
        Debug.Log("3. 'Oculus' kutucugunu isaretleyin");
        Debug.Log("4. Quest 3'te USB debugging'i onaylayin");
        Debug.Log("5. File > Build Settings > Build And Run");
    }
}
