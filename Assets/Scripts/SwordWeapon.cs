using UnityEngine;

public class SwordWeapon : MonoBehaviour
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
