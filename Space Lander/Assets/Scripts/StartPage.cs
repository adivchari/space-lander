using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            NextLevel();
    }
    void NextLevel()
    {
        

        int CurrentScene=SceneManager.GetActiveScene().buildIndex;
        int NextScene=CurrentScene+1;

        if(NextScene==SceneManager.sceneCountInBuildSettings)
            NextScene=0;

        SceneManager.LoadScene(NextScene);
    }
}
