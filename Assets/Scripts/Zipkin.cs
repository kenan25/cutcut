using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Zipkin : MonoBehaviour
{
    public GameObject zipkinPrefab;
    public Transform firlatmaNoktasi;
    public float hiz = 15f;
    
    private XRGrabInteractable grabInteractable;
    
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.activated.AddListener(Firlat);
        }
    }
    
void Firlat(ActivateEventArgs args)
    {
        if (zipkinPrefab != null && firlatmaNoktasi != null)
        {
            GameObject zipkin = Instantiate(zipkinPrefab, firlatmaNoktasi.position, firlatmaNoktasi.rotation);
            Rigidbody rb = zipkin.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firlatmaNoktasi.forward * hiz;
            }
            
            Destroy(zipkin, 5f);
        }
    }
}
