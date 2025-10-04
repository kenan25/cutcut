using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ReferanslariAyarla : EditorWindow
{
    [MenuItem("Tools/Referanslari Ayarla")]
    static void Ayarla()
    {
        // OyunYoneticisi'ne Text referansi ekle
        OyunYoneticisi oyun = FindObjectOfType<OyunYoneticisi>();
        if (oyun != null)
        {
            // Text (TMP) bul
            TextMeshProUGUI puanText = GameObject.Find("Text (TMP)")?.GetComponent<TextMeshProUGUI>();
            if (puanText != null)
            {
                SerializedObject so = new SerializedObject(oyun);
                so.FindProperty("puanYazisi").objectReferenceValue = puanText;
                so.ApplyModifiedProperties();
                Debug.Log("OyunYoneticisi'ne puan yazisi baglandi!");
            }
            
            // Balik prefab referansi
            GameObject balikPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Balik_Prefab.prefab");
            if (balikPrefab != null)
            {
                SerializedObject so = new SerializedObject(oyun);
                so.FindProperty("balikPrefab").objectReferenceValue = balikPrefab;
                so.ApplyModifiedProperties();
                Debug.Log("Balik prefab baglandi!");
            }
        }
        
        // ZipkinFirlatici referanslari
        ZipkinFirlatici zipkin = FindObjectOfType<ZipkinFirlatici>();
        if (zipkin != null)
        {
            // Zipkin prefab
            GameObject zipkinPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Zipkin_Prefab.prefab");
            if (zipkinPrefab != null)
            {
                SerializedObject so = new SerializedObject(zipkin);
                so.FindProperty("zipkinPrefab").objectReferenceValue = zipkinPrefab;
                so.ApplyModifiedProperties();
                Debug.Log("Zipkin prefab baglandi!");
            }
            
            // Firlatma noktasi (Zipkin objesi)
            Transform firlatmaNok = GameObject.Find("Zipkin")?.transform;
            if (firlatmaNok != null)
            {
                SerializedObject so = new SerializedObject(zipkin);
                so.FindProperty("firlatmaNoktasi").objectReferenceValue = firlatmaNok;
                so.ApplyModifiedProperties();
                Debug.Log("Firlatma noktasi baglandi!");
            }
        }
        
        // Text ayarlari
        TextMeshProUGUI text = GameObject.Find("Text (TMP)")?.GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = "Puan: 0";
            text.fontSize = 36;
            text.color = Color.white;
            text.alignment = TextAlignmentOptions.TopLeft;
            
            RectTransform rect = text.GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.anchorMin = new Vector2(0, 1);
                rect.anchorMax = new Vector2(0, 1);
                rect.pivot = new Vector2(0, 1);
                rect.anchoredPosition = new Vector2(20, -20);
                rect.sizeDelta = new Vector2(300, 50);
            }
            
            Debug.Log("Text ayarlandi!");
        }
        
        EditorUtility.SetDirty(oyun);
        EditorUtility.SetDirty(zipkin);
        
        Debug.Log("Tum referanslar ayarlandi! Oyun hazir!");
    }
}
