using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


 public class ai_mover : MonoBehaviour
 {

     public Transform Player;
     // public GameObject Playerref;
     public CapsuleCollider playerCollider;
     public CapsuleCollider physicsCollider;
     public int xp_to_give = 10;
     int MoveSpeed = 4;
     int MaxDist = 10;
     float MinDist = 2;
     bool attacking = false;
     bool canattack = true;
     bool canbeattacked = true;
     int ai_health = 10;
     // int player_xp;

     void Start()
     {

     }

     void Update()
     {
         //makes ai look at player from start
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
         }
         //if ai is close enough to player to attack them
         else if (canattack && !attacking && Vector3.Distance(transform.position, Player.position) <= MinDist)
         {
           StartCoroutine(ExpandHitbox());
           StartCoroutine(waittoattack());
         }
     }

     //this detects if the ai has collided with a weapon
     // (checks if the player punches this ai)
     private void OnTriggerEnter(Collider other)
     {
       if(canbeattacked && other.gameObject.tag == "Weapon")
       {
         ReduceHealth(other);
       }
     }

     //this function actually removes health from ai, then kills them if they have
     // no health by deleting them from the game
     void ReduceHealth(Collider other)
     {
       ai_health -= 5;
       if (ai_health <= 0)
       {
         // player_xp = Playerref.GetComponent <m_PlayerXP>();
         // player_xp += xp_to_give;
         Object.Destroy(this.gameObject);
       }
       StartCoroutine(waittobeattacked());
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

     //These 2 functions basically just makes the script wait 1 second before proceeding
     IEnumerator waittoattack()
     {
       canattack = false;
       yield return new WaitForSeconds(1);
       canattack = true;
     }

     IEnumerator waittobeattacked()
     {
       canbeattacked = false;
       yield return new WaitForSeconds(1);
       canbeattacked = true;
     }

}
