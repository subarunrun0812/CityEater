using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EatObjectScript : MonoBehaviour
{

    [SerializeField] private int smallTime = 2;

    [SerializeField] private GameManager gameManager;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("cube"))
        {
            col.transform.DOShakeRotation(
                 duration: smallTime,   // 演出時間
                 strength: 90f   // シェイクの強さ
            );
            col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
            .OnComplete(() =>//dotween終了後、cubeを消す
            {
                gameManager.AddPoint(10);//ポイントを１０追加する
                col.gameObject.SetActive(false);
                Debug.Log(gameManager.point);
            });
        }
    }

    void Update()
    {
        //Playerの大きさをポイントに応じて変更する
        int p = gameManager.point;

        if (p < 10)
        {
            this.gameObject.transform.DOScale(
                new Vector3(1f, 1f, 1f), 1f
            );
        }
        else if (10 <= p && p < 20)
        {
            this.gameObject.transform.DOScale(
                new Vector3(2f, 2f, 2f), 1f
            );
        }

    }

    public void PlayerScale()//プレイヤーの大きさを変更する関数
    {
        // this.gameObject.transform.DOScale(new Vector3())
    }
}