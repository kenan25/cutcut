using UnityEngine;

public class KilicHasar : MonoBehaviour
{
    public float hasarMiktari = 50f;
    
    private void OnTriggerEnter(Collider other)
    {
        // Eğer çarpan obje balık ise
        if (other.CompareTag("Balik"))
        {
            Debug.Log("Kılıç ile balık kesildi!");
            
            // Oyun yöneticisine balık kesildiğini bildir
            OyunYoneticisi oyunYoneticisi = FindObjectOfType<OyunYoneticisi>();
            if (oyunYoneticisi != null)
            {
                oyunYoneticisi.BalikKesildi();
            }
            
            // Balığı yok et
            Destroy(other.gameObject);
        }
    }
}
