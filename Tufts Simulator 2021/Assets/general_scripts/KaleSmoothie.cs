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
        // Debug.Log("hi");
        fps_script = player.GetComponent<FirstPersonController>();
        fps_script.m_PlayerHealth += 5;
    }
  }
}    
