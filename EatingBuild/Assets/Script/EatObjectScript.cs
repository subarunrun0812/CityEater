using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EatObjectScript : MonoBehaviour
{

    public float smallTime = 2;//objectを小さくするのにかかる時間
    public float smallTimeApartment = 2;//マンションを小さくするのにかかる時間
    public float smallTimeBigApartment = 0.8f;//大きいビルを小さくするのにかかる時間
    public float playerScaleTime = 1;//プレイヤーを大きくするのにかかる時間

    [SerializeField] private GameManager gameManager;

    [SerializeField] private PlayerFollowCamera refCamera;
    [SerializeField] private GameObject pacMan;//子オブジェクトの本体をアタッチする

    private bool sizeFlag = true;
    [SerializeField] private PlayerController playerController;
    public float changeSpeed;
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
    public int objover1 = 12000;
    public int objover2 = 20000;
    public int objover3 = 30000;
    public int objover4 = 50000;

    private int halthpoint;//gamemanager.pointの半分のpを切り上げたの値を入れる
    void Start()
    {
        float Playerspeed = playerController.speed;

    }
    private void VIbrationFunction()//スマホを振動される関数
    {
        VibrationMng.ShortVibration();//スマホを短く振動させる
        // Debug.Log("振動した");
    }
    private void AccelerationItem()//スピードアップのアイテムを食べた時.略して AT
    {
        changeSpeed = 0.04f;
        playerController.speed += changeSpeed;
    }
    private void IncreasePointItem()////Pointが増えるアイテムを食べた時.略して INCR
    {
        halthpoint = gameManager.point / 2;//小数点以下は切り捨て。
        gameManager.AddPoint(halthpoint);//pointを追加
    }
    private void DecreasePointItem()//Pointが減るアイテムを食べた時。
    {
        halthpoint = gameManager.point / 2;//小数点以下は切り捨て。
        halthpoint = -halthpoint;//-にする
        Debug.Log(halthpoint);
        gameManager.AddPoint(halthpoint);//pointを減少
    }
    private void QuestionItem()//questionが食べられた時。
    {
        int ranItem = Random.Range(0, 3);//アイテムは３種類あるから.0~2の間で乱数。intは「max - 1」
        Debug.Log("ranItemは" + ranItem);
        switch (ranItem)
        {
            case 0:
                AccelerationItem();
                break;
            case 1:
                IncreasePointItem();
                break;
            case 2:
                DecreasePointItem();
                break;
        }
    }

    void OnTriggerEnter(Collider col)//食べた時の処理
    {
        int p = gameManager.point;//GameManagerスクリプトの変数を参照

        switch (col.gameObject.tag)
        {
            case "Untagged"://ポイントがついている以外は食べれない
                break;

            case "NPC":
                if (p > col.gameObject.GetComponent<NPCEatObjectScript>().point)
                {
                    col.transform.DOShakeRotation(
                         duration: 0.5f,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(col.gameObject.GetComponent<NPCEatObjectScript>().point);
                        gameManager.AddKill(1);
                        col.gameObject.SetActive(false);

                    });
                    VIbrationFunction();
                }
                else
                {
                    NotEatBuild();
                }

                break;

            case "AT"://speedが上がるアイテムを食べた時
                if (p >= 0)
                {
                    AccelerationItem();
                    col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                    VIbrationFunction();
                }
                break;

            case "INCR"://Pointが増えるアイテムを食べた時
                if (p >= 0)
                {
                    IncreasePointItem();
                    col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                    VIbrationFunction();
                }
                break;

            case "DEC"://Pointが減るアイテムを食べた時
                if (p >= 0)
                {
                    DecreasePointItem();
                    col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                    VIbrationFunction();
                }
                break;

            case "QUESTION"://Pointが減るアイテムを食べた時
                if (p >= 0)
                {
                    QuestionItem();
                    col.gameObject.SetActive(false);//gameObjectを消すより非表示の方が処理が軽いらしい
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
                    VIbrationFunction();
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
        // if (this.transform.position.y == 0)
        // {
        //     this.transform.DOJump(transform.position + new Vector3(-1f, 0f, -1f), 2.0f, 1, 0.4f);
        // }

        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
            Debug.Log("長く振動した");
        }
    }



    void FixedUpdate()//playerの大きさや速度のパラメーターの変更の処理
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
                    refCamera.distance = 17;//初期値は15
                    sizeFlag = false;
                    // playerController.speed += changeSpeed;
                }


            }
            else if (obj3p <= p && p < obj4p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(2f, 2f, 2f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    refCamera.distance = 19;//+2
                    // playerController.speed += changeSpeed;
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
                    refCamera.distance = 21;//+2
                    sizeFlag = false;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (obj5p <= p && p < obj8p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(3f, 3f, 3f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    refCamera.distance = 23;//+2
                    sizeFlag = true;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (obj8p <= p && p < obj10p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(4f, 4f, 4f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    refCamera.distance = 27;//+4
                    sizeFlag = false;
                    // playerController.speed += changeSpeed;
                }
            }

            else if (obj10p <= p && p < obj12p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(6f, 6f, 6f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    refCamera.distance = 31;//+4
                    sizeFlag = true;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (obj12p <= p && p < obj15p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(8f, 8f, 8f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    refCamera.distance = 35;//+4
                    sizeFlag = false;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (obj15p <= p && p < obj20p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(10f, 10f, 10f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    refCamera.distance = 45;//+10
                    sizeFlag = true;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (obj20p <= p && p < obj30p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(12f, 12f, 12f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    refCamera.distance = 55;//+10
                    sizeFlag = false;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (obj30p <= p && p < objover1)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(14f, 14f, 14f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    refCamera.distance = 65;//+10
                    sizeFlag = true;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (objover1 <= p && p < objover2)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(15f, 15f, 15f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    refCamera.distance = 75;//+10
                    sizeFlag = false;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (objover2 <= p && p < objover3)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(16f, 16f, 16f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    refCamera.distance = 85;//+10
                    sizeFlag = false;
                    // playerController.speed += changeSpeed;
                }
            }
            else if (objover3 <= p && p < objover4)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(18f, 18f, 18f), playerScaleTime
                );
                if (sizeFlag == true)
                {
                    refCamera.distance = 95;//+10
                    sizeFlag = false;
                    // playerController.speed += changeSpeed;
                }
            }





        }


    }
}