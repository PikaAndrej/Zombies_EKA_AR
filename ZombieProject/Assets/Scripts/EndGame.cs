using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject loseUI;
    private GameManager gameManager;
    private AudioSource audioSource;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
        audioSource = FindObjectOfType<AudioSource>();
        loseUI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            LoseMenu();
        }
    }

    private void LoseMenu()
    {
        Time.timeScale = 0;
        loseUI.SetActive(true);
        gameManager.gameActive = false;
        audioSource.Stop();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
