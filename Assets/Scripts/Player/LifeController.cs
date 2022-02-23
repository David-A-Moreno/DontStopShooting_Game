using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public Image lifeBar;
    public float currentLife = 400;
    public float maxLife = 400;
    private Animator anim;
    private Movement playerMovement;

    private Renderer myRenderer;
    public Color[] colors;

    private bool damage = false;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        playerMovement = GetComponentInParent<Movement>();
        myRenderer = GetComponentInParent<Renderer>();
    }

    void Update()
    {
        lifeBar.fillAmount = currentLife / maxLife;    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Rango"))
        {
            damage = true;
            currentLife -= 5;
            StopAllCoroutines();
            StartCoroutine(damageEffect());
            damage = false;
        }
        if (currentLife == 0)
        {
            playerMovement.setZeroVelocity();
            anim.SetBool("Die", true);
        }
    }

    IEnumerator damageEffect()
    {
        if (damage)
        {
            myRenderer.material.color = colors[1];
            yield return new WaitForSeconds(0.15f);
            myRenderer.material.color = colors[0];
        }
    }
}