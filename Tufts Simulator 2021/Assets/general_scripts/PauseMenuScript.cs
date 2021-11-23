using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject CanvasObject;

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
        {
          Debug.Log("ESC PRESSED");
          PauseGame();
        }
    }

    public void PauseGame()
    {
      //pauses game / freezes time
      Time.timeScale = 0;
      //lets player use mouse to click buttons on menu
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      //adds pause menu to screen
      CanvasObject.SetActive(true);
    }

    public void PauseResumeButton()
    {
      //removes pause menu from screen
      CanvasObject.SetActive(false);
      //resumes game (unfreezes time)
      FindObjectOfType<npc_interaction>().FreePlayer();
    }

    public void PauseQuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}
