using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3[] respawnPosition = { new Vector3(-6.6f,3.1f,0),  new Vector3(6.6f,3.1f,0),
                                          new Vector3(-7.5f,0.07f,0), new Vector3(6.7f,0.07f,0),
                                          new Vector3(-7.1f,-2.8f,0), new Vector3(5.9f,-2.8f,0)};
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < respawnPosition.Length; i++)
        {
            Instantiate(enemy, respawnPosition[i], transform.rotation, this.transform);
            
        }
        StartCoroutine(spawnEnemy());
    }
}
