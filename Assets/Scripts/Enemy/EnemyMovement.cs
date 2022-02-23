using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rbEnemy;

    private GameObject player, checkBottomPlayer;
    private Transform playerTransform;
    private ChackPlatform playerMovement;
    private Animator anim;

    private Attack attackScript;
    private AirAttack airAttackScript;

    private bool leftMovement, rightMovement, attack, airAttack,standbyMode, onFloor;
    private int  velocity;
    private float distanceToPlayer, bound;
    private int instanceIDPlatform;

    private bool positionOnFloor, positionOnPlatform1, positionOnPlatform2;


    private void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        airAttackScript = GetComponent<AirAttack>();
        attackScript = GetComponent<Attack>();

        checkBottomPlayer = GameObject.Find("bottomCheck");
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<ChackPlatform>();
        playerTransform = player.GetComponent<Transform>();

        leftMovement = false;
        rightMovement = false;
        attack = false;
        airAttack = false;
        onFloor = false;

        positionOnFloor = false;
        positionOnPlatform1 = false;
        positionOnPlatform2 = false;

        standbyMode = true;

        instanceIDPlatform = 0;
        distanceToPlayer = 5;
        bound = 2.2f;
        velocity = 5;

        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>(), true);
        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), checkBottomPlayer.GetComponent<BoxCollider2D>(), true);
    }

    private void CheckAirAttack ()
    {
        if (playerMovement.getOnPlatform2() && !positionOnFloor)
        {
            airAttack = true;
            airAttackScript.StartAirAttack();

        }
        else
        {
            airAttack = false;
        }
    }

    private void SetDistanceToPlayer()
    {
        distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        //Debug.Log(distanceToPlayer + "Distance mode 2: " + (player.transform.position.x - gameObject.transform.position.x));
    }

    private void MovementManager()
    {
        if (!airAttack)
        {
            CheckPlatformPlayer();
            if (distanceToPlayer > bound)
            {
                if (!standbyMode)
                {
                    SetSenseRespectToPlayer();
                }
                Movement();
                anim.SetBool("Walking", true);
                anim.SetBool("Attack", false);
            }
            else
            {
                attack = true;
                attackScript.StartAttack();
            } 
        }
    }

    private void SetSenseRespectToPlayer()
    {   
        if (transform.position.x < playerTransform.position.x)
        {
            if (velocity < 0)
            {
                velocity *= -1;
            }
        }
        else if (transform.position.x > playerTransform.position.x)
        {
            if (velocity > 0)
            {
                velocity *= -1;
            }
        }
    }

    private void FlipSense ()
    {
        velocity *= -1;
    }

    private void Movement()
    {
        rbEnemy.velocity = new Vector2(velocity, rbEnemy.velocity.y);
        if (velocity < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundaries") || collision.gameObject.CompareTag("CollisionIgnore"))
        {
            if (standbyMode)
            {
                FlipSense();
            }
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Platform1"))
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            positionOnFloor = true;
        }
        if (collision.gameObject.CompareTag("Platform1Enemy"))
        {
            positionOnPlatform1 = true;
        }
        if (collision.gameObject.CompareTag("Platform2"))
        {
            positionOnPlatform2 = true;
        }
        
    }

    private void CheckPlatformPlayer()
    {
        if (positionOnFloor)
        {
            if (playerMovement.GetOnFloor())
            {
                standbyMode = false;
                SetDistanceToPlayer();
            }
            else
            {
                distanceToPlayer = 5;
                standbyMode = true;
            }
        }
        else if (positionOnPlatform1)
        {
          /*  Debug.Log("instancia del jugador: " + playerMovement.GetPlatformInstanceID() +
                "Instancia del enemigo: " + instanceIDPlatform);*/
            if (playerMovement.getOnPlatform1() && instanceIDPlatform.Equals(playerMovement.GetPlatformInstanceID()))
            {
                standbyMode = false;
                SetDistanceToPlayer();
            }
            else
            {
                distanceToPlayer = 5;
                standbyMode = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform1") || collision.gameObject.CompareTag("Floor"))
        {
            instanceIDPlatform = collision.gameObject.GetInstanceID();
        }
    }

    private void FixedUpdate()
    {
        CheckAirAttack();
        MovementManager();
    }
}