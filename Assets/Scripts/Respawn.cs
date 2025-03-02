using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) 
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        transform.position = startPosition; 
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; 
    }
}