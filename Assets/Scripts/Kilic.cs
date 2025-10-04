using UnityEngine;

public class Kilic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SuAltiYaratik yaratik = other.GetComponent<SuAltiYaratik>();
        if (yaratik != null)
        {
            yaratik.Vuruldu();
        }
    }
}
