using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Text puanText;
    public Text saglikText;
    
    private int puan = 0;
    private int saglik = 100;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    void Start()
    {
        GuiGuncelle();
    }
    
    public void PuanEkle(int miktar)
    {
        puan += miktar;
        GuiGuncelle();
    }
    
    public void HasarAl(int miktar)
    {
        saglik -= miktar;
        if (saglik < 0) saglik = 0;
        GuiGuncelle();
        
        if (saglik <= 0)
        {
            OyunBitti();
        }
    }
    
    void GuiGuncelle()
    {
        if (puanText != null) puanText.text = "Puan: " + puan;
        if (saglikText != null) saglikText.text = "Sağlık: " + saglik;
    }
    
    void OyunBitti()
    {
        Debug.Log("OYUN BİTTİ! Toplam Puan: " + puan);
    }
}
