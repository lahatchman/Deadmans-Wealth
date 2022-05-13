using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializingEnemies : MonoBehaviour
{
    [SerializeField] private GameObject human, fox, chicken;
    private GameObject[] enemySpawnPoints;
    private int randomEnemyAmount, typeOfEnemy;

    void Awake()
    {
        enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        randomEnemyAmount = Random.Range(1, enemySpawnPoints.Length);
        for (int i = 0; i < randomEnemyAmount; i++)
        {
            typeOfEnemy = Random.Range(1, 6);
            if (typeOfEnemy <= 1) { Instantiate(human, enemySpawnPoints[i].transform.position, enemySpawnPoints[i].transform.rotation); }
            else if (typeOfEnemy == 2 || typeOfEnemy == 3) { Instantiate(fox, enemySpawnPoints[i].transform.position, enemySpawnPoints[i].transform.rotation); }
            else { Instantiate(chicken, enemySpawnPoints[i].transform.position, enemySpawnPoints[i].transform.rotation); }
        }
    }
}
