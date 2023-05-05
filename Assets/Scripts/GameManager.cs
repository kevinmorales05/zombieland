using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0) 
        {
            round++;
            NextWave(round);
        }
    }
    public void NextWave(int round) 
    {
        for (var x = 0; x < round; x++){
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //spawn the enemy, create new one
            GameObject enemySpawned =  Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            //drag the game manager automatically
            enemySpawned.GetComponent<EnemyManager>().gameManager =  GetComponent<GameManager>();
            Debug.Log("Create a new Zombie");
            enemiesAlive++;
        }
       



    }
}
