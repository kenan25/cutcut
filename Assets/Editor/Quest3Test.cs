using UnityEngine;
using UnityEditor;

public class Quest3Test : EditorWindow
{
    [MenuItem("Tools/Quest 3 Test Modu")]
    static void Quest3TestModu()
    {
        Debug.Log("=== QUEST 3 TEST MODU ===");
        
        // Quest 3'ü Unity Editor'a bağlama adımları
        Debug.Log("1. Quest 3'ü USB ile bilgisayara bağlayın");
        Debug.Log("2. Quest 3'te 'Allow USB Debugging' onayını verin");
        Debug.Log("3. Quest 3'te 'Allow USB Debugging' onayını verin");
        Debug.Log("4. Unity Editor'da Play butonuna basın");
        Debug.Log("5. Quest 3'te oyunu göreceksiniz!");
        
        Debug.Log("");
        Debug.Log("=== TEST İÇİN GEREKLİ AYARLAR ===");
        
        // XR Plugin Management kontrolü
        Debug.Log("XR Plugin Management ayarları:");
        Debug.Log("- Edit > Project Settings > XR Plug-in Management");
        Debug.Log("- Android tabında 'Oculus' işaretli olmalı");
        
        // Build Settings kontrolü
        Debug.Log("Build Settings ayarları:");
        Debug.Log("- File > Build Settings > Android platform seçili olmalı");
        
        // Player Settings kontrolü
        Debug.Log("Player Settings ayarları:");
        Debug.Log("- Company Name: BlackSeaVR");
        Debug.Log("- Product Name: BlackSea");
        Debug.Log("- Scripting Backend: IL2CPP");
        Debug.Log("- Target Architecture: ARM64");
        
        Debug.Log("");
        Debug.Log("=== TEST BAŞLATMA ===");
        Debug.Log("Unity Editor'da Play butonuna basın!");
        Debug.Log("Quest 3'te oyunu göreceksiniz.");
    }
}
