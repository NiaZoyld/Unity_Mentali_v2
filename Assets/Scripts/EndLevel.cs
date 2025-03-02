using UnityEngine;
using UnityEngine.Video;

public class EndLevel : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public GameObject player; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            StartCinematic();
        }
    }

    void StartCinematic()
    {
        Debug.Log("Début de la cinématique de fin !");
        player.GetComponent<PlayerMovement>().enabled = false; 
        videoPlayer.Play(); 
        videoPlayer.loopPointReached += EndGame; 
    }

    void EndGame(VideoPlayer vp)
    {
        Debug.Log("Cinématique terminée, fin du jeu !");
    }
}