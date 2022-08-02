using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class EatObjectScript : MonoBehaviour
{
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
    [SerializeField] private GameObject tropyObj;

    [SerializeField] private OneHundredMillion _100m_script;
    [SerializeField] public AudioClip sound1;
    [SerializeField] AudioSource audioSource;
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
    public int objoverMax = 2147483647;//int型の最大値
    private int decreasePoint;
    void Start()
    {
        float Playerspeed = playerController.speed;
        speedUp_t.SetActive(false);
        sizeDown_t.SetActive(false);
        sizeUp_t.SetActive(false);
        kO_t.SetActive(false);
    }

    private void VIbrationFunction()//スマホを振動される関数
    {
#if UNITY_IOS
#if UNITY_ANDROID
        VibrationMng.ShortVibration();//スマホを短く振動させる
#endif
#endif
        //音楽を鳴らす
        //音(sound1)を鳴らす
        audioSource.PlayOneShot(sound1);
    }
    private void AccelerationItem()//スピードアップのアイテムを食べた時.
    {
        changeSpeed = 0.03f;
        playerController.speed += changeSpeed;
        speedUp_t.SetActive(true);
    }
    private void IncreasePointItem()//Pointが増えるアイテムを食べた時.
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
        decreasePoint = gameManager.point / 6;//小数点以下は切り捨て。
        decreasePoint = -decreasePoint;//-にする
        Debug.Log(decreasePoint);
        gameManager.AddPoint(decreasePoint);//pointを減少
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
        int p = gameManager.point;//Playerのぽいん

        switch (col.gameObject.tag)
        {
            case "Untagged":
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
                break;

            case "AT"://speedが上がるアイテムを食べた時
                if (p >= 0)
                {
                    AccelerationItem();
                    //gameObjectを消すより、非表示にする方が処理が軽い
                    col.gameObject.SetActive(false);
                    VIbrationFunction();
                }
                break;

            case "INCR"://Pointが増えるアイテムを食べた時
                if (p >= 0)
                {
                    IncreasePointItem();
                    col.gameObject.SetActive(false);
                    VIbrationFunction();
                }
                break;

            case "DEC"://Pointが減るアイテムを食べた時
                if (p >= 0)
                {
                    DecreasePointItem();
                    col.gameObject.SetActive(false);
                    VIbrationFunction();
                }
                break;

            case "QUESTION"://ランダムアイテムを食べたとき
                if (p >= 0)
                {
                    QuestionItem();
                    col.gameObject.SetActive(false);
                    VIbrationFunction();
                }
                break;

            case "1p":
                if (p >= 0)
                {
                    EatPointObjFunction(col, 1, smallTime);
                }
                break;

            case "2p":
                if (p >= obj2p)
                {
                    EatPointObjFunction(col, 2, smallTime);
                }
                break;
            case "3p":
                if (p >= obj3p)
                {
                    EatPointObjFunction(col, 3, smallTime);
                }
                break;
            case "4p":
                if (p >= obj4p)
                {
                    EatPointObjFunction(col, 4, smallTime);
                }
                break;
            case "5p":
                if (p >= obj5p)
                {
                    EatPointObjFunction(col, 5, smallTime);
                }
                break;
            case "8p":
                if (p >= obj8p)
                {
                    EatPointObjFunction(col, 8, smallTime);
                }
                break;

            case "10p":
                if (p >= obj10p)
                {
                    EatPointObjFunction(col, 20, smallTime);
                }
                break;

            case "12p":
                if (p >= obj12p)
                {
                    EatPointObjFunction(col, 36, smallTimeApartment);
                }
                break;

            case "15p":
                if (p >= obj15p)
                {
                    EatPointObjFunction(col, 150, smallTimeApartment);
                }
                break;

            case "20p":
                if (p >= obj20p)
                {
                    EatPointObjFunction(col, 200, smallTimeBigApartment);
                }
                break;

            case "30p":
                if (p >= obj30p)
                {
                    EatPointObjFunction(col, 1200, smallTimeBigApartment);
                }
                break;

            case "50p":
                if (p >= obj50p)
                {
                    EatPointObjFunction(col, 1500, smallTimeBigApartment);
                }
                break;
        }
    }
    private void EatPointObjFunction(Collider col, int point, float smallTime)
    {
        col.enabled = false;
        col.transform.DOShakeRotation(
             duration: smallTime,   // 演出時間
             strength: 60f   // シェイクの強さ
        );
        col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
        .OnComplete(() =>//dotween終了後、cubeを消す
        {
            gameManager.AddPoint(point);
            col.gameObject.SetActive(false);

        });
        VIbrationFunction();
    }

    void FixedUpdate()//playerのレベルに応じて、パラメーターを変更
    {
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
            ChangeInSize(1.5f, 21, obj2p, obj3p, 1);
        }
        else if (obj3p <= p && p < obj4p)
        {
            ChangeInSize(2f, 23, obj3p, obj4p, 2);
        }
        else if (obj4p <= p && p < obj5p)
        {
            ChangeInSize(2.5f, 25, obj4p, obj5p, 3);
            if (speedflag == true)
            {
                speedflag = false;
                playerController.speed += addSpeed;
            }
        }
        else if (obj5p <= p && p < obj8p)
        {
            ChangeInSize(3f, 27, obj5p, obj8p, 4);
            if (speedflag == false)
            {
                speedflag = true;
                playerController.speed += addSpeed;
            }
        }
        else if (obj8p <= p && p < obj10p)
        {
            ChangeInSize(4f, 31, obj8p, obj10p, 5);
            if (speedflag == true)
            {
                speedflag = false;
                playerController.speed += addSpeed;
            }
        }
        else if (obj10p <= p && p < obj12p)
        {
            ChangeInSize(6f, 35, obj10p, obj12p, 6);
            if (speedflag == false)
            {
                speedflag = true;
                playerController.speed += addSpeed;
            }
        }
        else if (obj12p <= p && p < obj15p)
        {
            ChangeInSize(8f, 39, obj12p, obj15p, 7);
            if (speedflag == true)
            {
                speedflag = false;
                playerController.speed += addSpeed;
            }
        }
        else if (obj15p <= p && p < obj20p)
        {
            ChangeInSize(10f, 49, obj15p, obj20p, 8);
            if (speedflag == false)
            {
                speedflag = true;
                playerController.speed += addSpeed;
            }
        }
        else if (obj20p <= p && p < obj30p)
        {
            ChangeInSize(12f, 59, obj20p, obj30p, 9);
            if (speedflag == true)
            {
                speedflag = false;
                playerController.speed += addSpeed;
            }
        }
        else if (obj30p <= p && p < objover1)
        {
            ChangeInSize(14f, 71, obj30p, objover1, 10);
            if (speedflag == false)
            {
                speedflag = true;
                playerController.speed += addSpeed;
            }
        }
        else if (objover1 <= p && p < objover2)
        {
            ChangeInSize(16f, 79, objover1, objover2, 11);
            if (speedflag == true)
            {
                speedflag = false;
                playerController.speed += addSpeed;
            }
        }
        else if (objover2 <= p && p < objover3)
        {
            ChangeInSize(18f, 89, objover2, objover3, 12);
            if (speedflag == false)
            {
                speedflag = true;
                playerController.speed += addSpeed;
            }
        }
        else if (objover3 <= p && p < objover4)
        {
            ChangeInSize(20f, 99, objover3, objover4, 13);
            if (speedflag == true)
            {
                speedflag = false;
                playerController.speed += addSpeed;
            }
        }
        else if (objover4 <= p && p < objover5)
        {
            ChangeInSize(22f, 109, objover4, objover5, 14);
            if (speedflag == false)
            {
                speedflag = true;
                playerController.speed += addSpeed;
            }
        }
        else if (objover5 <= p && p < objover6)
        {
            ChangeInSize(24f, 119, objover5, objover6, 15);
            if (speedflag == true)
            {
                speedflag = false;
                playerController.speed += addSpeed;
            }
        }
        else if (objover6 <= p && p < objoverMax)
        {
            ChangeInSize(26, 129, objover6, objoverMax, 16);
            if (speedflag == false)
            {
                speedflag = true;
                playerController.speed += addSpeed;
            }
        }

        else if (p == objoverMax)//int型の最大値に達したとき
        {
            float proportion = 1;
            sphImg.fillAmount = proportion;
            //ゲームを強制終了
            highScoreTable.SetActive(true);
        }

    }
    private void ChangeInSize(float size, int cameraDis, int num1, int num2, int levelNum)
    {
        this.gameObject.transform.DOScale(
                    new Vector3(size, size, size), playerScaleTime
                );
        refCamera.distance = cameraDis;
        float proportion = ((float)gameManager.point - num1) / (num2 - num1);//割合 = 元の数 / 比べる数
        sphImg.fillAmount = proportion;
        level = levelNum;
        string levelText = $"{levelNum}";
        level_t.text = levelText;
    }
}
