using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject changeSkinbutton;

    [SerializeField]
    private GameObject scrollviewbutton;

    private int totalScore;

    void Start()
    {
        changeSkinbutton.SetActive(true);
        startButton.SetActive(true);
        scrollviewbutton.SetActive(false);

        if (PlayerPrefs.HasKey("TotalScore"))
        {
            Debug.LogError("トータルスコアのデータがあるよ！");
        }
        else
        {
            Debug.LogError("トータルスコアのデータがないよ！");
            //ない場合名前を入力させる処理をここから入れる
        }
        if (PlayerPrefs.HasKey("GameScore"))
        {
            Debug.LogError("ゲームスコアのデータがあるよ！");
        }
        else
        {
            Debug.LogError("ゲームスコアのデータがないよ！");
            //ない場合名前を入力させる処理をここから入れる
        }
        //totalScoreを計算する
        //totalScoreの情報を取得する
        totalScore = PlayerPrefs.GetInt("TotalScore", totalScore);
        //totalScoreに前回のゲーム内のスコアを足す
        int gameScore = PlayerPrefs.GetInt("GameScore", 0);
        totalScore += gameScore;
        //保存する
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();
        Debug.LogError("totalScore = " + totalScore);
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Demo");
    }

    public void ActiveChangeSkinButton()//buttonが押されたらscrollviewを表示する
    {
        changeSkinbutton.SetActive(false);
        startButton.SetActive(true);
        scrollviewbutton.SetActive(true);
    }

    public void CloseChangeSkinButton() //buttonが押されたらscrollviewを非表示にする
    {
        changeSkinbutton.SetActive(true);
        startButton.SetActive(true);

        scrollviewbutton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StartScene");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
            Debug.LogError("セーブデータを全て削除した");
        }
    }

}
