using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesController : MonoBehaviour
{
    public float speed = 6;

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x <= -23)
        {
            Destroy(gameObject);
        }
    }
}
