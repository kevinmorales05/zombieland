using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerManager : MonoBehaviour
{
    public float health = 100;

    public Text healthText;
    // Start is called before the first frame update

    public GameManager gameManager;

    public void Hit(float damage){
        health -= damage;
        healthText.text = "Health " + health.ToString();
        if(health <= 0) 
        {
            //SceneManager.LoadScene(0);
            gameManager.EndGame();
        }
    }

    
}
