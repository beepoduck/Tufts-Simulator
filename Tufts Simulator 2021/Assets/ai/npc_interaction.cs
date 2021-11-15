using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc_interaction : MonoBehaviour
{
    public Transform Player;
    public Dialogue dialogue;
    private bool playerhere;
    public Image m_speakto;
    // Start is called before the first frame update
    void Start()
    {
      playerhere = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        if (playerhere && Input.GetKeyDown(KeyCode.E))
        {
          Time.timeScale = 0;
          Cursor.visible = true;
          Cursor.lockState = CursorLockMode.None;
          m_speakto.enabled = false;
          TriggerDialogue();
          m_speakto.enabled = true;
        }
    }

    public void TriggerDialogue()
    {
      FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "Player")
      {
        playerhere = true;
        m_speakto.enabled = true;
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.gameObject.tag == "Player")
      {
        playerhere = false;
        m_speakto.enabled = false;
      }
    }

    public void FreePlayer()
    {
      Time.timeScale = 1;
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
    }


}
