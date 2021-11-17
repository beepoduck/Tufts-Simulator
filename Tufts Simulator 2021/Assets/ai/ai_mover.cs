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
     public int xp_to_give = 10;
     int MoveSpeed = 4;
     int MaxDist = 10;
     float MinDist = 2;
     bool attacking = false;
     bool canattack = true;
     int ai_health = 10;
     
     public HealthBar2 healthBar;

     void Start()
     {
       playerCollider = gameObject.GetComponent <CapsuleCollider>();
       playerCollider.enabled = true;
       
       healthBar.SetMaxHealth(ai_health);
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
           FindObjectOfType<FirstPersonController>().DamagePlayer(1);
           StartCoroutine(waittoattack());
         }
     }

     //this detects if the ai has collided with a weapon
     // (checks if the player punches this ai)
     private void OnTriggerEnter(Collider other)
     {
       if(other.gameObject.tag == "Weapon")
       {
         ReduceHealth(other);
       }
     }

     //this function actually removes health from ai, then kills them if they have
     // no health by deleting them from the game
     void ReduceHealth(Collider other)
     {
       ai_health -= 5;
       healthBar.SetHealth(ai_health);
       if (ai_health <= 0)
       {
         //if the ai dies, it gives xp to the player, and deletes itself
         FindObjectOfType<FirstPersonController>().addXP(10);
         Object.Destroy(this.gameObject);
       }
     }

     //These 2 functions basically just makes the script wait 1 second before proceeding
     IEnumerator waittoattack()
     {
       canattack = false;
       yield return new WaitForSeconds(1);
       canattack = true;
     }
}
