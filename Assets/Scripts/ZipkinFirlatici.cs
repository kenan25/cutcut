using UnityEngine;

public class ZipkinFirlatici : MonoBehaviour
{
    [Header("Zipkin Ayarlari")]
    public GameObject zipkinPrefab;
    public Transform firlatmaNoktasi;
    public float firlatmaGucu = 20f;
    public float zipkinOmru = 5f;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            ZipkinFirlat();
        }
    }
    
    void ZipkinFirlat()
    {
        if (zipkinPrefab == null || firlatmaNoktasi == null) return;
        
        GameObject zipkin = Instantiate(zipkinPrefab, firlatmaNoktasi.position, firlatmaNoktasi.rotation);
        
        Rigidbody rb = zipkin.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = zipkin.AddComponent<Rigidbody>();
        }
        
        rb.useGravity = false;
        rb.velocity = firlatmaNoktasi.forward * firlatmaGucu;
        
        zipkin.tag = "Zipkin";
        
        Destroy(zipkin, zipkinOmru);
    }
}
