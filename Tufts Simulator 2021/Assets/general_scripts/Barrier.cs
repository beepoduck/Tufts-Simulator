using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Barrier : MonoBehaviour
{
    public int xp_needed;
    public GameObject barrier;
    public Text barrier_text;
    private int player_xp;
    // Start is called before the first frame update
    void Start()
    {
      barrier.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
        player_xp = FindObjectOfType<FirstPersonController>().GetXP();
        if(player_xp >= xp_needed)
        {
          barrier.SetActive(false);
        }
        else
        {
          barrier_text.text = "You Are Not A High Enough Level For This Area Yet\n(Must Have 10 XP)";
          StartCoroutine(DisplayBarrierText());
        }
      }
    }

    IEnumerator DisplayBarrierText()
    {
      barrier_text.enabled = true;
      yield return new WaitForSeconds(3);
      barrier_text.enabled = false;
    }
}
