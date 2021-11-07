using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{    
    void Update() {
        if (Input.GetKey("space"))
        {
            SceneManager.LoadScene("BrettScene");
        } 
        else if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

}
