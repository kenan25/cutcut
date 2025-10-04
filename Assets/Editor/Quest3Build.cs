using UnityEngine;
using UnityEditor;

public class Quest3Build : EditorWindow
{
    [MenuItem("Tools/Quest 3'e Build Et")]
    static void Quest3BuildEt()
    {
        Debug.Log("=== QUEST 3 BUILD BAŞLIYOR ===");
        
        // Build Settings kontrolü
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
        {
            Debug.LogError("Platform Android değil! Önce Android'e geçin.");
            return;
        }
        
        // Build path ayarla
        string buildPath = "C:/Users/gulsum/Desktop/BlackSea.apk";
        
        // Build ayarları
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/BlackSea.unity" };
        buildPlayerOptions.locationPathName = buildPath;
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;
        
        Debug.Log("Build başlıyor: " + buildPath);
        
        // Build işlemi
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        
        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("✓ Build başarılı! APK oluşturuldu: " + buildPath);
            Debug.Log("");
            Debug.Log("=== QUEST 3'E YÜKLEME ===");
            Debug.Log("1. Quest 3'ü USB ile bağlayın");
            Debug.Log("2. Quest 3'te 'Allow USB Debugging' onayını verin");
            Debug.Log("3. APK'yı Quest 3'e yükleyin");
            Debug.Log("4. Quest 3'te oyunu başlatın");
        }
        else
        {
            Debug.LogError("Build başarısız! Hataları kontrol edin.");
        }
    }
}
