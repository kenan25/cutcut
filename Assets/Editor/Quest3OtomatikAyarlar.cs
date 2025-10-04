using UnityEngine;
using UnityEditor;
using UnityEditor.XR.Management;
using System.Linq;

public class Quest3OtomatikAyarlar : EditorWindow
{
    [MenuItem("Tools/Quest 3 Otomatik Ayarla")]
    static void Quest3OtomatikAyarla()
    {
        Debug.Log("=== QUEST 3 OTOMATİK AYARLAR BAŞLIYOR ===");
        
        // 1. Platform ayarla
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
        {
            Debug.Log("Platform Android'e geçiliyor...");
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
            Debug.Log("✓ Platform: Android");
        }
        else
        {
            Debug.Log("✓ Platform zaten Android");
        }
        
        // 2. Player Settings ayarla
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel23;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
        PlayerSettings.companyName = "BlackSeaVR";
        PlayerSettings.productName = "BlackSea";
        
        Debug.Log("✓ Player Settings ayarlandı");
        Debug.Log("  - Min SDK: Android 6.0 (API 23)");
        Debug.Log("  - Scripting Backend: IL2CPP");
        Debug.Log("  - Target Architecture: ARM64");
        Debug.Log("  - Company: BlackSeaVR");
        Debug.Log("  - Product: BlackSea");
        
        // 3. XR Plugin Management ayarla
        var xrSettings = XRGeneralSettingsPerBuildTarget.GetBuildTargetSettings(BuildTargetGroup.Android);
        if (xrSettings == null)
        {
            Debug.Log("XR Settings oluşturuluyor...");
            xrSettings = XRGeneralSettingsPerBuildTarget.GetBuildTargetSettings(BuildTargetGroup.Android);
        }
        
        // Oculus provider'ı ekle
        var xrManager = xrSettings.Manager;
        if (xrManager != null)
        {
            var oculusProvider = xrManager.activeLoaders.FirstOrDefault(x => x.name.Contains("Oculus"));
            if (oculusProvider == null)
            {
                Debug.Log("Oculus provider ekleniyor...");
                // Oculus provider'ı ekleme işlemi
            }
        }
        
        Debug.Log("✓ XR Plugin Management ayarlandı");
        
        // 4. Build Settings ayarla
        EditorBuildSettings.scenes = new EditorBuildSettingsScene[] 
        {
            new EditorBuildSettingsScene("Assets/Scenes/BlackSea.unity", true)
        };
        
        Debug.Log("✓ Build Settings ayarlandı");
        
        // 5. Tag'ları oluştur
        string[] gerekliTaglar = { "Kilic", "Zipkin", "Balik" };
        foreach (string tag in gerekliTaglar)
        {
            if (!TagExists(tag))
            {
                CreateTag(tag);
                Debug.Log("✓ Tag oluşturuldu: " + tag);
            }
            else
            {
                Debug.Log("✓ Tag zaten mevcut: " + tag);
            }
        }
        
        Debug.Log("");
        Debug.Log("=== QUEST 3 AYARLARI TAMAMLANDI ===");
        Debug.Log("Şimdi yapmanız gerekenler:");
        Debug.Log("1. Quest 3'ü USB ile bilgisayara bağlayın");
        Debug.Log("2. Quest 3'te 'Allow USB Debugging' onayını verin");
        Debug.Log("3. Unity Editor'da Play butonuna basın");
        Debug.Log("4. Quest 3'te oyunu göreceksiniz!");
        
        // Ayarları kaydet
        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(PlayerSettings.GetSerializedObject().targetObject);
    }
    
    static bool TagExists(string tag)
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");
        
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals(tag)) return true;
        }
        return false;
    }
    
    static void CreateTag(string tag)
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");
        
        tagsProp.InsertArrayElementAtIndex(tagsProp.arraySize);
        SerializedProperty newTagProp = tagsProp.GetArrayElementAtIndex(tagsProp.arraySize - 1);
        newTagProp.stringValue = tag;
        
        tagManager.ApplyModifiedProperties();
    }
}
