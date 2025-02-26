using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class ZombieManager : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject restartButton;
    private int totalZombies;
    private int fallenZombies = 0;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        
        totalZombies = GameObject.FindGameObjectsWithTag("Zombie").Length;
    }
    
    public void ZombieFell()
    {
        fallenZombies++;

        if (fallenZombies >= totalZombies)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("All zombies are gone! Game Over.");
        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        Time.timeScale = 0f; // stops the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // ensures time is normal after restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reloads the current scene
    }

}