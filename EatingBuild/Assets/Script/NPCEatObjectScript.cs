using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class NPCEatObjectScript : MonoBehaviour
{

    [SerializeField] private float smallTime = 2;//objectを小さくするのにかかる時間
    [SerializeField] private float smallTimeApartment = 2;//マンションを小さくするのにかかる時間
    [SerializeField] private float smallTimeBigApartment = 0.8f;//大きいビルを小さくするのにかかる時間
    [SerializeField] private float playerScaleTime = 1;//プレイヤーを大きくするのにかかる時間

    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject pacMan;//子オブジェクトの本体をアタッチする

    bool sizeFlag = true;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float changeSpeed = 0.05f;

    public int obj2p = 10;
    public int obj3p = 50;
    public int obj4p = 100;
    public int obj5p = 200;
    public int obj8p = 400;
    public int obj10p = 800;
    public int obj12p = 1500;
    public int obj15p = 3000;
    public int obj20p = 5000;

    public int obj30p = 8000;
    public int obj50p = 8000;

    void Start()
    {
        float Playerspeed = playerController.speed;
        // if (SystemInfo.supportsVibration)
        // {
        //     Handheld.Vibrate();
        //     Debug.Log("長く振動した");
        // }
    }




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
                    });
                }

                break;

            case "2p":

                if (p >= obj2p)
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

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;


            case "3p":

                if (p >= obj3p)
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

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "4p":

                if (p >= obj4p)
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

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "5p":

                if (p >= obj5p)
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

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;


            case "8p":
                if (p >= obj8p)
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

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "10p":
                if (p >= obj10p)
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

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "12p":
                if (p >= obj12p)
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

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "15p":
                if (p >= obj15p)
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

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "20p":
                if (p >= obj20p)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeBigApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeBigApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(20);

                        col.gameObject.SetActive(false);

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "30p":
                if (p >= obj30p)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeBigApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeBigApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(30);

                        col.gameObject.SetActive(false);

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "50p":
                if (p >= obj50p)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeBigApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeBigApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(50);

                        col.gameObject.SetActive(false);

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

    }



    void FixedUpdate()
    {
        {
            //Playerの大きさをポイントに応じて変更する
            int p = gameManager.point;

            if (p < obj2p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(1f, 1f, 1f), playerScaleTime
                );
            }
            else if (obj2p <= p && p < obj3p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(1.5f, 1.5f, 1.5f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    sizeFlag = false;
                    playerController.speed += changeSpeed;
                }


            }
            else if (obj3p <= p && p < obj4p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(2f, 2f, 2f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    playerController.speed += changeSpeed;
                    sizeFlag = true;
                }
            }
            else if (obj4p <= p && p < obj5p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(2.5f, 2.5f, 2.5f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    sizeFlag = false;
                    playerController.speed += changeSpeed;
                }
            }
            else if (obj5p <= p && p < obj8p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(3f, 3f, 3f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    sizeFlag = true;
                    playerController.speed += changeSpeed;
                }
            }
            else if (obj8p <= p && p < obj10p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(4f, 4f, 4f), playerScaleTime
                );
                if (sizeFlag == true)
                {

                    sizeFlag = false;
                    playerController.speed += changeSpeed;
                }
            }

            else if (obj10p <= p && p < obj12p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(6f, 6f, 6f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    sizeFlag = true;
                    playerController.speed += changeSpeed;
                }
            }
            else if (obj12p <= p && p < obj15p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(8f, 8f, 8f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    sizeFlag = false;
                    playerController.speed += changeSpeed;
                }
            }
            else if (obj15p <= p && p < obj20p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(10f, 10f, 10f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    sizeFlag = true;
                    playerController.speed += changeSpeed;
                }
            }
            else if (obj20p <= p && p < obj30p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(12f, 12f, 12f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    sizeFlag = false;
                    playerController.speed += changeSpeed;
                }
            }
            // else if (obj30p <= p && p < obj50p)
            // {
            //     this.gameObject.transform.DOScale(
            //         new Vector3(14f, 14f, 14f), playerScaleTime
            //     );
            //     if (sizeFlag == false)
            //     {
            //                //         sizeFlag = true;
            //         playerController.speed += changeSpeed;
            //     }
            // }
            // else if (obj50p <= p && p < 100000000)
            // {
            //     this.gameObject.transform.DOScale(
            //         new Vector3(16f, 16f, 16f), playerScaleTime
            //     );
            //     if (sizeFlag == true)
            //     {
            //                //         sizeFlag = false;
            //         playerController.speed += changeSpeed;
            //     }
            // }





        }


    }
}