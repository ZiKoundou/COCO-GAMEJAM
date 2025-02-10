using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public SceneTransition sceneTransition;
    public MusicManager musicManager;

    void Start(){
        sceneTransition = FindObjectOfType<SceneTransition>();
        //musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
    }

    public void PlayGame(){
        sceneTransition.NextScene();
        musicManager.PlayFightTheme();
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor
        #endif
    }

}
