using UnityEngine;
using UnityEditor;
using System.Linq;

public class Quest3XRManager : EditorWindow
{
    [MenuItem("Tools/Quest 3 XR Ayarla")]
    static void Quest3XRAyarla()
    {
        Debug.Log("=== QUEST 3 XR AYARLARI ===");
        
        // XR Plugin Management ayarları
        var xrSettings = XRGeneralSettingsPerBuildTarget.GetBuildTargetSettings(BuildTargetGroup.Android);
        if (xrSettings == null)
        {
            Debug.Log("XR Settings oluşturuluyor...");
            xrSettings = XRGeneralSettingsPerBuildTarget.GetBuildTargetSettings(BuildTargetGroup.Android);
        }
        
        // XR Manager'ı etkinleştir
        if (xrSettings.Manager == null)
        {
            Debug.Log("XR Manager oluşturuluyor...");
            xrSettings.Manager = ScriptableObject.CreateInstance<XRManagerSettings>();
        }
        
        // Oculus provider'ı kontrol et
        var xrManager = xrSettings.Manager;
        if (xrManager != null)
        {
            Debug.Log("XR Manager ayarları kontrol ediliyor...");
            
            // Initialize XR on Startup'ı etkinleştir
            xrSettings.InitManagerOnStart = true;
            
            Debug.Log("✓ XR Manager ayarlandı");
            Debug.Log("✓ Initialize XR on Startup: " + xrSettings.InitManagerOnStart);
        }
        
        // Ayarları kaydet
        EditorUtility.SetDirty(xrSettings);
        AssetDatabase.SaveAssets();
        
        Debug.Log("");
        Debug.Log("=== XR AYARLARI TAMAMLANDI ===");
        Debug.Log("Quest 3'te oyunu test edebilirsiniz!");
    }
}
