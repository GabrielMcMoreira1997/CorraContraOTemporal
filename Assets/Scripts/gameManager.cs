using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    playerController player;
    groundMovement groundMovement;
    enemiesSpawn enemiesSpawn;
    obstaclesController _obstaclesController;
    public obstaclesController obstaclePrefab_1, obstaclePrefab_2;
    healthBarraController healthBarra;
    ScenaController scenaController;

    public GameObject txtRetry;

    Scene scene;

    float timeToIncreaseDifficulty = 0;
    float interval = 5f;
 
    void Start()
    {
        player = FindObjectOfType<playerController>();
        groundMovement = FindObjectOfType<groundMovement>();
        enemiesSpawn = FindObjectOfType<enemiesSpawn>();
        _obstaclesController = FindObjectOfType<obstaclesController>();
        healthBarra = FindObjectOfType<healthBarraController>();
        scenaController = FindObjectOfType<ScenaController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBoxAll(player.transform.position, Vector2.one * 0.3f, 0f, LayerMask.GetMask("Enemie")).Length > 0)
        {
            player.died = true;
            groundMovement.speed = 0;
            obstaclesController[] allEnemies = FindObjectsOfType<obstaclesController>();

            foreach (obstaclesController item in allEnemies)
            {
                item.speed = 0;
            }
        }

        if (player.died)
        {
            txtRetry.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (Time.time > timeToIncreaseDifficulty)
        {
            timeToIncreaseDifficulty = Time.time + interval;

            if(groundMovement.speed <= 7)
            {
                groundMovement.speed += 0.5f;
            }else if (groundMovement.speed <= 10)
            {
                groundMovement.speed += 0.65f;
            }else if (groundMovement.speed <= 13)
            {
                groundMovement.speed += 0.8f;
            }else if (groundMovement.speed <= 15)
            {
                groundMovement.speed += 0.9f;
            }else
            {
                groundMovement.speed += 1.1f;
            }


            obstaclesController[] allEnemies = FindObjectsOfType<obstaclesController>();

            foreach (obstaclesController item in allEnemies)
            {
                item.speed = groundMovement.speed;
            }

        }

        if(healthBarra.health <= 0)
        {
            scenaController.LoadFinalScene();
        }

    }
}
