using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{
    private float time;
    private float timeCounter = 0;
    private int sec;
    private int secCounter;

    private bool finishedGame = false;

    public TextMeshProUGUI txtTimer;
    public GameObject enemies;

    public GameObject player;
    public Movement playerScript;

    public GameObject bgGameOverLose;
    public GameObject bgGameOverWin;
    public TextMeshProUGUI txtFinalTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Movement>();
        time = 59;
        txtTimer.text = "00:00";

        bgGameOverLose = GameObject.Find("GameOverPanelLose");
        bgGameOverLose.SetActive(false);
        bgGameOverWin = GameObject.Find("GameOverPanelWin");
        bgGameOverWin.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            calculateTime();
        }
        
    }

    private void calculateTime()
    {
        if (!playerScript.getDie() && !finishedGame)
        {
            time -= Time.deltaTime;
            timeCounter += Time.deltaTime;
            sec = (int)time % 60;
            txtTimer.text = "00:" + sec.ToString().PadLeft(2, '0');
            if (sec == 0)
            {
                gameOverLose();
            }
        }
    }

    public void gameOver()
    {
        player.SetActive(false);
        enemies.SetActive(false);
        foreach (Transform child in enemies.transform)
        {
            child.gameObject.SetActive(false);
        }
        txtTimer.text = "00:00";
    }

    public void gameOverLose()
    {
        bgGameOverLose.SetActive(true);
        gameOver();
    }

    public void gameOverWin()
    {
        finishedGame = true;
        bgGameOverWin.SetActive(true);
        secCounter = (int)timeCounter % 60;
        txtFinalTime.text = "TIME 00:" + secCounter.ToString().PadLeft(2, '0');
        gameOver();
    }
}
