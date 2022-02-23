using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChackPlatform : MonoBehaviour
{
    /*
   * esta variable se usa para indicar a otros scripts si el jugador esta en zona alta para ser
   * atacado con flechas
   */
    private bool onPlatform2 = false;
    private bool onPlatform1 = false;
    private bool onFloor = false;
    public int instanceID = -1;
    public int instancePlatformPlayer = 0;

    private GameObject[] ignoreBoundary;
    private GameObject[] ignorePlatform;
    public GameObject enemies;


    private void Start()
    {
        ignoreBoundary = GameObject.FindGameObjectsWithTag("CollisionIgnore");
        ignorePlatform = GameObject.FindGameObjectsWithTag("Platform1Enemy");
        for (int i = 0; i < ignoreBoundary.Length; i++)
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), ignoreBoundary[i].GetComponent<BoxCollider2D>(), true);
            if (ignorePlatform.Length > i)
            {
                Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), ignorePlatform[i].GetComponent<BoxCollider2D>(), true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform2"))
        {
           // Debug.Log("OnPlatform2");
            onPlatform2 = true;
            onPlatform1 = false;
            onFloor = false;
        }
        else if (collision.gameObject.CompareTag("Platform1Player"))
        {
            onPlatform1 = true;
            onPlatform2 = false;
            onFloor = false;
            instancePlatformPlayer = collision.gameObject.GetInstanceID();
        }
        else if (collision.gameObject.CompareTag("Floor"))
        {
         //   Debug.Log("Floor");
            onFloor = true;
            onPlatform1 = false;
            onPlatform2 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onPlatform1)
        {
            if (collision.gameObject.CompareTag("Platform1"))
            {
                onPlatform1 = false;
                onFloor = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform1") || collision.gameObject.CompareTag("Floor"))
        {
            instanceID = collision.gameObject.GetInstanceID();
        }
    }

    public int GetPlatformInstanceID()
    {
        return instanceID;
    }

    public bool getOnPlatform2()
    {
        return onPlatform2;
    }

    public bool getOnPlatform1()
    {
        return onPlatform1;
    }

    public bool GetOnFloor()
    {
        return onFloor;
    }

    public int getInstancePlatformPlayer()
    {
        return instancePlatformPlayer;
    }

    public void SetActiveFalseEnemies()
    {
        enemies.SetActive(false);
        foreach (Transform child in enemies.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

}