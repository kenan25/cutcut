using UnityEngine;
using TMPro;

public class OyunYoneticisi : MonoBehaviour
{
    public GameObject balikPrefab;
    public TextMeshProUGUI puanYazisi;
    
    private int puan = 0;
    private float balikSpawnZamani = 0f;
    private float balikSpawnAraligi = 3f;
    
    void Start()
    {
        // İlk balığı spawn et
        BalikSpawnEt();
        
        // Puan yazısını güncelle
        PuanGuncelle();
    }
    
    void Update()
    {
        balikSpawnZamani += Time.deltaTime;
        
        // Belirli aralıklarla balık spawn et
        if (balikSpawnZamani >= balikSpawnAraligi)
        {
            BalikSpawnEt();
            balikSpawnZamani = 0f;
        }
    }
    
    void BalikSpawnEt()
    {
        if (balikPrefab != null)
        {
            // Rastgele pozisyon belirle (deniz tabanı üzerinde)
            Vector3 spawnPozisyonu = new Vector3(
                Random.Range(-10f, 10f),
                1f, // Deniz tabanından biraz yukarı
                Random.Range(-10f, 10f)
            );
            
            // Balık prefabını oluştur
            GameObject yeniBalik = Instantiate(balikPrefab, spawnPozisyonu, Quaternion.identity);
            
            // 10 saniye sonra balığı yok et (kesilmezse)
            Destroy(yeniBalik, 10f);
        }
    }
    
    public void BalikKesildi()
    {
        puan += 10;
        PuanGuncelle();
        Debug.Log("Puan: " + puan);
    }
    
    void PuanGuncelle()
    {
        if (puanYazisi != null)
        {
            puanYazisi.text = "Puan: " + puan;
        }
    }
}
