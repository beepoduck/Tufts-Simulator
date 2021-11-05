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
     int MinDist = 1;
     bool attacking = false;
     bool canattack = true;




     void Start()
     {

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
         else if (canattack && !attacking && Vector3.Distance(transform.position, Player.position) <= MinDist)
         {
           StartCoroutine(ExpandHitbox());
           StartCoroutine(waitasecond());
         }
     }

     IEnumerator ExpandHitbox()
     {
       attacking = true;
       playerCollider = gameObject.GetComponent <CapsuleCollider>();
       playerCollider.radius += 5;
       yield return new WaitForFixedUpdate();
       playerCollider.radius -= 5;
       attacking = false;
     }

     IEnumerator waitasecond()
     {
       canattack = false;
       yield return new WaitForSeconds(1);
       canattack = true;
     }


}
