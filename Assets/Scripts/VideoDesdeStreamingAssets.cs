using UnityEngine;
using UnityEngine.Video;

public class VideoDesdeStreamingAssets : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Ruta completa al archivo dentro de StreamingAssets
        string ruta = System.IO.Path.Combine(Application.streamingAssetsPath, "intro.mp4");

#if UNITY_WEBGL && !UNITY_EDITOR
        // En WebGL, StreamingAssets es una URL relativa al servidor
        videoPlayer.url = ruta;
#else
        // En otras plataformas es una ruta del sistema
        videoPlayer.url = "file://" + ruta;
#endif

        videoPlayer.Prepare(); // opcional: precargar
        videoPlayer.Play();
    }
}
