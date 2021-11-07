using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


 public class ai_mover : MonoBehaviour
 {

     public Transform Player;
     public CapsuleCollider playerCollider;
     public CapsuleCollider physicsCollider;
     int MoveSpeed = 4;
     int MaxDist = 10;
     float MinDist = 2;
     bool attacking = false;
     bool canattack = true;

     void Start()
     {

     }

     void Update()
     {
         transform.LookAt(Player);
         //if ai is close enough to player to notice player
         if (Vector3.Distance(transform.position, Player.position) <= MaxDist && Vector3.Distance(transform.position, Player.position) >= MinDist)
         {
           //ai chases player
           transform.position += transform.forward * MoveSpeed * Time.deltaTime;
         }
         //if ai is too far away from player to notice them
         else if (Vector3.Distance(transform.position, Player.position) >= MaxDist)
         {
           //do what ai does when its too far away
           //add script for idle ai activity here (stand still is ok, or add idle walking)
           Debug.Log("TOO FAR AWAY!!!!");
         }
         //if ai is close enough to player to attack them
         else if (canattack && !attacking && Vector3.Distance(transform.position, Player.position) <= MinDist)
         {
           StartCoroutine(ExpandHitbox());
           StartCoroutine(waitasecond());
         }
     }

     //The enemy will expand its hitbox for a frame so that it overlaps the player's hitbox
     //This causes the player to take damage (by function in firstpersoncontroller script)
     IEnumerator ExpandHitbox()
     {
       attacking = true;
       playerCollider = gameObject.GetComponent <CapsuleCollider>();
       playerCollider.radius += 2;
       yield return new WaitForFixedUpdate();
       playerCollider.radius -= 2;
       attacking = false;
     }

     //This function basically just makes the script wait 1 second before proceeding
     IEnumerator waitasecond()
     {
       canattack = false;
       yield return new WaitForSeconds(1);
       canattack = true;
     }

}
