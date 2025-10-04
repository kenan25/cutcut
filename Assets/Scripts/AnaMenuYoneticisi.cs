using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AnaMenuYoneticisi : MonoBehaviour
{
    public Button oynaButonu;
    public Button cikisButonu;
    public TextMeshProUGUI baslikText;
    public TextMeshProUGUI aciklamaText;
    
    void Start()
    {
        if (oynaButonu != null)
        {
            oynaButonu.onClick.AddListener(OyunuBaslat);
        }
        
        if (cikisButonu != null)
        {
            cikisButonu.onClick.AddListener(OyundanCik);
        }
    }
    
    void OyunuBaslat()
    {
        SceneManager.LoadScene("BlackSea");
    }
    
    void OyundanCik()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
