using UnityEngine;
using UnityEditor;

public class MateryalOlusturucu : EditorWindow
{
    [MenuItem("Tools/BlackSea Materyaller Oluştur")]
    static void MateryalOlustur()
    {
        // Deniz tabanı materyali (kumsal)
        Material kumMat = new Material(Shader.Find("Standard"));
        kumMat.color = new Color(0.76f, 0.70f, 0.50f, 1f);
        AssetDatabase.CreateAsset(kumMat, "Assets/Materials/Kum.mat");
        
        // Balık materyali (turuncu)
        Material balikMat = new Material(Shader.Find("Standard"));
        balikMat.color = new Color(1f, 0.5f, 0.0f, 1f);
        AssetDatabase.CreateAsset(balikMat, "Assets/Materials/Balik.mat");
        
        // Kılıç materyali (gümüş)
        Material kilicMat = new Material(Shader.Find("Standard"));
        kilicMat.color = new Color(0.75f, 0.75f, 0.75f, 1f);
        kilicMat.SetFloat("_Metallic", 0.8f);
        AssetDatabase.CreateAsset(kilicMat, "Assets/Materials/Kilic.mat");
        
        // Zıpkın materyali (kahverengi)
        Material zipkinMat = new Material(Shader.Find("Standard"));
        zipkinMat.color = new Color(0.4f, 0.26f, 0.13f, 1f);
        AssetDatabase.CreateAsset(zipkinMat, "Assets/Materials/Zipkin.mat");
        
        AssetDatabase.SaveAssets();
        Debug.Log("BlackSea materyalleri oluşturuldu!");
    }
    
    [MenuItem("Tools/Kamerayı Mavi Yap")]
    static void KamerayiMaviYap()
    {
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            mainCam.backgroundColor = new Color(0.1f, 0.3f, 0.5f, 1f);
            mainCam.clearFlags = CameraClearFlags.SolidColor;
            Debug.Log("Kamera mavi yapıldı (su altı efekti)!");
        }
    }
}
