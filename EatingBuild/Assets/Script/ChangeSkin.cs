using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class ChangeSkin : MonoBehaviour
{

    public GameObject[] _changeskin;
    public GameObject[] Lockskin;//まだ、条件を達成できていないスキンは上から画像を貼り、選べなくする。

    [SerializeField] private TextMeshProUGUI bestscoreText;
    private int totalScore;
    public static int changeNumber;//demoシーンで同期させるためにstatic修飾子を使う
    private int playerBestscore;
    //合計プレイ回数を増やす
    private int totalCount;

    public int unLockSkin0 = 10000;//1万
    public int unLockSkin1 = 50000;//5万
    public int unLockSkin2 = 100000;//10万
    public int unLockToal_Skin3 = 1000000;//100万
    public int unLockTotal_Skin4 = 5000000;//500万
    public int unLockTotal_Skin5 = 10000000;//1000万
    public int TotalCount_skin1;//
    public int TotalCount_skin2;//
    public int TotalCount_skin3;//

    void Awake()
    {
        changeNumber = PlayerPrefs.GetInt("ChangeNumber");//ロードする
        LoadSkin();
        playerBestscore = PlayerPrefs.GetInt("PlayerBestScore");//ロードする

        //totalScoreの情報を取得する
        totalScore = PlayerPrefs.GetInt("TotalScore", totalScore);
        //totalScoreに前回のゲーム内のスコアを足す
        int gameScore = PlayerPrefs.GetInt("GameScore", 0);

        //int型の最大値を超えなさそうだったら、合計ポイントを追加する
        if (totalScore + gameScore < 2000000000)//2147483647
        {
            totalScore += gameScore;
        }
        else
        {
            Debug.LogError(totalScore + "が2000000000を超えた");
        }
        //保存する
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();
        Debug.LogError("totalScore = " + totalScore);
        bestscoreText.text = "Best: " + playerBestscore + "P";

        //プレイした合計回数の処理
        totalCount = PlayerPrefs.GetInt("TotalCount");
    }
    void Start()//skinアンロックの処理
    {
        for (int i = 0; i < Lockskin.Length; i++)
        {
            //使えるスキンはlock画像を非表示にする
            if (i == 0 && playerBestscore >= unLockSkin0)
            {
                Lockskin[0].SetActive(false);
            }
            else if (i == 1 && playerBestscore >= unLockSkin1)
            {
                Lockskin[1].SetActive(false);
            }
            else if (i == 2 && playerBestscore >= unLockSkin2)
            {
                Lockskin[2].SetActive(false);
            }
            //totalScore
            else if (i == 3 && totalScore >= unLockToal_Skin3)
            {
                Lockskin[3].SetActive(false);
            }
            else if (i == 4 && totalScore >= unLockTotal_Skin4)
            {
                Lockskin[4].SetActive(false);
            }
            else if (i == 5 && totalScore >= unLockTotal_Skin5)
            {
                Lockskin[5].SetActive(false);
            }
            else if (i == 6 && totalCount >= TotalCount_skin1)
            {
                Lockskin[6].SetActive(false);
            }
            else if (i == 7 && totalCount >= TotalCount_skin2)
            {
                Lockskin[7].SetActive(false);
            }
            else if (i == 8 && totalCount >= TotalCount_skin3)
            {
                Lockskin[8].SetActive(false);
            }
        }
        // if (PlayerPrefs.HasKey("ChangeNumber"))
        //     Debug.Log("スキンの順番のデータがあるよ！");
        // else
        //     Debug.Log("スキンの順番のデータがないよ！");

        // if (PlayerPrefs.HasKey("TotalScore"))
        //     Debug.LogError("トータルスコアのデータがあるよ！");
        // else
        //     Debug.LogError("トータルスコアのデータがないよ！");

        // if (PlayerPrefs.HasKey("GameScore"))
        //     Debug.LogError("ゲームスコアのデータがあるよ！");
        // else
        //     Debug.LogError("ゲームスコアのデータがないよ！");

    }

    private void BestScoreText()
    {
        bestscoreText.text = "Best: " + playerBestscore + "P";
    }
    private void TotalScoreText()
    {
        bestscoreText.text = "Total: " + totalScore + "P";
    }
    private void TotalCountText()
    {
        bestscoreText.text = "Played: " + totalCount;
    }

    public void ChangeSkinButton0()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 0;
        _changeskin[0].SetActive(true);
        SaveDate(); BestScoreText();
    }
    public void ChangeSkinButton1()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 1;
        _changeskin[1].SetActive(true);
        SaveDate(); BestScoreText();
    }
    public void ChangeSkinButton2()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 2;
        _changeskin[2].SetActive(true);
        SaveDate(); BestScoreText();
    }


    //ここから、特定の条件を満たしたら使えるスキン達
    //BestScoreの条件を満たしたら使えるスキン達
    public void ChangeSkinButton3()//buttonを押したらスキンが変わっていく
    {
        BestScoreText();
        if (playerBestscore >= unLockSkin0)//1万
        {
            Resetchangeskin();
            changeNumber = 3;
            _changeskin[3].SetActive(true);
            SaveDate();
        }
    }
    public void ChangeSkinButton4()//buttonを押したらスキンが変わっていく
    {
        BestScoreText();
        if (playerBestscore >= unLockSkin1)//5万
        {
            Resetchangeskin();
            changeNumber = 4;
            _changeskin[4].SetActive(true);
            SaveDate();
        }
    }
    public void ChangeSkinButton5()//buttonを押したらスキンが変わっていく
    {
        BestScoreText();
        if (playerBestscore >= unLockSkin2)//10万
        {
            Resetchangeskin();
            changeNumber = 5;
            _changeskin[5].SetActive(true);
            SaveDate();
        }
    }

    //TotalScoreの条件を満たしたら使えるスキン達
    public void ChangeSkinButton6()
    {
        TotalScoreText();
        if (totalScore >= unLockToal_Skin3)
        {
            Resetchangeskin();
            changeNumber = 6;
            _changeskin[6].SetActive(true);
            SaveDate();
        }
    }
    //TotalScoreの条件を満たしたら使えるスキン達
    public void ChangeSkinButton7()
    {
        TotalScoreText();
        if (totalScore >= unLockTotal_Skin4)
        {
            Resetchangeskin();
            changeNumber = 7;
            _changeskin[7].SetActive(true);
            SaveDate();
        }
    }
    public void ChangeSkinButton8()
    {
        TotalScoreText();
        if (totalScore >= unLockTotal_Skin5)
        {
            Resetchangeskin();
            changeNumber = 8;
            _changeskin[8].SetActive(true);
            SaveDate();
        }
    }

    //プレイした合計の回数
    public void ChangeSkinButton9()
    {
        TotalCountText();
        if (totalCount >= TotalCount_skin1)
        {
            Resetchangeskin();
            changeNumber = 9;
            _changeskin[9].SetActive(true);
            SaveDate();
        }
    }
    public void ChangeSkinButton10()
    {
        TotalCountText();
        if (totalCount >= TotalCount_skin2)
        {
            Resetchangeskin();
            changeNumber = 10;
            _changeskin[10].SetActive(true);
            SaveDate();
        }
    }
    public void ChangeSkinButton11()
    {
        TotalCountText();
        if (totalCount >= TotalCount_skin3)
        {
            Resetchangeskin();
            changeNumber = 11;
            _changeskin[11].SetActive(true);
            SaveDate();
        }
    }






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







}
