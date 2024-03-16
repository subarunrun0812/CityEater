using UnityEngine;
using TMPro;
public class Ready3seconds : MonoBehaviour
{
    //トータル制限時間
    private float totalTime;


    //制限時間（秒）
    [SerializeField]
    private float seconds = 3.9f;
    //前回Update時の秒数
    private float oldSeconds;
    [SerializeField]
    private TextMeshProUGUI timerText;


    [SerializeField]
    private GameObject joystick;//操作をできないようにする

    void Start()
    {
        totalTime = seconds;
        oldSeconds = 0f;
        joystick.SetActive(false);

    }
    void Update()
    {

        //一旦トータルの制限時間を計測；
        totalTime = seconds;
        totalTime -= Time.deltaTime;

        //再設定

        seconds = totalTime;


        //タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = ((int)seconds).ToString("0");
        }
        oldSeconds = seconds;
        //制限時間以下になったらゲームをスタートする
        if (totalTime <= 1.0f && totalTime < 0f)
        {
            joystick.SetActive(true);
            timerText.text = "Start";
        }
        if (totalTime <= 0.0f)
        {
            timerText.text = "";
        }
    }
}
