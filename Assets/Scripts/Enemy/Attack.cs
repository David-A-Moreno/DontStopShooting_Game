using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public GameObject rangeDamage;
    private BoxCollider2D rangeCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rangeDamage = transform.GetChild(0).gameObject;
        rangeCollider = rangeDamage.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAttack()
    {
        anim.SetBool("Attack", true);
        anim.SetBool("Walking", false);
    }

    public void trueCollider()
    {
        rangeCollider.enabled = true;
    }

    public void falseCollider()
    {
        rangeCollider.enabled = false;
    }

}
