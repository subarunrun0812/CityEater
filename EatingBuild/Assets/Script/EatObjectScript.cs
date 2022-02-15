using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class EatObjectScript : MonoBehaviour
{
    private bool ptsText_flag = true;
    private bool speedflag = true;
    private float addSpeed = 0.016f;
    public float smallTime = 2;//objectを小さくするのにかかる時間
    public float smallTimeApartment = 2;//マンションを小さくするのにかかる時間
    public float smallTimeBigApartment = 0.8f;//大きいビルを小さくするのにかかる時間
    public float playerScaleTime = 1;//プレイヤーを大きくするのにかかる時間

    [SerializeField] private Image sphImg;//円グラフのゲージ
    [SerializeField] private Text level_t;//円グラフのゲージの中のLv.(text)
    [SerializeField] private GameObject highScoreTable;//int型の最大値に到達した時に使う

    [SerializeField] private GameManager gameManager;

    [SerializeField] private PlayerFollowCamera refCamera;
    // [SerializeField] private GameObject pacMan;//子オブジェクトの本体をアタッチする
    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject sizeUp_t;
    [SerializeField] private GameObject sizeDown_t;
    [SerializeField] private GameObject speedUp_t;
    [SerializeField] private GameObject kO_t;
    [SerializeField] private AnimationTextKO ko_script;
    [SerializeField] private GameObject _100m_t;

    [SerializeField] private OneHundredMillion _100m_script;
    [SerializeField] public AudioClip sound1;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private GameObject effectPrefab;
    public int level;//pointを一定ごとにlvに分類させていく
    private float changeSpeed;
    public int obj2p;
    public int obj3p;
    public int obj4p;
    public int obj5p;
    public int obj8p;
    public int obj10p;
    public int obj12p;
    public int obj15p;
    public int obj20p;

    public int obj30p;
    public int obj50p;
    public int objover1;
    public int objover2;
    public int objover3;
    public int objover4;
    public int objover5;
    public int objover6;
    // public int objover7 = 40000000;
    // public int objover8 = 80000000;
    // public int objover9 = 160000000;
    public int objoverMax = 2147483647;//int型の最大値
    private int halthpoint;//gamemanager.pointの半分のpを切り上げたの値を入れる
    void Start()
    {
        float Playerspeed = playerController.speed;
        speedUp_t.SetActive(false);
        sizeDown_t.SetActive(false);
        sizeUp_t.SetActive(false);
        kO_t.SetActive(false);
    }
    private IEnumerator HitStopCorutineSmall()
    {
        // Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.01f);
        // Debug.Log("ヒットストップした");
        // Time.timeScale = 1;
    }
    private IEnumerator HitStopCorutineBig()
    {
        // Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.01f);
        // Debug.Log("ヒットストップした");
        // Time.timeScale = 1;
    }
    private void VIbrationFunction()//スマホを振動される関数
    {
        VibrationMng.ShortVibration();//スマホを短く振動させる
        //音楽を鳴らす
        //音(sound1)を鳴らす
        audioSource.PlayOneShot(sound1);
        // GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        // Destroy(effect, 1f);
    }
    private void AccelerationItem()//スピードアップのアイテムを食べた時.略して AT
    {
        changeSpeed = 0.03f;
        playerController.speed += changeSpeed;
        speedUp_t.SetActive(true);
    }
    private void IncreasePointItem()////Pointが増えるアイテムを食べた時.略して INCR
    {
        sizeUp_t.SetActive(true);
        if (gameManager.point < obj30p)
        {
            gameManager.AddPoint(gameManager.point / 3);//pointを追加
        }
        else if (obj30p <= gameManager.point && gameManager.point < objover2)
        {
            gameManager.AddPoint(gameManager.point / 6);//pointを追加
        }
        else if (objover2 <= gameManager.point)
        {
            gameManager.AddPoint(gameManager.point / 10);//pointを追加
        }

    }
    private void DecreasePointItem()//Pointが減るアイテムを食べた時。
    {
        halthpoint = gameManager.point / 6;//小数点以下は切り捨て。
        halthpoint = -halthpoint;//-にする
        Debug.Log(halthpoint);
        gameManager.AddPoint(halthpoint);//pointを減少
        sizeDown_t.SetActive(true);
        if (gameManager.point >= objover1)
        {
            playerController.speed -= changeSpeed + addSpeed;
        }
        else
        {
            playerController.speed -= addSpeed;
        }

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
                if (level > col.gameObject.GetComponent<NPCEatObjectScript>().npc_level)
                {
                    col.enabled = false;
                    col.transform.DOShakeRotation(
                         duration: 0.5f,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(col.gameObject.GetComponent<NPCEatObjectScript>().point);
                        col.gameObject.SetActive(false);
                    });
                    ko_script.OnEnable(col.gameObject.name);//npcの名前を渡す
                    kO_t.SetActive(true);
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
                    StartCoroutine("HitStopCorutineSmall");
                    col.enabled = false;
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
                    StartCoroutine("HitStopCorutineSmall");
                    col.enabled = false;
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
                    StartCoroutine("HitStopCorutineSmall");
                    col.enabled = false;
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
                    StartCoroutine("HitStopCorutineSmall");
                    col.enabled = false;
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
                    StartCoroutine("HitStopCorutineSmall");
                    col.enabled = false;
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
                    StartCoroutine("HitStopCorutineSmall");
                    col.enabled = false;
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
                    StartCoroutine("HitStopCorutineBig");
                    col.enabled = false;
                    col.transform.DOShakeRotation(
                         duration: smallTime,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
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

            case "12p":
                if (p >= obj12p)
                {
                    StartCoroutine("HitStopCorutineBig");
                    col.enabled = false;
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(36);

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
                    StartCoroutine("HitStopCorutineBig");
                    col.enabled = false;
                    col.transform.DOShakeRotation(
                         duration: smallTimeApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(150);

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
                    StartCoroutine("HitStopCorutineBig");
                    col.enabled = false;
                    col.transform.DOShakeRotation(
                         duration: smallTimeBigApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeBigApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(200);

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
                    StartCoroutine("HitStopCorutineBig");
                    col.enabled = false;
                    col.transform.DOShakeRotation(
                         duration: smallTimeBigApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeBigApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(1200);
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
                    StartCoroutine("HitStopCorutineBig");
                    col.enabled = false;
                    col.transform.DOShakeRotation(
                         duration: smallTimeBigApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeBigApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(1500);

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
    }



    void FixedUpdate()//playerの大きさや速度のパラメーターの変更の処理
    {

        int distaceAdd = 4;
        {
            //Playerの大きさをポイントに応じて変更する
            int p = gameManager.point;

            if (p < obj2p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(1f, 1f, 1f), playerScaleTime
                );
                level = 0;
                level_t.text = "0";
            }
            else if (obj2p <= p && p < obj3p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(1.5f, 1.5f, 1.5f), playerScaleTime
                );
                refCamera.distance = 17 + distaceAdd;//初期値は15

                //sphimgの円グラフのゲージについての処理
                float imgP = ((float)gameManager.point - obj2p) / (obj3p - obj2p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 1;
                level_t.text = "1";
            }
            else if (obj3p <= p && p < obj4p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(2f, 2f, 2f), playerScaleTime
                );
                refCamera.distance = 19 + distaceAdd;//+2

                float imgP = ((float)gameManager.point - obj3p) / (obj4p - obj3p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 2;
                level_t.text = "2";
            }
            else if (obj4p <= p && p < obj5p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(2.5f, 2.5f, 2.5f), playerScaleTime
                );
                refCamera.distance = 21 + distaceAdd;//+2

                float imgP = ((float)gameManager.point - obj4p) / (obj5p - obj4p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 3;
                level_t.text = "3";
                if (speedflag == true)
                {
                    speedflag = false;
                    playerController.speed += addSpeed;
                }
            }
            else if (obj5p <= p && p < obj8p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(3f, 3f, 3f), playerScaleTime
                );
                refCamera.distance = 23 + distaceAdd;//+2

                float imgP = ((float)gameManager.point - obj5p) / (obj8p - obj5p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 4;
                level_t.text = "4";
                if (speedflag == false)
                {
                    speedflag = true;
                    playerController.speed += addSpeed;
                }
            }
            else if (obj8p <= p && p < obj10p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(4f, 4f, 4f), playerScaleTime
                );
                refCamera.distance = 27 + distaceAdd;//+4
                float imgP = ((float)gameManager.point - obj8p) / (obj10p - obj8p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 5;
                level_t.text = "5";
                if (speedflag == true)
                {
                    speedflag = false;
                    playerController.speed += addSpeed;
                }
            }
            else if (obj10p <= p && p < obj12p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(6f, 6f, 6f), playerScaleTime
                );
                refCamera.distance = 31 + distaceAdd;//+4
                float imgP = ((float)gameManager.point - obj10p) / (obj12p - obj10p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 6;
                level_t.text = "6";
                if (speedflag == false)
                {
                    speedflag = true;
                    playerController.speed += addSpeed;
                }
            }
            else if (obj12p <= p && p < obj15p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(8f, 8f, 8f), playerScaleTime
                );
                refCamera.distance = 35 + distaceAdd;//+4
                float imgP = ((float)gameManager.point - obj12p) / (obj15p - obj12p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 7;
                level_t.text = "7";
                if (speedflag == true)
                {
                    speedflag = false;
                    playerController.speed += addSpeed;
                }
            }
            else if (obj15p <= p && p < obj20p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(10f, 10f, 10f), playerScaleTime
                );
                refCamera.distance = 45 + distaceAdd;//+10
                float imgP = ((float)gameManager.point - obj15p) / (obj20p - obj15p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 8;
                level_t.text = "8";
                if (speedflag == false)
                {
                    speedflag = true;
                    playerController.speed += addSpeed;
                }
            }
            else if (obj20p <= p && p < obj30p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(12f, 12f, 12f), playerScaleTime
                );
                refCamera.distance = 55 + distaceAdd;//+10
                float imgP = ((float)gameManager.point - obj20p) / (obj30p - obj20p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 9;
                level_t.text = "9";
                if (speedflag == true)
                {
                    speedflag = false;
                    playerController.speed += addSpeed;
                }
            }
            else if (obj30p <= p && p < objover1)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(14f, 14f, 14f), playerScaleTime
                );
                refCamera.distance = 65 + distaceAdd;//+10
                float imgP = ((float)gameManager.point - obj30p) / (objover1 - obj30p);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 10;
                level_t.text = "10";
                if (speedflag == false)
                {
                    speedflag = true;
                    playerController.speed += addSpeed;
                }
            }
            else if (objover1 <= p && p < objover2)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(16f, 16f, 16f), playerScaleTime
                );
                refCamera.distance = 75 + distaceAdd;//+5
                float imgP = ((float)gameManager.point - objover1) / (objover2 - objover1);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 11;
                level_t.text = "11";
                if (speedflag == true)
                {
                    speedflag = false;
                    playerController.speed += addSpeed;
                }

            }
            else if (objover2 <= p && p < objover3)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(18f, 18f, 18f), playerScaleTime
                );
                refCamera.distance = 85 + distaceAdd;//+5
                float imgP = ((float)gameManager.point - objover2) / (objover3 - objover2);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 12;
                level_t.text = "12";
                if (speedflag == false)
                {
                    speedflag = true;
                    playerController.speed += addSpeed;
                }

            }
            else if (objover3 <= p && p < objover4)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(20f, 20f, 20f), playerScaleTime
                );
                refCamera.distance = 95 + distaceAdd;//+5
                float imgP = ((float)gameManager.point - objover3) / (objover4 - objover3);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 13;
                level_t.text = "13";
                if (speedflag == true)
                {
                    speedflag = false;
                    playerController.speed += addSpeed;
                }

            }
            else if (objover4 <= p && p < objover5)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(22f, 22f, 22f), playerScaleTime
                );
                refCamera.distance = 105 + distaceAdd;//+5
                float imgP = ((float)gameManager.point - objover4) / (objover5 - objover4);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 14;
                level_t.text = "14";
                if (speedflag == false)
                {
                    speedflag = true;
                    playerController.speed += addSpeed;
                }
            }
            else if (objover5 <= p && p < objover6)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(24f, 24f, 24f), playerScaleTime
                );
                refCamera.distance = 115 + distaceAdd;//+5
                float imgP = ((float)gameManager.point - objover5) / (objover6 - objover5);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 15;
                level_t.text = "15";
                if (p >= 100000 && ptsText_flag == true)
                {
                    ptsText_flag = false;
                    _100m_t.SetActive(true);
                    // _100m_script.OnEnable("100,000");
                    Debug.Log("100000を超えた");
                }
                if (speedflag == true)
                {
                    speedflag = false;
                    playerController.speed += addSpeed;
                }
            }
            else if (objover6 <= p && p < objoverMax)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(26f, 26f, 26f), playerScaleTime
                );
                refCamera.distance = 125 + distaceAdd;//+5
                float imgP = ((float)gameManager.point - objover6) / (objoverMax - objover6);//割合 = 元の数 / 比べる数
                sphImg.fillAmount = imgP;
                level = 16;
                level_t.text = "16";
                if (speedflag == false)
                {
                    speedflag = true;
                    playerController.speed += addSpeed;
                }
            }
            // else if (objover7 <= p && p < objover8)
            // {
            //     this.gameObject.transform.DOScale(
            //         new Vector3(21f, 21f, 21f), playerScaleTime
            //     );
            //     refCamera.distance = 100 + distaceAdd;//+5
            //     float imgP = ((float)gameManager.point - objover7) / (objover8 - objover7);//割合 = 元の数 / 比べる数
            //     sphImg.fillAmount = imgP;
            //     level = 17;
            //     level_t.text = "17";
            //     if (speedflag == true)
            //     {
            //         speedflag = false;
            //         playerController.speed += addSpeed;
            //     }
            // }
            // else if (objover8 <= p && p < objover9)
            // {
            //     this.gameObject.transform.DOScale(
            //         new Vector3(22f, 22f, 22f), playerScaleTime
            //     );
            //     refCamera.distance = 105 + distaceAdd;//+5
            //     float imgP = ((float)gameManager.point - objover8) / (objover9 - objover8);//割合 = 元の数 / 比べる数
            //     sphImg.fillAmount = imgP;
            //     level = 18;
            //     level_t.text = "18";
            //     if (speedflag == false)
            //     {
            //         speedflag = true;
            //         playerController.speed += addSpeed;
            //     }
            // }
            // else if (objover9 <= p && p < objoverMax)
            // {
            //     this.gameObject.transform.DOScale(
            //         new Vector3(23f, 23f, 23f), playerScaleTime
            //     );
            //     refCamera.distance = 110 + distaceAdd;//+5
            //     float imgP = ((float)gameManager.point - objover9) / (objoverMax - objover9);//割合 = 元の数 / 比べる数
            //     sphImg.fillAmount = imgP;
            //     level = 19;
            //     level_t.text = "19";
            //     if (speedflag == true)
            //     {
            //         speedflag = false;
            //         playerController.speed += addSpeed;
            //     }
            // }


            else if (p == objoverMax)//int型の最大値を越えさせたいための処理
            {
                float imgP = 1;
                sphImg.fillAmount = imgP;
                highScoreTable.SetActive(true);
            }
        }
    }
}
