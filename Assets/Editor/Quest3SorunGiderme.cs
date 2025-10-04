using UnityEngine;
using UnityEditor;

public class Quest3SorunGiderme : EditorWindow
{
    [MenuItem("Tools/Quest 3 Sorun Giderme")]
    static void Quest3SorunGiderme()
    {
        Debug.Log("=== QUEST 3 SORUN GİDERME ===");
        
        // 1. Platform kontrolü
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
        {
            Debug.LogError("❌ Platform Android değil!");
            Debug.Log("Çözüm: File > Build Settings > Android > Switch Platform");
            return;
        }
        else
        {
            Debug.Log("✓ Platform: Android");
        }
        
        // 2. XR Plugin Management kontrolü
        Debug.Log("XR Plugin Management kontrolü:");
        Debug.Log("- Edit > Project Settings > XR Plug-in Management");
        Debug.Log("- Android tabında 'Oculus' işaretli olmalı");
        Debug.Log("- 'Initialize XR on Startup' işaretli olmalı");
        
        // 3. Player Settings kontrolü
        Debug.Log("Player Settings kontrolü:");
        Debug.Log("- Company Name: " + PlayerSettings.companyName);
        Debug.Log("- Product Name: " + PlayerSettings.productName);
        Debug.Log("- Scripting Backend: " + PlayerSettings.GetScriptingBackend(BuildTargetGroup.Android));
        Debug.Log("- Target Architecture: " + PlayerSettings.Android.targetArchitectures);
        
        // 4. Quest 3 bağlantı kontrolü
        Debug.Log("");
        Debug.Log("=== QUEST 3 BAĞLANTI KONTROLÜ ===");
        Debug.Log("1. Quest 3'ü USB ile bilgisayara bağlayın");
        Debug.Log("2. Quest 3'te 'Allow USB Debugging' onayını verin");
        Debug.Log("3. Quest 3'te Developer Mode açık olmalı");
        Debug.Log("4. Quest 3'te 'Unknown Sources' açık olmalı");
        
        // 5. Test adımları
        Debug.Log("");
        Debug.Log("=== TEST ADIMLARI ===");
        Debug.Log("1. Unity Editor'da Play butonuna basın");
        Debug.Log("2. Quest 3'te oyunu görmelisiniz");
        Debug.Log("3. Görmüyorsanız Quest 3'ü yeniden bağlayın");
        Debug.Log("4. Unity Editor'ı yeniden başlatın");
        
        // 6. Alternatif çözümler
        Debug.Log("");
        Debug.Log("=== ALTERNATİF ÇÖZÜMLER ===");
        Debug.Log("1. Quest 3'ü yeniden başlatın");
        Debug.Log("2. USB kablosunu değiştirin");
        Debug.Log("3. Unity Editor'ı yeniden başlatın");
        Debug.Log("4. Quest 3'te 'Allow USB Debugging' onayını tekrar verin");
    }
}
