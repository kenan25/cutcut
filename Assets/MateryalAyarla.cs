using UnityEngine;

public class MateryalAyarla : MonoBehaviour
{
    [System.Serializable]
    public class MateryalAyarlari
    {
        public Material kilicMateryali;    // Gümüş metalik
        public Material zipkinMateryali;   // Kahverengi
        public Material balikMateryali;    // Turuncu
        public Material denizTabanMateryali; // Kum rengi
    }
    
    public MateryalAyarlari materyaller;
    
    void Start()
    {
        MateryalleriAyarla();
    }
    
    void MateryalleriAyarla()
    {
        // Kılıç materyalini ayarla
        if (materyaller.kilicMateryali != null)
        {
            GameObject kilic = GameObject.FindGameObjectWithTag("Kilic");
            if (kilic != null)
            {
                Renderer kilicRenderer = kilic.GetComponent<Renderer>();
                if (kilicRenderer != null)
                {
                    kilicRenderer.material = materyaller.kilicMateryali;
                }
            }
        }
        
        // Zıpkın materyalini ayarla
        if (materyaller.zipkinMateryali != null)
        {
            GameObject zipkin = GameObject.FindGameObjectWithTag("Zipkin");
            if (zipkin != null)
            {
                Renderer zipkinRenderer = zipkin.GetComponent<Renderer>();
                if (zipkinRenderer != null)
                {
                    zipkinRenderer.material = materyaller.zipkinMateryali;
                }
            }
        }
        
        // Deniz tabanı materyalini ayarla
        if (materyaller.denizTabanMateryali != null)
        {
            GameObject denizTaban = GameObject.Find("DenizTaban");
            if (denizTaban != null)
            {
                Renderer denizTabanRenderer = denizTaban.GetComponent<Renderer>();
                if (denizTabanRenderer != null)
                {
                    denizTabanRenderer.material = materyaller.denizTabanMateryali;
                }
            }
        }
        
        Debug.Log("Materyaller ayarlandı!");
    }
}
