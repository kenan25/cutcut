using UnityEngine;

public class SuAltiYaratik : MonoBehaviour
{
    public float hiz = 2f;
    public int puan = 10;
    public int hasar = 10;
    
    private Transform hedef;
    private bool oldu = false;
    
    void Start()
    {
        hedef = Camera.main.transform;
    }
    
    void Update()
    {
        if (oldu) return;
        
        // Oyuncuya doğru yüz
        if (hedef != null)
        {
            Vector3 yon = (hedef.position - transform.position).normalized;
            transform.position += yon * hiz * Time.deltaTime;
            transform.LookAt(hedef);
        }
        
        // Oyuncuya çarpma kontrolü
        if (Vector3.Distance(transform.position, hedef.position) < 1.5f)
        {
            OyuncuyaCarpt();
        }
    }
    
    void OyuncuyaCarpt()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.HasarAl(hasar);
        }
        Yok();
    }
    
    public void Vuruldu()
    {
        if (oldu) return;
        oldu = true;
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PuanEkle(puan);
        }
        
        Yok();
    }
    
    void Yok()
    {
        Destroy(gameObject);
    }
}
