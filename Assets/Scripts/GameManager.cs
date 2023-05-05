using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    //UI elements
    public Text roundNumber;

    public GameObject endScreen;

    public Text roundSurvived;


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
            roundNumber.text = "Round: " + round.ToString();
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

    public void Restart()
    {
        Time.timeScale = 1; //if not the game frozen
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState =  CursorLockMode.None;
        endScreen.SetActive(true);
        roundSurvived.text = round.ToString();
    }
}
