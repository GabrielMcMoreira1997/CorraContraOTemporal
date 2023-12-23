using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class playerController : MonoBehaviour
{

    float maxHeight = 3.0f;
    float timeToPeak = 0.4f;

    float jumpSpeed;
    float gravity;
    float tempoRestante;

    bool isGrounded = false;

    Vector2 yVelocity;

    float groundPosition;

    public bool died;

    groundMovement groundMovement;
    enemiesSpawn enemiesSpawn;
    Animator animator;
    healthBarraController healthBarra;
    DustController dustController;

    AudioSource jumpSound;

    private void Start()
    {
        died = false;
        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);
        jumpSpeed = gravity * timeToPeak;

        groundPosition = transform.position.y;

        groundMovement = FindObjectOfType<groundMovement>();
        enemiesSpawn = FindObjectOfType<enemiesSpawn>();
        healthBarra = FindObjectOfType<healthBarraController>();
        dustController = FindObjectOfType<DustController>();

        animator = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();

        tempoRestante = healthBarra.health;
    }

    private void Update()
    {
        dustController.setVisibilidade(true);
        yVelocity += gravity * Time.deltaTime * Vector2.down;

        if (transform.position.y <= groundPosition)
        {
            transform.position = new Vector3(transform.position.x, groundPosition, transform.position.z);
            yVelocity = Vector3.zero;
            isGrounded = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yVelocity = jumpSpeed * Vector2.up;
            isGrounded = false;

            jumpSound.Play();
        }

        transform.position += (Vector3)yVelocity * Time.deltaTime;

        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;
            healthBarra.health = tempoRestante;
        }

        if (died)
        {
            animator.SetBool("morreu", died);

            StartCoroutine(setMorte(0.3f));
        }

        if(transform.position.y > groundPosition) 
        {
            dustController.setVisibilidade(false);
        }
    }

    private IEnumerator setMorte(float sec)
    {
        yield return new WaitForSeconds(sec);        
        gameObject.SetActive(false);
        dustController.setVisibilidade(false);
    }

}
