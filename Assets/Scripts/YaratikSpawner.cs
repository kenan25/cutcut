using UnityEngine;

public class YaratikSpawner : MonoBehaviour
{
    public GameObject yaratikPrefab;
    public float spawnAraligi = 3f;
    public float spawnMesafesi = 15f;
    public int maxYaratik = 10;
    
    private float sonSpawnZamani;
    private Transform oyuncu;
    
    void Start()
    {
        oyuncu = Camera.main.transform;
    }
    
    void Update()
    {
        if (Time.time - sonSpawnZamani > spawnAraligi)
        {
            int mevcutYaratiklar = GameObject.FindGameObjectsWithTag("Yaratik").Length;
            
            if (mevcutYaratiklar < maxYaratik)
            {
                SpawnYaratik();
                sonSpawnZamani = Time.time;
            }
        }
    }
    
    void SpawnYaratik()
    {
        if (yaratikPrefab == null || oyuncu == null) return;
        
        // Rastgele bir açıda spawn et
        float aci = Random.Range(0f, 360f);
        float radyan = aci * Mathf.Deg2Rad;
        
        Vector3 spawnPos = oyuncu.position;
        spawnPos.x += Mathf.Cos(radyan) * spawnMesafesi;
        spawnPos.z += Mathf.Sin(radyan) * spawnMesafesi;
        spawnPos.y = oyuncu.position.y + Random.Range(-5f, 5f);
        
        GameObject yaratik = Instantiate(yaratikPrefab, spawnPos, Quaternion.identity);
        yaratik.tag = "Yaratik";
    }
}
