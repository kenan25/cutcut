using UnityEngine;

public class BasitBalik : MonoBehaviour
{
    public float hareketHizi = 2f;
    public float donusHizi = 1f;
    private Vector3 hareketYonu;
    private float zamanlayici = 0f;
    
    void Start()
    {
        // Rastgele hareket yönü belirle
        hareketYonu = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
    
    void Update()
    {
        zamanlayici += Time.deltaTime;
        
        // Her 3 saniyede bir yön değiştir
        if (zamanlayici >= 3f)
        {
            hareketYonu = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            zamanlayici = 0f;
        }
        
        // Balığı hareket ettir
        transform.Translate(hareketYonu * hareketHizi * Time.deltaTime);
        
        // Hareket yönüne doğru döndür
        if (hareketYonu != Vector3.zero)
        {
            Quaternion hedefRotasyon = Quaternion.LookRotation(hareketYonu);
            transform.rotation = Quaternion.Slerp(transform.rotation, hedefRotasyon, donusHizi * Time.deltaTime);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Eğer çarpan obje kılıç veya zıpkın ise
        if (other.CompareTag("Kilic") || other.CompareTag("Zipkin"))
        {
            Debug.Log("Balık kesildi!");
            
            // Oyun yöneticisine balık kesildiğini bildir
            OyunYoneticisi oyunYoneticisi = FindObjectOfType<OyunYoneticisi>();
            if (oyunYoneticisi != null)
            {
                oyunYoneticisi.BalikKesildi();
            }
            
            // Balığı yok et
            Destroy(gameObject);
        }
    }
}
