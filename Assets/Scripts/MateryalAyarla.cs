using UnityEngine;

public class MateryalAyarla : MonoBehaviour
{
    void Start()
    {
        // Bu objenin renderer'ını bul
        Renderer rend = GetComponent<Renderer>();
        if (rend != null && rend.material != null)
        {
            // Eğer obje adına göre renk belirle
            if (gameObject.name.Contains("Deniz") || gameObject.name.Contains("Tabani"))
            {
                rend.material.color = new Color(0.76f, 0.70f, 0.50f); // Kum
            }
            else if (gameObject.name.Contains("Balik"))
            {
                rend.material.color = new Color(1f, 0.5f, 0f); // Turuncu
            }
            else if (gameObject.name.Contains("Kilic"))
            {
                rend.material.color = new Color(0.75f, 0.75f, 0.75f); // Gümüş
                rend.material.SetFloat("_Metallic", 0.8f);
            }
            else if (gameObject.name.Contains("Zipkin"))
            {
                rend.material.color = new Color(0.4f, 0.26f, 0.13f); // Kahverengi
            }
        }
    }
}
