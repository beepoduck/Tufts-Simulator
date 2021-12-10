using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class paperbagAddXP : MonoBehaviour
{
  public Collider box;

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
        FindObjectOfType<FirstPersonController>().addXP(25);
      }
    }

}
