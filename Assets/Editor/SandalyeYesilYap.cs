using UnityEngine;
using UnityEditor;

public class SandalyeYesilYap : EditorWindow
{
    [MenuItem("Tools/Sandalyeyi Yeşil Yap")]
    static void YesilYap()
    {
        GameObject sandalye = GameObject.Find("Sandalye");
        if (sandalye == null)
        {
            Debug.LogError("Sandalye bulunamadı!");
            return;
        }

        Material yesil = new Material(Shader.Find("Standard"));
        yesil.color = new Color(0.2f, 0.8f, 0.2f, 1f);

        MeshRenderer[] renderers = sandalye.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material = yesil;
        }

        Debug.Log("Sandalye yeşil yapıldı!");
    }
}
