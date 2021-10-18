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
                break;

            case "cube"://テスト用のオブジェクトなので、後で消さなければならない
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
                break;

            case "1p":

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

                if (p >= 10)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 90f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(2);
                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;


            case "3p":

                if (p >= 50)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 90f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(3);
                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "4p":

                if (p >= 100)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 90f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(4);
                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "5p":

                if (p >= 200)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 90f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(5);
                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;


            case "8p":
                if (p >= 400)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(8);

                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "10p":
                if (p >= 800)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(10);

                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "12p":
                if (p >= 1500)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(12);

                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "15p":
                if (p >= 3000)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(15);

                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "20p":
                if (p >= 5000)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(20);

                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "30p":
                if (p >= 10000)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(30);

                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "50p":
                if (p >= 15000)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(50);

                        col.gameObject.SetActive(false);
                        Debug.Log(gameManager.point);
                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;


        }
    }

    private void NotEatBuild()
    {
        // DOTween.Sequence()
        //     .Append(Cylinder.transform.DOLocalRotate(new Vector3(0f, -45f, 0f), 0.5f))
        //     .Append(Cylinder.transform.DOLocalRotate(new Vector3(0f, 45f, 0f), 0.5f))
        //     .SetLoops(2)
        //     .Append(Cylinder.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.5f));
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
        else if (10 <= p && p < 50)
        {
            this.gameObject.transform.DOScale(
                new Vector3(1.5f, 1.5f, 1.5f), playerScaleTime
            );
        }
        else if (50 <= p && p < 100)
        {
            this.gameObject.transform.DOScale(
                new Vector3(2f, 2f, 2f), playerScaleTime
            );
        }
        else if (100 <= p && p < 200)
        {
            this.gameObject.transform.DOScale(
                new Vector3(2.5f, 2.5f, 2.5f), playerScaleTime
            );
        }
        else if (200 <= p && p < 400)
        {
            this.gameObject.transform.DOScale(
                new Vector3(3f, 3f, 3f), playerScaleTime
            );
        }
        else if (400 <= p && p < 800)
        {
            this.gameObject.transform.DOScale(
                new Vector3(4f, 4f, 4f), playerScaleTime
            );
        }

        else if (800 <= p && p < 1500)
        {
            this.gameObject.transform.DOScale(
                new Vector3(6f, 6f, 6f), playerScaleTime
            );
        }
        else if (1500 <= p && p < 3000)
        {
            this.gameObject.transform.DOScale(
                new Vector3(8f, 8f, 8f), playerScaleTime
            );
        }
        else if (3000 <= p && p < 5000)
        {
            this.gameObject.transform.DOScale(
                new Vector3(10f, 10f, 10f), playerScaleTime
            );
        }
        else if (5000 <= p && p < 10000)
        {
            this.gameObject.transform.DOScale(
                new Vector3(12f, 12f, 12f), playerScaleTime
            );
        }
        else if (10000 <= p && p < 15000)
        {
            this.gameObject.transform.DOScale(
                new Vector3(15f, 15f, 15f), playerScaleTime
            );
        }
        else if (15000 <= p && p < 100000)
        {
            this.gameObject.transform.DOScale(
                new Vector3(20f, 20f, 20f), playerScaleTime
            );
        }





    }


}