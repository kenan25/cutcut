using UnityEngine;
using UnityEditor;

public class VRAyarlari : EditorWindow
{
    [MenuItem("Tools/VR Build Ayarlari")]
    static void Ayarla()
    {
        // Player Settings'i kontrol et
        Debug.Log("=== VR Build Kontrolu ===");
        Debug.Log("1. Android SDK kurulu mu kontrol edin");
        Debug.Log("2. USB Debugging acik mi kontrol edin");
        Debug.Log("3. VR headset USB ile bagli mi kontrol edin");
        Debug.Log("");
        Debug.Log("ADIMLAR:");
        Debug.Log("1. File > Build Settings");
        Debug.Log("2. Platform: Android sec");
        Debug.Log("3. 'Switch Platform' tikla");
        Debug.Log("4. Player Settings > XR Plug-in Management");
        Debug.Log("5. Android tab > Oculus/OpenXR'i aktif et");
        Debug.Log("6. VR headset'i USB ile bagla");
        Debug.Log("7. Headset'te 'USB Debugging'i onayla");
        Debug.Log("8. Build and Run");
        Debug.Log("");
        Debug.Log("=== Alternatif: PC'de Test ===");
        Debug.Log("VR headset yoksa, PC'de Space tusu ile test edebilirsiniz!");
    }
}
