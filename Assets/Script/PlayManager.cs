using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject GameoverCanvas;
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text failedText;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;

    GravityController gravityController;
    public float time;
    float counter;
    public bool timeActive = true;

    private void OnEnable()
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);
        playerWinEvent.OnInvoked.AddListener(PlayerWin);
    }

    private void OnDisable()
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);
        playerWinEvent.OnInvoked.RemoveListener(PlayerWin);
    }

    private void Update() {
        if (timeActive)
        {
            counter += Time.deltaTime;
            if(counter >= 1)
            {
                time--;
                counter = 0;
            }
        }

        if (timeActive && time <= 0)
        {
            GameOver();
            timeActive = false;
        }


        setText();
    }

    // int coin = 100; //TODO

    public void GameOver()
    {
        failedText.text = "You Failed";
        GameoverCanvas.SetActive(true);
        timeActive = false;
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win!!!";
        finishedCanvas.SetActive(true);
        timeActive = false;
        gravityController.SetActive(false);
    }

    public void setText()
    {
        int minute = Mathf.FloorToInt(time / 60);
        int second = Mathf.FloorToInt(time % 60);

        timerText.text = minute.ToString("00") + ":" + second.ToString("00");
    }
}