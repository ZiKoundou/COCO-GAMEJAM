using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public SceneTransition sceneTransition;
    void Start(){
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void PlayGame(){
        sceneTransition.NextScene();
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor
        #endif
    }

}
