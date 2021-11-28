using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.AI;
public class NPCEatObjectScript : MonoBehaviour
{
    [SerializeField] private EatObjectScript eatObj;//PlayerのeatObjectscriptをアタッチする

    void NPCAddPoint(int number)//ポイントの追加
    {
        point = point + number;
    }
    public int point;//大きさを変える時などに使うポイント
    [SerializeField] private GameObject pacMan;//子オブジェクトの本体をアタッチする
    bool sizeFlag = true;
    private NavMeshAgent _agent;
    private float addSpped = 2f;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        float agentspeed = _agent.speed;
    }




    void OnTriggerEnter(Collider col)
    {
        //eatObjectscriptと変数の値を統一する
        float smallTime = eatObj.smallTime;//objectを小さくするのにかかる時間
        float smallTimeApartment = eatObj.smallTimeApartment;//マンションを小さくするのにかかる時間
        float smallTimeBigApartment = eatObj.smallTimeBigApartment;//大きいビルを小さくするのにかかる時間
        float playerScaleTime = eatObj.playerScaleTime;//プレイヤーを大きくするのにかかる時間
        int obj2p = eatObj.obj2p;
        int obj3p = eatObj.obj3p;
        int obj4p = eatObj.obj4p;
        int obj5p = eatObj.obj5p;
        int obj8p = eatObj.obj8p;
        int obj10p = eatObj.obj10p;
        int obj12p = eatObj.obj12p;
        int obj15p = eatObj.obj15p;
        int obj20p = eatObj.obj20p;
        int obj30p = eatObj.obj30p;
        int obj50p = eatObj.obj50p;
        int p = point;

        switch (col.gameObject.tag)
        {
            case "Untagged"://ポイントがついている以外は食べれない
                break;

            case "Player":
                if (p > gameManager.point)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeBigApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeBigApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        NPCAddPoint(gameManager.point);
                        col.gameObject.SetActive(false);

                    });
                }
                else
                {
                    NotEatBuild();
                }
                break;

            case "NPC":
                if (p > col.gameObject.GetComponent<NPCEatObjectScript>().point)
                {
                    col.transform.DOShakeRotation(
                         duration: smallTimeBigApartment,   // 演出時間
                         strength: 60f   // シェイクの強さ
                    );
                    col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTimeBigApartment)
                    .OnComplete(() =>//dotween終了後、cubeを消す
                    {
                        gameManager.AddPoint(col.gameObject.GetComponent<NPCEatObjectScript>().point);
                        col.gameObject.SetActive(false);

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
                        NPCAddPoint(1);//ポイントを1追加する
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
                        NPCAddPoint(2);
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
                        NPCAddPoint(3);
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
                        NPCAddPoint(4);
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
                        NPCAddPoint(5);
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
                        NPCAddPoint(8);

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
                        NPCAddPoint(10);

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
                        NPCAddPoint(12);

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
                        NPCAddPoint(15);

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
                        NPCAddPoint(20);

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
                        NPCAddPoint(30);

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
                        NPCAddPoint(50);

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
        //eatObjectscriptと変数の値を統一する
        float smallTime = eatObj.smallTime;//objectを小さくするのにかかる時間
        float smallTimeApartment = eatObj.smallTimeApartment;//マンションを小さくするのにかかる時間
        float smallTimeBigApartment = eatObj.smallTimeBigApartment;//大きいビルを小さくするのにかかる時間
        float playerScaleTime = eatObj.playerScaleTime;//プレイヤーを大きくするのにかかる時間
        int obj2p = eatObj.obj2p;
        int obj3p = eatObj.obj3p;
        int obj4p = eatObj.obj4p;
        int obj5p = eatObj.obj5p;
        int obj8p = eatObj.obj8p;
        int obj10p = eatObj.obj10p;
        int obj12p = eatObj.obj12p;
        int obj15p = eatObj.obj15p;
        int obj20p = eatObj.obj20p;
        int obj30p = eatObj.obj30p;
        int obj50p = eatObj.obj50p;
        {
            //Playerの大きさをポイントに応じて変更する
            int p = point;

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
                    _agent.speed += addSpped;
                }


            }
            else if (obj3p <= p && p < obj4p)
            {
                this.gameObject.transform.DOScale(
                    new Vector3(2f, 2f, 2f), playerScaleTime
                );
                if (sizeFlag == false)
                {
                    _agent.speed += addSpped;
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
                    _agent.speed += addSpped;
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
                    _agent.speed += addSpped;
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
                    _agent.speed += addSpped;
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
                    _agent.speed += addSpped;
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
                    _agent.speed += addSpped;
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
                    _agent.speed += addSpped;
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
                    _agent.speed += addSpped;
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