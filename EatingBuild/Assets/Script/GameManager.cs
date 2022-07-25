using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class GameManager : MonoBehaviour
{

    public int point;//大きさを変える時などに使うポイント
    [SerializeField] private EatObjectScript playerEat;
    // [SerializeField] private Text scoreText;
    [SerializeField] private TextMeshProUGUI addScoreText;//+1 +2 と画面に何ポイント追加したか表示する
    [SerializeField] private GameObject returnstart_b;
    public int killpoint;
    [SerializeField] private Text killText;//killした数を表示
    public Color EndColor;

    public int[] score_all;//NPCとplayerのスコアを格納する




    public void AddPoint(int number)//ポイントの追加
    {
        point = point + number;
        // addScoreText.text = $"+{number}";
    }

    public void AddKill(int number)//killした数を追加
    {
        killpoint = killpoint + number;
        killText.text = $"{killpoint} kill";
    }

    public void ReturnStartSceneButton()//highscoretableを表示した後にスタートシーンに戻るボタン
    {
        SceneManager.LoadScene("StartScene");
    }
    // public void ReturnBeforeStartScene_b()//returnstart_bを押して広告を見る前の処理
    // {
    //     returnstart_b.SetActive(false);
    // }

    void Start()
    {
        killText.text = "0 kill";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Demo");
        }
        // scoreText.text = point.ToString();
    }


}
