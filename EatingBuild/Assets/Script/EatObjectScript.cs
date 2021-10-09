using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EatObjectScript : MonoBehaviour
{

    [SerializeField] private float smallTime = 2;//objectを小さくするのにかかる時間
    [SerializeField] private float playerScaleTime = 1;//プレイヤーを大きくするのにかかる時間

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject Cylinder;//子オブジェクトの本体をアタッチする


    void OnTriggerEnter(Collider col)
    {
        int p = gameManager.point;//GameManagerスクリプトの変数を参照

        if (col.CompareTag("cube"))//cubeタグがついているオブジェクトを食べたときの、そのオブジェクトをの処理
        {
            if (p >= 0)
            {
                col.transform.DOShakeRotation(
                     duration: smallTime,   // 演出時間
                     strength: 90f   // シェイクの強さ
                );
                col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                .OnComplete(() =>//dotween終了後、cubeを消す
                {
                    gameManager.AddPoint(5);//ポイントを１０追加する
                    col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                    Debug.Log(gameManager.point);
                });
            }
            else
            {
                NotEatBuild();
            }
        }
        else if (col.CompareTag("30p"))
        {
            if (p >= 30)
            {
                col.transform.DOShakeRotation(
                     duration: smallTime,   // 演出時間
                     strength: 90f   // シェイクの強さ
                );
                col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                .OnComplete(() =>//dotween終了後、cubeを消す
                {
                    gameManager.AddPoint(30);//ポイントを１０追加する
                    col.gameObject.SetActive(false);
                    Debug.Log(gameManager.point);
                });
            }
            else
            {
                NotEatBuild();
            }
        }
    }

    private void NotEatBuild()
    {
        DOTween.Sequence()
            .Append(Cylinder.transform.DOLocalRotate(new Vector3(0f, -45f, 0f), 0.5f))
            .Append(Cylinder.transform.DOLocalRotate(new Vector3(0f, 45f, 0f), 0.5f))
            .SetLoops(2)
            .Append(Cylinder.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.5f));
    }


    void Update()
    {
        //Playerの大きさをポイントに応じて変更する
        int p = gameManager.point;

        if (p < 10)
        {
            this.gameObject.transform.DOScale(
                new Vector3(1f, 1f, 1f), playerScaleTime
            );
        }
        else if (10 <= p && p < 20)
        {
            this.gameObject.transform.DOScale(
                new Vector3(1.5f, 1.5f, 1.5f), playerScaleTime
            );
        }
        else if (20 <= p && p < 30)
        {
            this.gameObject.transform.DOScale(
                new Vector3(2f, 2f, 2f), playerScaleTime
            );
        }
        else if (30 <= p && p < 40)
        {
            this.gameObject.transform.DOScale(
                new Vector3(2.5f, 2.5f, 2.5f), playerScaleTime
            );
        }
        else if (40 <= p && p < 50)
        {
            this.gameObject.transform.DOScale(
                new Vector3(3f, 3f, 3f), playerScaleTime
            );
        }
        else if (50 <= p && p < 100)
        {
            this.gameObject.transform.DOScale(
                new Vector3(3.5f, 3.5f, 3.5f), playerScaleTime
            );
        }
        else if (100 <= p)
        {
            this.gameObject.transform.DOScale(
                new Vector3(8f, 8f, 8f), playerScaleTime
            );
        }



    }


}