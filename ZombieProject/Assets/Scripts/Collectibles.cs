using System;
using Unity.VisualScripting;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private GameManager gameManager;
    private bool isCollected = false;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckCollected(other.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        CheckCollected(other.gameObject);
    }
    private void CheckCollected(GameObject interactingObject)
    {
        if (gameManager != null && interactingObject == gameManager.selectedZombie) 
        {
            isCollected = true;
            gameManager.AddPoints(10); 
            Destroy(gameObject);
            isCollected = false;
        }
    }
}