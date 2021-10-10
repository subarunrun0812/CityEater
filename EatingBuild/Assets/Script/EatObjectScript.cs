using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EatObjectScript : MonoBehaviour
{

    [SerializeField] private float smallTime = 2;//objectを小さくするのにかかる時間
    [SerializeField] private float smallTimeApartment = 2;//マンションを小さくするのにかかる時間
    [SerializeField] private float playerScaleTime = 1;//プレイヤーを大きくするのにかかる時間

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject Cylinder;//子オブジェクトの本体をアタッチする


    void OnTriggerEnter(Collider col)
    {
        int p = gameManager.point;//GameManagerスクリプトの変数を参照

        switch (col.gameObject.tag)
        {
            case "Untagged"://ポイントがついている以外は食べれない
                NotEatBuild();
                break;

            case "cube"://テスト用のオブジェクトなので、後で消さなければならない
                Debug.Log("switch文が正常に動いた");
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
                break;

            case "1p":
                Debug.Log("switch文が正常に動いた");
                if (p >= 0)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 90f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(1);//ポイントを1追加する
                        col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                        Debug.Log(gameManager.point);
                    });
                }
                break;

            case "2p":
                Debug.Log("switch文が正常に動いた");
                if (p >= 0)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 90f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(2);//ポイントを1追加する
                        col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                        Debug.Log(gameManager.point);
                    });
                }
                break;


            case "3p":
                Debug.Log("switch文が正常に動いた");
                if (p >= 0)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 90f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(3);//ポイントを1追加する
                        col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                        Debug.Log(gameManager.point);
                    });
                }
                break;

            case "5p":
                Debug.Log("switch文が正常に動いた");
                if (p >= 0)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 90f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(5);//ポイントを1追加する
                        col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                        Debug.Log(gameManager.point);
                    });
                }
                break;

            case "30p":
                if (p >= 150)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(30);//ポイントを１０追加する
                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                break;

            case "50p":
                if (p >= 200)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(50);//ポイントを１０追加する
                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                break;

            case "100p":
                if (p >= 500)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(100);//ポイントを１０追加する
                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                break;

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
        else if (20 <= p && p < 50)
        {
            this.gameObject.transform.DOScale(
                new Vector3(2.5f, 2.5f, 2.5f), playerScaleTime
            );
        }
        else if (50 <= p && p < 100)
        {
            this.gameObject.transform.DOScale(
                new Vector3(3f, 3f, 3f), playerScaleTime
            );
        }
        else if (100 <= p && p < 150)
        {
            this.gameObject.transform.DOScale(
                new Vector3(4f, 4f, 4f), playerScaleTime
            );
        }
        else if (150 <= p && p < 200)
        {
            this.gameObject.transform.DOScale(
                new Vector3(5f, 5f, 5f), playerScaleTime
            );
        }
        else if (200 <= p && p < 350)
        {
            this.gameObject.transform.DOScale(
                new Vector3(6f, 6f, 6f), playerScaleTime
            );
        }
        else if (350 <= p && p < 500)
        {
            this.gameObject.transform.DOScale(
                new Vector3(7.5f, 7.5f, 7.5f), playerScaleTime
            );
        }
        else if (500 <= p && p < 1000)
        {
            this.gameObject.transform.DOScale(
                new Vector3(9f, 9f, 9f), playerScaleTime
            );
        }
        else if (1000 <= p && p < 3000)
        {
            this.gameObject.transform.DOScale(
                new Vector3(12f, 12f, 12f), playerScaleTime
            );
        }





    }


}