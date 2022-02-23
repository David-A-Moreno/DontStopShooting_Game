using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * --------- Esta clase se usa para comprobar si el personaje esta parado sobre algo --------
 * 
 */
public class CheckBottom : MonoBehaviour
{
    public static bool isGrounded;
    private GameObject[] ignorePlatform;
    private GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        ignorePlatform = GameObject.FindGameObjectsWithTag("Platform1Enemy");
        for (int i = 0; i < ignorePlatform.Length; i++)
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), ignorePlatform[i].GetComponent<BoxCollider2D>(), true);
        }
        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), enemy.GetComponent<BoxCollider2D>(), true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform1") || collision.CompareTag("Platform2") || collision.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform1") || collision.CompareTag("Platform2") || collision.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}