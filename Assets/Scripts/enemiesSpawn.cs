using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawn : MonoBehaviour
{
    public obstaclesController[] spawn;

    float interval = 2;
    float instatiateTime = 0;
    float intervalVariation = 0.5f;

    groundMovement groundMovement;


    void Start()
    {
        groundMovement = FindObjectOfType<groundMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if(groundMovement.speed > 0)
        {
            Debug.Log("Speed: " + groundMovement.speed);
            if (Time.time >= instatiateTime)
            {
                int i = Random.Range(0, 2);
                spawn[i].speed = groundMovement.speed;

                if (groundMovement.speed >= 7 && groundMovement.speed <= 10)
                {
                    intervalVariation = 0.4f;
                }else if(groundMovement.speed > 10)
                {
                    interval = 1.5f;
                    intervalVariation = 0.35f;
                }

                obstaclesController obj = Instantiate(spawn[i], new Vector3(29, 0), Quaternion.identity);
                instatiateTime = Time.time + Random.Range(interval - intervalVariation, interval + intervalVariation);
            }
        }

    }
}
