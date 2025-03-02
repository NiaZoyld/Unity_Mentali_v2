using UnityEngine;
using UnityEngine.UI;
using TMPro; // Ajout pour TextMeshPro (si utilisé)

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Singleton global pour accéder à CoinManager facilement

    public TextMeshProUGUI coinText; // Décommente cette ligne si tu utilises TextMeshPro

    public int totalCoins = 10; // Nombre total de pièces à collecter
    private int collectedCoins = 0; // Nombre de pièces ramassées

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (coinText == null) 
        {
            Debug.LogError(" CoinManager : coinText n'est pas assigné dans l'Inspector !");
            return;
        }

        UpdateUI();
    }

    public void CollectCoin()
    {
        if (coinText == null) 
        {
            Debug.LogError(" CoinManager : coinText est null !");
            return;
        }

        collectedCoins++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = collectedCoins + "/" + totalCoins;
        }
        else
        {
            Debug.LogError(" CoinManager : coinText n'est pas assigné !");
        }
    }
    
    public bool AllCoinsCollected()
    {
        bool allCollected = collectedCoins >= totalCoins;
        Debug.Log("Toutes les pièces collectées ? " + allCollected); // Vérifie si la condition est remplie
          return allCollected;
    }   
}