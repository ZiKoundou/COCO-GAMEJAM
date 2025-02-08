using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen; // Assign this in the Inspector

    void Start()
    {
        gameOverScreen.SetActive(false); // Hide game over screen at start
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true); // Show Game Over screen
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Debug.Log("Restart Button Clicked");
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
        
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Main Menu Button Clicked");
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene("MainMenu"); // Load main menu scene (make sure it's added in Build Settings)
        
    }
}
