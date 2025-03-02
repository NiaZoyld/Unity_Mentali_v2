using UnityEngine;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Référence au VideoPlayer

    void Start()
    {
        videoPlayer.loopPointReached += EndVideo; // Événement quand la vidéo se termine
    }

    void EndVideo(VideoPlayer vp)
    {
        Debug.Log("Vidéo terminée, début du jeu !");
        FindFirstObjectByType<PlayerMovement>().enabled = true; // Active le joueur
        gameObject.SetActive(false); // Désactive l'objet vidéo
    }
}