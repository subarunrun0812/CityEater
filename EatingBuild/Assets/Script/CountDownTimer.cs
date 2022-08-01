using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] public AudioClip bgm;
    [SerializeField] AudioSource audioSource;

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
    [SerializeField] private GameObject indicators;
    [SerializeField] private GameObject lvUI;
    private int totalCount;//プレイした合計の回数
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
        indicators.SetActive(true);
        lvUI.SetActive(true);

        //bgmを再生
        audioSource.PlayOneShot(bgm);
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

        oldSeconds = seconds;
        //制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (totalTime <= 0f)
        {
            Time.timeScale = 0;
            seconds += 0.5f;//時間を追加しないとボタンが非表示にならないため、必要
            threeSeconds.text = "";
            ItemsText.SetActive(false);
            indicators.SetActive(false);
            //Continueを一度もしていない場合
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
