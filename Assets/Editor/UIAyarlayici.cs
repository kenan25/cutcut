using UnityEngine;
using UnityEditor;
using TMPro;

public class UIAyarlayici : EditorWindow
{
    [MenuItem("Tools/UI Sistemi Kur")]
    static void UISistemiKur()
    {
        Debug.Log("=== UI SİSTEMİ KURULUYOR ===");
        
        // Canvas oluştur
        GameObject canvas = new GameObject("Canvas");
        Canvas canvasComponent = canvas.AddComponent<Canvas>();
        canvasComponent.renderMode = RenderMode.WorldSpace;
        canvasComponent.worldCamera = Camera.main;
        
        // Canvas Scaler ekle
        UnityEngine.UI.CanvasScaler scaler = canvas.AddComponent<UnityEngine.UI.CanvasScaler>();
        scaler.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        
        // Graphic Raycaster ekle
        canvas.AddComponent<UnityEngine.UI.GraphicRaycaster>();
        
        // Puan yazısı oluştur
        GameObject puanYazisiObj = new GameObject("PuanYazisi");
        puanYazisiObj.transform.SetParent(canvas.transform);
        
        TextMeshProUGUI puanYazisi = puanYazisiObj.AddComponent<TextMeshProUGUI>();
        puanYazisi.text = "Puan: 0";
        puanYazisi.fontSize = 36;
        puanYazisi.color = Color.white;
        puanYazisi.alignment = TextAlignmentOptions.TopLeft;
        
        // RectTransform ayarla (sol üst köşe)
        RectTransform rectTransform = puanYazisiObj.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        rectTransform.anchoredPosition = new Vector2(50, -50);
        rectTransform.sizeDelta = new Vector2(300, 100);
        
        Debug.Log("✓ Canvas oluşturuldu");
        Debug.Log("✓ Puan yazısı oluşturuldu (sol üst köşe, 36pt, beyaz)");
        Debug.Log("");
        Debug.Log("=== UI SİSTEMİ HAZIR ===");
        Debug.Log("OyunYoneticisi scriptine puanYazisi referansını bağlayın!");
    }
}
