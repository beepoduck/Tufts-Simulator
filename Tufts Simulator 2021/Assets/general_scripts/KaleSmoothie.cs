using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class KaleSmoothie : MonoBehaviour
{
    public GameObject player;
    private FirstPersonController fps_script;

void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
        //This function call adds 5 health to player
        FindObjectOfType<FirstPersonController>().IncreaseHealth(5);
        //Destroys kale smoothie object so that the player "drinks" it
        Object.Destroy(this.gameObject);
    }
  }
}
