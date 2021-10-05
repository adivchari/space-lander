using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPage : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
