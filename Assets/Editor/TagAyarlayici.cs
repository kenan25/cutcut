using UnityEngine;
using UnityEditor;

public class TagAyarlayici : EditorWindow
{
    [MenuItem("Tools/Tag Sistemi Ayarla")]
    static void TagSistemiAyarla()
    {
        Debug.Log("=== TAG SİSTEMİ AYARLANIYOR ===");
        
        // Gerekli tagları oluştur
        string[] gerekliTaglar = { "Kilic", "Zipkin", "Balik" };
        
        foreach (string tag in gerekliTaglar)
        {
            // Tag var mı kontrol et
            if (!TagExists(tag))
            {
                // Tag oluştur
                SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
                SerializedProperty tagsProp = tagManager.FindProperty("tags");
                
                tagsProp.InsertArrayElementAtIndex(tagsProp.arraySize);
                SerializedProperty newTagProp = tagsProp.GetArrayElementAtIndex(tagsProp.arraySize - 1);
                newTagProp.stringValue = tag;
                
                tagManager.ApplyModifiedProperties();
                Debug.Log("✓ Tag oluşturuldu: " + tag);
            }
            else
            {
                Debug.Log("✓ Tag zaten mevcut: " + tag);
            }
        }
        
        Debug.Log("");
        Debug.Log("=== TAG SİSTEMİ HAZIR ===");
        Debug.Log("Kullanılabilir taglar: Kilic, Zipkin, Balik");
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
}
