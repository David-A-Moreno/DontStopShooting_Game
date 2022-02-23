using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * --- Esta clase se usa para hacer el efecto de caer al oprimir "s" cuando se esta en una plataforma. ---
 * 
 */
public class PlatformEffectorDown : MonoBehaviour
{
    PlatformEffector2D pf;
    public bool leftPlatform;
    public bool inCollision;

    public GameObject player;
    public ChackPlatform playerScript;

    private void Start()
    {
        pf = GetComponent<PlatformEffector2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<ChackPlatform>();
    }

    private void FixedUpdate()
    {
        // si se presiona la tecla "s" y esta sobre una plataforma gira el platformEffector 180 grados -----
        if ((Input.GetKey("down") || Input.GetKey("s")))
        {
            if (inCollision)
            {
                if (playerScript.getInstancePlatformPlayer() == this.gameObject.GetInstanceID())
                {
                    pf.rotationalOffset = 180;
                }
            }
        }
        else if (Input.GetKey("space"))
        {
        // si oprime la tecla "space" los platformsEfector vuelven a su posicion normal
        
            pf.rotationalOffset = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inCollision = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform1Player"))
        {
            inCollision = false;
        }
    }
}
