using UnityEngine;

public class ZipkinMermisi : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        SuAltiYaratik yaratik = collision.gameObject.GetComponent<SuAltiYaratik>();
        if (yaratik != null)
        {
            yaratik.Vuruldu();
            Destroy(gameObject);
        }
    }
}
