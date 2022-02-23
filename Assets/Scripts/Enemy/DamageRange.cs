using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRange : MonoBehaviour
{
    private BoxCollider2D coll;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }
    
}
