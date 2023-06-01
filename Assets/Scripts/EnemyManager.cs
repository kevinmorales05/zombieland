using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;

    public Animator enemyAnimator;

    public float damage = 20f;

    public float health = 100f;

    public GameManager gameManager;

    //logic for the zombies health bar
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //initial health bar
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //slider points to the player
        slider.transform.LookAt(player.transform);
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else 
        {
            enemyAnimator.SetBool("isRunning", false);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        {
            if (collision.gameObject == player)
            {
                Debug.Log("Player hit!");
                player.GetComponent<PlayerManager>().Hit(damage);
            }
        }
    }

    public void Hit(float damageInflicted){
         health -= damageInflicted;
         slider.value = health;
        if(health <= 0) 
        {
            //decrease the number of enemies alive
            gameManager.enemiesAlive--;
            //Destroy the enemy
            Destroy(gameObject);
        }
    }

}
