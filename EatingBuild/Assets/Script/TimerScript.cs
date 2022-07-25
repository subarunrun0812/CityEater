using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    //timer作成
    [SerializeField] private int minute;
    [SerializeField] private float seconds;
    private float oldSeconds;//前のUpdateの時の秒数
    // [SerializeField] private Text timerText;//タイマー表示用テキスト



    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
    }

    void FixedUpdate()//時間延長になった時にタイマーを再開さしたいからfiexdUpdate関数を使っている

    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            minute++;
            seconds = seconds - 60;
        }
        //値が変わったときだけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            // timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");

        }
        oldSeconds = seconds;
    }

}
