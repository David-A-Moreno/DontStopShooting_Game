using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrbs : MonoBehaviour
{
    private int orbsCounter;
    public GameObject blueOrbsCounter;
    private Vector3[] vectorArray = { new Vector3(-7.5f,3.42f,0),  new Vector3(-5.6f,2.9f,0),
                                  new Vector3(-3.69f,3.56f,0), new Vector3(-0.79f,3.7f,0),
                                  new Vector3(0.94f,2.94f,0),  new Vector3(2.65f,4.17f,0),
                                  new Vector3(4.11f,2.97f,0),  new Vector3(5.32f,3.95f,0),
                                  new Vector3(6.75f, 2.9f, 0), new Vector3(7.8f, 3.91f, 0),
                                  new Vector3(-7.6f,0.2f,0),   new Vector3(-6.6f,-0.27f,0),
                                  new Vector3(-4.7f,-0.2f,0),  new Vector3(-3.47f,0.9f,0),
                                  new Vector3(-0.6f,0.9f,0),   new Vector3(0.9f,0.47f,0),
                                  new Vector3(2.9f,-0.2f,0),   new Vector3(4.28f,-0.28f,0),
                                  new Vector3(5.3f,0.75f,0),   new Vector3(7.38f,0.14f,0),
                                  new Vector3(-7.1f,-3.2f,0),  new Vector3(-5.94f,-2.32f,0),
                                  new Vector3(-4.4f,-2.05f,0), new Vector3(-2.64f,-2.63f,0),
                                  new Vector3(-0.6f,-3.3f,0),  new Vector3(1.03f,-2.85f,0),
                                  new Vector3(2.94f,-2.25f,0), new Vector3(4,-3.27f,0),
                                  new Vector3(5.17f,-3.61f,0), new Vector3(7.11f,-2.85f,0)};

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = vectorArray[VectorRandom()];
        orbsCounter = 0;
    }

    private int VectorRandom()
    {
        int random = Random.Range(0, vectorArray.Length);
        return random;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.parent.CompareTag("Player"))
        {
            this.transform.position = vectorArray[VectorRandom()];
            orbsCounter++;
            blueOrbsCounter.gameObject.GetComponent<BlueOrbsCounter>().increaseCounter();
        }
    }

    public int getOrbsCounter()
    {
        return orbsCounter;
    }
}