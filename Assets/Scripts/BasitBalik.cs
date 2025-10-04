using UnityEngine;

public class BasitBalik : MonoBehaviour
{
    [Header("Hareket")]
    public float hiz = 2f;
    public float yonDegismeZamani = 3f;
    
    [Header("Can")]
    public int can = 1;
    
    private Vector3 hedefYon;
    private float sonYonDegismeZamani;
    
    void Start()
    {
        YeniYonSec();
    }
    
    void Update()
    {
        // Hareket et
        transform.position += hedefYon * hiz * Time.deltaTime;
        
        // Belirli sürede yön değiştir
        if (Time.time - sonYonDegismeZamani > yonDegismeZamani)
        {
            YeniYonSec();
        }
        
        // Sınırları kontrol et
        if (Vector3.Distance(transform.position, Vector3.zero) > 50f)
        {
            transform.position = Vector3.zero + Vector3.up * Random.Range(-5f, 5f);
            YeniYonSec();
        }
    }
    
    void YeniYonSec()
    {
        hedefYon = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-0.3f, 0.3f),
            Random.Range(-1f, 1f)
        ).normalized;
        
        if (hedefYon != Vector3.zero)
        {
            transform.forward = hedefYon;
        }
        
        sonYonDegismeZamani = Time.time;
    }
    
    public void HasarAl(int hasar)
    {
        can -= hasar;
        if (can <= 0)
        {
            OyunYoneticisi oyun = FindObjectOfType<OyunYoneticisi>();
            if (oyun != null)
            {
                oyun.PuanEkle(10);
            }
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kilic"))
        {
            HasarAl(1);
        }
        else if (other.CompareTag("Zipkin"))
        {
            HasarAl(1);
            Destroy(other.gameObject);
        }
    }
}
