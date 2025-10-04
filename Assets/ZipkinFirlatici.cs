using UnityEngine;

public class ZipkinFirlatici : MonoBehaviour
{
    public GameObject zipkinPrefab;
    public Transform firlatmaNoktasi;
    public float firlatmaKuvveti = 15f;
    
    void Update()
    {
        // Sağ el tetik tuşuna basıldığında zıpkın fırlat
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            ZipkinFirlat();
        }
    }
    
    void ZipkinFirlat()
    {
        if (zipkinPrefab != null && firlatmaNoktasi != null)
        {
            // Zıpkın prefabını oluştur
            GameObject yeniZipkin = Instantiate(zipkinPrefab, firlatmaNoktasi.position, firlatmaNoktasi.rotation);
            
            // Rigidbody ekle (eğer yoksa)
            Rigidbody rb = yeniZipkin.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = yeniZipkin.AddComponent<Rigidbody>();
            }
            
            // Fırlatma kuvvetini uygula
            Vector3 firlatmaYonu = firlatmaNoktasi.forward;
            rb.AddForce(firlatmaYonu * firlatmaKuvveti, ForceMode.Impulse);
            
            // 5 saniye sonra zıpkını yok et
            Destroy(yeniZipkin, 5f);
            
            Debug.Log("Zıpkın fırlatıldı!");
        }
    }
}
