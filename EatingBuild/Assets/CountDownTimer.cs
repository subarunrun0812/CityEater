using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CountDownTimer : MonoBehaviour
{
    //トータル制限時間
    [SerializeField] private float totalTime;
    //制限時間（分）
    [SerializeField] private int minute;
    //制限時間（秒）
    public float seconds;
    //前回Update時の秒数
    private float oldSeconds;

    [SerializeField] private GameObject Items;

    [SerializeField] private Text timerText;

    [SerializeField] private GameObject notime;
    [SerializeField] private GameObject continue_b;
    [SerializeField] private GameObject quit_b;

    [SerializeField] private GameObject revenge;//死んだ時に表示するボタンの親オブジェクト

    [SerializeField] private GameObject highScoreTable;
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI threeSeconds;//３秒前
    [SerializeField] private GameObject ItemsText;
    [SerializeField] private GameObject lvUI;
    private int totalCount;//プレイした合計の回数


    // [SerializeField] private GameObject banner;//google banner

    private bool flag = true;//continueを1回しか出来ないようにする
    void Start()
    {
        Time.timeScale = 1;
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
        scoreUI.SetActive(true);
        highScoreTable.SetActive(false);
        notime.SetActive(false);
        continue_b.SetActive(true);
        quit_b.SetActive(true);
        revenge.SetActive(false);
        ItemsText.SetActive(true);
        lvUI.SetActive(true);
        // banner.SetActive(false);
    }

    public void ContinueButtonInvoke()
    {
        notime.SetActive(false);
        revenge.SetActive(false);
        Time.timeScale = 1;
        if (_player.activeSelf == true)
        {
            flag = false;
        }

        // else if (_player.activeSelf == false)//playerが死んだ時に復活するとき
        // {
        //     seconds += 30;//30秒追加.この仕組みを使ったら、対戦時間を永延とプレイしてもらえる→広告をたくさん見てもらえる。
        //     gameManager.AddPoint(gameManager.point * 2);
        //     _player.SetActive(true);
        // }
    }
    public void QuitButton()//quitボタンを押したら、Result画面を表示する
    {
        notime.SetActive(false);
        revenge.SetActive(false);
        scoreUI.SetActive(false);
        highScoreTable.SetActive(true);
        Time.timeScale = 0;
        lvUI.SetActive(false);

        //合計プレイ回数を増やす
        totalCount = PlayerPrefs.GetInt("TotalCount", totalCount);
        totalCount += 1;
        PlayerPrefs.SetInt("TotalCount", totalCount);
        PlayerPrefs.Save();
        Debug.LogError("TotalCount = " + totalCount);
        // banner.SetActive(true);
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
        if (totalTime <= 4f)
        {
            if ((int)seconds != (int)oldSeconds)
            {
                threeSeconds.text = ((int)seconds).ToString("0");
            }
        }


        if (totalTime <= 45f)
        {
            Items.SetActive(true);
        }

        oldSeconds = seconds;
        //制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (totalTime <= 0f)
        {
            Time.timeScale = 0;
            seconds += 1f;//これがなかったらQuitボタンが非表示にならないため、必要
            threeSeconds.text = "";
            ItemsText.SetActive(false);
            if (flag == true)
            {
                //timerが0になった時に表示する
                notime.gameObject.SetActive(true);
            }
            else
            {
                continue_b.SetActive(false);
                notime.gameObject.SetActive(true);
            }
        }
    }
}
