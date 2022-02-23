using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * --------- Esta clase se encarga del movimiento de la bala cuando es disparada ---------
 * 
 */
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
 
    private float speed = 20;
    
    Vector3 currentPosition;
    //Variable en la que se guarda la posicion del mouse------
    Vector3 target;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
        
        //busca la posicion (coordenadas) del click respecto a la camara-----
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //rectificamos la posicion en z ----
        target.z = 0f; 
    }
    private void Start()
    {
        newAxis();
    }

    void Update()
    {
        //movemos el objeto desde transform.position hasta targen (mouse) -----
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //se destruye el objeto despues de 2 segundos ----
        Destroy(gameObject, 2f);
    }

    /*
     * calcula las nuevas coordenadas de la bala para hacer que la bala siga derecho y no pare en la posicion
     * del mouse.
     */
    public void newAxis()
    {
        /*
        **usando formula de la recta-----
        **/
        int newXAxis;

        /*se define la pendiente de la recta m = (y2 - y1)/(x2 - x1), con ella, se puede encontrar
        * otra coordenada en la misma direccion usando una coodenada x cualquiera ------
        */
        float m = (target.y - currentPosition.y) / (target.x - currentPosition.x);

        // si el click esta a la izquierda del personaje, se usara una posicion x negativa ----
            if (target.x < currentPosition.x)
            {
                newXAxis = -100;
            }
            else
            {
                newXAxis = 100;
            }

        // se encuentra la coordenada y usando la formula de la recta y = m (x - x1) + y1
        target.y = m * (newXAxis - target.x) + target.y;
        target.x = newXAxis;
    }

    // Si toca un enemigo se destruye ---------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}