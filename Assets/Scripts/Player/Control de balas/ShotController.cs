using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * ------------- Esta clase se usa para disparar las balas --------
 * 
 */
public class ShotController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;

    public AudioSource audioFX;
    

    //se usa esta variable para el control de balas
    private bool wait;

    void Start()
    {
        wait = false;
        audioFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            if (!wait)
            {
                //instancia las balas cada vez que se da click izquierdo cada 3 segundos 
                
                Instantiate(Bullet, firePoint.position, firePoint.rotation);
                audioFX.Play();
                wait = true;
                StartCoroutine(shotTimer());
            }
            
        }
    }

    //corrutina usada para el control de balas
    IEnumerator shotTimer()
    {
        yield return new WaitForSeconds(0.2f);
        wait = false;
             
    }
}