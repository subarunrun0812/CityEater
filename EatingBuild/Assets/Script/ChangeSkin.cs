using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour//キャラのスキン変更について
{

    public GameObject[] _changeskin;

    private int totalScore;
    public static int changeNumber;//demoシーンで同期させるためにstatic修飾子を使う
    private int playerBestscore;


    void Awake()
    {
        changeNumber = PlayerPrefs.GetInt("ChangeNumber");//ロードする
        LoadSkin();


        playerBestscore = PlayerPrefs.GetInt("PlayerBestScore");//ロードする

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

    public void ChangeSkinButton0()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 0;
        _changeskin[0].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    public void ChangeSkinButton1()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 1;
        _changeskin[1].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    public void ChangeSkinButton2()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 2;
        _changeskin[2].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }


    //ここから、特定の条件を満たしたら使えるスキン達
    //BestScoreの条件を満たしたら使えるスキン達
    public void ChangeSkinButton3()//buttonを押したらスキンが変わっていく
    {
        if (playerBestscore >= 10000)//1万
        {
            Resetchangeskin();
            changeNumber = 3;
            _changeskin[3].SetActive(true);
            Debug.Log(changeNumber);
            SaveDate();
        }
    }
    public void ChangeSkinButton4()//buttonを押したらスキンが変わっていく
    {
        if (playerBestscore >= 50000)//5万
        {
            Resetchangeskin();
            changeNumber = 4;
            _changeskin[4].SetActive(true);
            Debug.Log(changeNumber);
            SaveDate();
        }
    }
    public void ChangeSkinButton5()//buttonを押したらスキンが変わっていく
    {
        if (playerBestscore >= 100000)//10万
        {
            Resetchangeskin();
            changeNumber = 5;
            _changeskin[5].SetActive(true);
            Debug.Log(changeNumber);
            SaveDate();
        }
    }

    //TotalScoreの条件を満たしたら使えるスキン達
    public void ChangeSkinButton6()
    {
        if (totalScore >= 100000)//10万
        {
            Resetchangeskin();
            changeNumber = 6;
            _changeskin[6].SetActive(true);
            Debug.Log(changeNumber);
            SaveDate();
        }
    }
    //TotalScoreの条件を満たしたら使えるスキン達
    public void ChangeSkinButton7()
    {
        if (totalScore >= 500000)//50万
        {
            Resetchangeskin();
            changeNumber = 7;
            _changeskin[7].SetActive(true);
            Debug.Log(changeNumber);
            SaveDate();
        }
    }
    public void ChangeSkinButton8()
    {
        if (totalScore >= 1000000)//100万
        {
            Resetchangeskin();
            changeNumber = 8;
            _changeskin[8].SetActive(true);
            Debug.Log(changeNumber);
            SaveDate();
        }
    }
    // public void ChangeSkinButton9()
    // {
    //     if (totalScore >= 1000000)//100万
    //     {
    //         Resetchangeskin();
    //         changeNumber = 9;
    //         _changeskin[9].SetActive(true);
    //         Debug.Log(changeNumber);
    //         SaveDate();
    //     }
    // }






    private void Resetchangeskin()//全ての着せ替えを非表示にする
    {
        for (int i = 0; i < _changeskin.Length; i++)
        {
            _changeskin[i].SetActive(false);
        }
    }
    private void LoadSkin()//スキンをロードする
    {
        for (int i = 0; i < _changeskin.Length; i++)
        {
            if (i == changeNumber)
            {
                _changeskin[i].SetActive(true);
            }
            else
            {
                _changeskin[i].SetActive(false);
            }
        }
    }

    public void SaveDate()//スキンを保存する
    {
        //変更したスキンの要素の順番をPlayerPrefsで記憶する
        PlayerPrefs.SetInt("ChangeNumber", changeNumber);
        PlayerPrefs.Save();
    }




    void Start()//初期は0番目のスキン
    {
        //ユ―ザーネームがあるかチェック
        if (PlayerPrefs.HasKey("ChangeNumber"))
        {
            Debug.Log("スキンの順番のデータがあるよ！");
        }
        else
        {
            Debug.Log("スキンの順番のデータがないよ！");
            //ない場合名前を入力させる処理をここから入れる
        }
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

    }



}
