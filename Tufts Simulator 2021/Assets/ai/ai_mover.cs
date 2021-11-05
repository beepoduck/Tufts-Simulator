using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


 public class ai_mover : MonoBehaviour
 {

     public Transform Player;
     public GameObject playerchar;
     int MoveSpeed = 4;
     int MaxDist = 10;
     int MinDist = 1;




     void Start()
     {
       playerchar = GameObject.FindWithTag("Player");
     }

     void Update()
     {
         transform.LookAt(Player);
         if (Vector3.Distance(transform.position, Player.position) <= MaxDist && Vector3.Distance(transform.position, Player.position) >= MinDist)
         {
           //ai chases player
           transform.position += transform.forward * MoveSpeed * Time.deltaTime;
         }
         else if (Vector3.Distance(transform.position, Player.position) >= MaxDist)
         {
           //do what ai does when its too far away
           Debug.Log("TOO FAR AWAY!!!!");
         }
         else if (Vector3.Distance(transform.position, Player.position) <= MinDist)
         {
           //attack
         }
     }
}
