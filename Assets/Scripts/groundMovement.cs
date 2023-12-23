using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundMovement : MonoBehaviour
{

    public GameObject[] grounds;

    public float speed = 6;

    Vector2 endPosition = new Vector2 (-23, 0);
    Vector2 startPosition = new Vector2(18, 0);

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < grounds.Length; i++)
        {
            grounds[i].transform.position += Vector3.left * speed * Time.deltaTime;

            if (grounds[i].transform.position.x <= endPosition.x)
            {
                grounds[i].transform.position = startPosition;
            }
        }
        
    }
}
