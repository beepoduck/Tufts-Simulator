using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyManager : MonoBehaviour
{

    public Transform[] m_SpawnPoints;
    public GameObject enemyai;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
    }

    void OnEnable()
    {
        EnemyController.OnEnemyKilled += SpawnNewEnemy;
    }


    void SpawnNewEnemy() {

        int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoints.Length-1));

        Instantiate(enemyai, m_SpawnPoints[randomNumber].transform.position, Quaternion.identity);


    }

}