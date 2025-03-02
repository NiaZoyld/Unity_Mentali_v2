using UnityEngine;

public class Door : MonoBehaviour
{
    public KeyCode openKey = KeyCode.E; // Touche pour ouvrir la porte
    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(openKey))
        {
            Debug.Log("Touche E pressée !"); // Vérifie si la touche est détectée

            if (CoinManager.instance.AllCoinsCollected())
            {
                OpenDoor();
            }
            else
            {
                Debug.Log("Toutes les pièces ne sont pas collectées !");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Le joueur est proche de la porte !");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
            Debug.Log("Le joueur s'éloigne de la porte !");
        }
    }

    void OpenDoor()
    {
        Debug.Log("Porte ouverte !");
        Destroy(gameObject); // Supprime la porte
    }
}