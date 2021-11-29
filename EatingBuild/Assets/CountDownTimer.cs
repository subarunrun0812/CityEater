using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDownTimer : MonoBehaviour
{
    //トータル制限時間
    private float totalTime;
    //制限時間（分）
    [SerializeField]
    private int minute;
    //制限時間（秒）
    [SerializeField]
    private float seconds;
    //前回Update時の秒数
    private float oldSeconds;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private GameObject notime;

    [SerializeField] private GameObject result;//resule画面を表示するオブジェクト


    void Start()
    {
        Time.timeScale = 1;
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
        notime.SetActive(false);
    }

    public void ContinueButtonInvoke()
    {
        Time.timeScale = 1;
        seconds += 30;//30秒追加
        notime.SetActive(false);
        Debug.Log("ContinueButtonが押された");
    }
    public void QuitButton()//quitボタンを押したら、Result画面を表示する
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    void Update()
    {

        //一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;

        //再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        //制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (totalTime <= 0f)
        {
            Time.timeScale = 0;
            notime.SetActive(true);
        }
    }
}
