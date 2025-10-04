using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class MenuyuDuzenle : EditorWindow
{
    [MenuItem("Tools/Ana Menuyu Duzenle")]
    static void Duzenle()
    {
        // Panel bul ve ayarla
        GameObject panel = GameObject.Find("Panel");
        if (panel != null)
        {
            Image panelImg = panel.GetComponent<Image>();
            if (panelImg != null)
            {
                panelImg.color = new Color(0.1f, 0.3f, 0.5f, 0.9f); // Mavi arka plan
            }
        }
        
        // Baslik text olustur
        GameObject baslikObj = new GameObject("Baslik");
        baslikObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
        TextMeshProUGUI baslik = baslikObj.AddComponent<TextMeshProUGUI>();
        baslik.text = "BLACKSEA\nSU ALTI AVLANMA";
        baslik.fontSize = 48;
        baslik.color = Color.white;
        baslik.alignment = TextAlignmentOptions.Center;
        baslik.fontStyle = FontStyles.Bold;
        
        RectTransform baslikRect = baslik.GetComponent<RectTransform>();
        baslikRect.anchorMin = new Vector2(0.5f, 0.7f);
        baslikRect.anchorMax = new Vector2(0.5f, 0.9f);
        baslikRect.pivot = new Vector2(0.5f, 0.5f);
        baslikRect.anchoredPosition = Vector2.zero;
        baslikRect.sizeDelta = new Vector2(600, 200);
        
        // Aciklama text
        GameObject aciklamaObj = new GameObject("Aciklama");
        aciklamaObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
        TextMeshProUGUI aciklama = aciklamaObj.AddComponent<TextMeshProUGUI>();
        aciklama.text = "VR kumandalarla su altında balık avlayın!\n\nSağ el: Kılıç (yakın mesafe)\nSol el: Zıpkın (uzak mesafe)\n\nSpace tuşu ile test edin";
        aciklama.fontSize = 20;
        aciklama.color = new Color(0.9f, 0.9f, 0.9f);
        aciklama.alignment = TextAlignmentOptions.Center;
        
        RectTransform aciklamaRect = aciklama.GetComponent<RectTransform>();
        aciklamaRect.anchorMin = new Vector2(0.5f, 0.45f);
        aciklamaRect.anchorMax = new Vector2(0.5f, 0.65f);
        aciklamaRect.pivot = new Vector2(0.5f, 0.5f);
        aciklamaRect.anchoredPosition = Vector2.zero;
        aciklamaRect.sizeDelta = new Vector2(700, 200);
        
        // Butonlari bul ve ayarla
        Button[] butonlar = FindObjectsOfType<Button>();
        int butonIndex = 0;
        
        foreach (Button buton in butonlar)
        {
            RectTransform butonRect = buton.GetComponent<RectTransform>();
            
            if (butonIndex == 0) // Ilk buton - OYNA
            {
                buton.name = "OynaButonu";
                butonRect.anchorMin = new Vector2(0.5f, 0.3f);
                butonRect.anchorMax = new Vector2(0.5f, 0.3f);
                butonRect.pivot = new Vector2(0.5f, 0.5f);
                butonRect.anchoredPosition = Vector2.zero;
                butonRect.sizeDelta = new Vector2(300, 60);
                
                // Buton rengi - yesil
                Image butonImg = buton.GetComponent<Image>();
                if (butonImg != null)
                {
                    ColorBlock colors = buton.colors;
                    colors.normalColor = new Color(0.2f, 0.8f, 0.2f);
                    colors.highlightedColor = new Color(0.3f, 1f, 0.3f);
                    colors.pressedColor = new Color(0.1f, 0.6f, 0.1f);
                    buton.colors = colors;
                }
                
                // Text
                TextMeshProUGUI butonText = buton.GetComponentInChildren<TextMeshProUGUI>();
                if (butonText != null)
                {
                    butonText.text = "OYNA";
                    butonText.fontSize = 32;
                    butonText.fontStyle = FontStyles.Bold;
                }
            }
            else if (butonIndex == 1) // Ikinci buton - CIKIS
            {
                buton.name = "CikisButonu";
                butonRect.anchorMin = new Vector2(0.5f, 0.15f);
                butonRect.anchorMax = new Vector2(0.5f, 0.15f);
                butonRect.pivot = new Vector2(0.5f, 0.5f);
                butonRect.anchoredPosition = Vector2.zero;
                butonRect.sizeDelta = new Vector2(300, 60);
                
                // Buton rengi - kirmizi
                Image butonImg = buton.GetComponent<Image>();
                if (butonImg != null)
                {
                    ColorBlock colors = buton.colors;
                    colors.normalColor = new Color(0.8f, 0.2f, 0.2f);
                    colors.highlightedColor = new Color(1f, 0.3f, 0.3f);
                    colors.pressedColor = new Color(0.6f, 0.1f, 0.1f);
                    buton.colors = colors;
                }
                
                // Text
                TextMeshProUGUI butonText = buton.GetComponentInChildren<TextMeshProUGUI>();
                if (butonText != null)
                {
                    butonText.text = "ÇIKIŞ";
                    butonText.fontSize = 32;
                    butonText.fontStyle = FontStyles.Bold;
                }
            }
            
            butonIndex++;
        }
        
        // MenuYoneticisi ekle
        GameObject menuObj = new GameObject("MenuYoneticisi");
        AnaMenuYoneticisi menuScript = menuObj.AddComponent<AnaMenuYoneticisi>();
        
        // Referanslari bagla
        menuScript.oynaButonu = GameObject.Find("OynaButonu")?.GetComponent<Button>();
        menuScript.cikisButonu = GameObject.Find("CikisButonu")?.GetComponent<Button>();
        menuScript.baslikText = GameObject.Find("Baslik")?.GetComponent<TextMeshProUGUI>();
        menuScript.aciklamaText = GameObject.Find("Aciklama")?.GetComponent<TextMeshProUGUI>();
        
        // Kamera rengini mavi yap
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            mainCam.backgroundColor = new Color(0.05f, 0.15f, 0.25f);
            mainCam.clearFlags = CameraClearFlags.SolidColor;
        }
        
        // Text (TMP) objesini sil (menu'de gereksiz)
        GameObject oldText = GameObject.Find("Text (TMP)");
        if (oldText != null)
        {
            DestroyImmediate(oldText);
        }
        
        Debug.Log("Ana menu duzenlendi!");
    }
}
