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

    public GameObject playerCamera;

    private float shakeTime;
    private float shakeDuration;
    private Quaternion playerCameraOriginalPosition;

    private void Start()
    {
        playerCameraOriginalPosition = playerCamera.transform.localRotation;
    }
    private void Update() 
    {
       if(shakeTime < shakeDuration)
       {
            shakeTime += Time.deltaTime;
            CameraShake();
       }
       else if (playerCamera.transform.localRotation != playerCameraOriginalPosition) 
       {
            playerCamera.transform.localRotation = playerCameraOriginalPosition;
       }
        
    }

    public void Hit(float damage){
        health -= damage;
        healthText.text = "Health " + health.ToString();
        if(health <= 0) 
        {
            //SceneManager.LoadScene(0);
            gameManager.EndGame();
        }
        else
        {
            shakeTime = 0;
            shakeDuration = 0.2f;
        }
    }
    public void CameraShake()
    {
        playerCamera.transform.localRotation = Quaternion.Euler(Random.Range(-2,2), 0, 0);
    }

    
}
