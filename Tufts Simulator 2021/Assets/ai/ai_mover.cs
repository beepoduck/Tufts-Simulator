using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


 public class ai_mover : MonoBehaviour
 {
     public Transform Player;
     public Collider playerCollider;
     public Collider physicsCollider;
     public int xp_to_give = 10;
     public float ai_health = 20;
     public int ai_damage = 5;
     //for non bosses this should be 1
     public int ai_attackSpeed = 1;
     public bool is_boss;
     //for non bosses this should be 10
     public int MaxDist = 10;
     //for non bosses this should be 2
     public float MinDist = 2;
     public Text defeated_text;
     int MoveSpeed = 4;
     bool attacking = false;
     bool canattack = true;
     private int player_xp;
     private float player_damage;

     public HealthBar2 healthBar;

     void Start()
     {
      // set health bar max
      healthBar.SetMaxHealth(ai_health);
      
      Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
      // playerCollider = gameObject.GetComponent<Collider>();
      // physicsCollider = gameObject.GetComponentInChildren<Collider>();
      playerCollider.enabled = true;
     }

     void Update()
     {
         Debug.Log("Transform:" + Player);
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
           FindObjectOfType<FirstPersonController>().DamagePlayer(ai_damage);
           StartCoroutine(waittoattack());
         }
     }

     //this detects if the ai has collided with a weapon
     // (checks if the player punches this ai)
     private void OnTriggerEnter(Collider other)
     {
       if(other.gameObject.tag == "Weapon")
       {
         player_damage = CalculateDamage();
         ReduceHealth(other);
       }
     }

     //This function calculates how much damage the player should do per hit
     // based on their level / XP
     float CalculateDamage()
     {
       player_xp = FindObjectOfType<FirstPersonController>().GetXP();
       return (5 + (player_xp / 10));

     }

     //this function actually removes health from ai, then kills them if they have
     // no health by deleting them from the game
     void ReduceHealth(Collider other)
     {
       ai_health -= player_damage;
       // update health
       healthBar.SetHealth(ai_health);
       if (ai_health <= 0)
       {
         //if the ai dies, it gives xp to the player
        FindObjectOfType<FirstPersonController>().addXP(xp_to_give);
         //if the ai was a boss enemy, we display info
         if(is_boss)
         {
           defeated_text.text = $"You Defeated This Boss and Were Rewarded {xp_to_give} XP!";
           FindObjectOfType<FirstPersonController>().SetBossesDefeated();
           StartCoroutine(DisplayDefeatedText());
           //insert some function we'll call when a boss dies
           // (win screen? add to quest completion? ...)
         } else {
           //if it's not a boss enemy, we'll just respawn it.
           FindObjectOfType<EnemyManager>().SpawnNewEnemy();
           Object.Destroy(this.gameObject);
         }
        }
     }

     //These 2 functions basically just makes the script wait 1 second before proceeding
     IEnumerator waittoattack()
     {
       canattack = false;
       yield return new WaitForSeconds(ai_attackSpeed);
       canattack = true;
     }

     IEnumerator DisplayDefeatedText()
     {
       //displays winning text on player's screen
       defeated_text.enabled = true;
       //temporarily moves the enemy to reeeeeeeallly far away
       // (can't just delete the enemy yet because there's more script to run)
       transform.position = new Vector3(-999999, -9999999, -99999);
       //keeps winning text on screen for 3 seconds
       yield return new WaitForSeconds(3);
       //gets rid of winning text
       defeated_text.enabled = false;
       //destroys this object once there's no more code to run
       Object.Destroy(this.gameObject);
     }
}
