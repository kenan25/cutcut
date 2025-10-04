using UnityEngine;
using UnityEditor;

public class Quest3TestBaslat : EditorWindow
{
    [MenuItem("Tools/Quest 3 Test Başlat")]
    static void Quest3TestBaslat()
    {
        Debug.Log("=== QUEST 3 TEST BAŞLATILIYOR ===");
        
        // Tüm ayarları kontrol et
        Quest3OtomatikAyarla();
        
        Debug.Log("");
        Debug.Log("=== TEST BAŞLATMA ===");
        Debug.Log("Unity Editor'da Play butonuna basın!");
        Debug.Log("Quest 3'te oyunu göreceksiniz.");
        
        // Play mode'a geç
        EditorApplication.isPlaying = true;
        
        Debug.Log("✓ Play mode başlatıldı");
        Debug.Log("Quest 3'te oyunu kontrol edin!");
    }
}
