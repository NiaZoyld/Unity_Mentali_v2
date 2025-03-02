using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool alreadyCollected = false; // Empêche le double comptage

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si c'est le joueur et que la pièce n'a pas déjà été ramassée
        if (!alreadyCollected && collision.gameObject.CompareTag("Player"))
        {
            alreadyCollected = true; // Marque la pièce comme collectée
            CoinManager.instance.CollectCoin(); // Augmente le score
            Destroy(gameObject); // Supprime la pièce
        }
    }
}