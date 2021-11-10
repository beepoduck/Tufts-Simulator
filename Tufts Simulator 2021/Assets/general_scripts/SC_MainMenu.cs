using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SC_MainMenu : MonoBehaviour
{

    public GameObject MainMenu;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        SceneManager.LoadScene("BrettScene");
    }

    public void MapButton()
    {
        SceneManager.LoadScene("Map");
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}