using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string escenaASiguiente;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(escenaASiguiente);
    }
}
