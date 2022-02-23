using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueOrbsCounter : MonoBehaviour
{
    public GameObject stopWatch;

    private int counter;
    private int numberMaxOfOrbs;
    public TextMeshProUGUI txtCounter;
    // Start is called before the first frame update
    void Start()
    {
        stopWatch = GameObject.Find("StopWatch");
        counter = 0;
        numberMaxOfOrbs = 20;
        txtCounter.text = counter.ToString().PadLeft(2, '0') + "/" + numberMaxOfOrbs.ToString().PadLeft(2, '0');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseCounter ()
    {
        if (counter < numberMaxOfOrbs)
        {
            counter++;
            //Debug.Log(counter);
            txtCounter.text = counter.ToString().PadLeft(2, '0') + "/" + numberMaxOfOrbs.ToString().PadLeft(2, '0');
        }
        if(counter == numberMaxOfOrbs)
        {
            stopWatch.GetComponent<StopWatch>().gameOverWin();
        }
    }
}
