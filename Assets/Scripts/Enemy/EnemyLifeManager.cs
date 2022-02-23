using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour
{
    public int life = 100;

    private Renderer myRenderer;
    public Color[] colors;

    public bool bullet = false;

    private void Start() 
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null )
        {
            bullet = true;
            life -= 20;
            StopAllCoroutines();
            StartCoroutine(damageEffect());
            if (life <= 0)
            {
                die();
            }
            bullet = false;
        }
    }

    IEnumerator damageEffect()
    {
        if (bullet)
        {
            myRenderer.material.color = colors[1];
            yield return new WaitForSeconds(0.15f);
            myRenderer.material.color = colors[0];
        }
    }

    private void die ()
    {
        Destroy(gameObject);
    }
}
