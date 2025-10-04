using UnityEngine;
using UnityEditor;

public class OyunuHazirla : EditorWindow
{
    [MenuItem("Tools/BlackSea Oyunu Hazirla")]
    static void Hazirla()
    {
        // Kilic collider'ini trigger yap
        GameObject kilic = GameObject.Find("Kilic");
        if (kilic != null)
        {
            Collider col = kilic.GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = true;
                Debug.Log("Kilic trigger yapildi");
            }
        }
        
        // Balik prefab'ini hazirla
        GameObject balikPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Balik_Prefab.prefab");
        if (balikPrefab != null)
        {
            string path = AssetDatabase.GetAssetPath(balikPrefab);
            GameObject balikInstance = PrefabUtility.LoadPrefabContents(path);
            
            Collider col = balikInstance.GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = true;
            }
            
            PrefabUtility.SaveAsPrefabAsset(balikInstance, path);
            PrefabUtility.UnloadPrefabContents(balikInstance);
            Debug.Log("Balik prefab trigger yapildi");
        }
        
        // Zipkin prefab'ini hazirla
        GameObject zipkinPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Zipkin_Prefab.prefab");
        if (zipkinPrefab != null)
        {
            string path = AssetDatabase.GetAssetPath(zipkinPrefab);
            GameObject zipkinInstance = PrefabUtility.LoadPrefabContents(path);
            
            Collider col = zipkinInstance.GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = true;
            }
            
            PrefabUtility.SaveAsPrefabAsset(zipkinInstance, path);
            PrefabUtility.UnloadPrefabContents(zipkinInstance);
            Debug.Log("Zipkin prefab trigger yapildi");
        }
        
        Debug.Log("BlackSea oyunu hazir!");
    }
}
