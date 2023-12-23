using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    groundMovement groundMovement;
    GameObject txtRetry;

    // Start is called before the first frame update
    void Start()
    {
        groundMovement = FindObjectOfType<groundMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (groundMovement.speed == 0)
        {
            txtRetry.SetActive(true);
        }
    }
}
