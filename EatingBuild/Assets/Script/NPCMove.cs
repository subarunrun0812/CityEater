using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class NPCMove : MonoBehaviour
{
    private GameObject[] targets;

    private GameObject closeObj;
    private GameObject closeEnemy;

    [SerializeField] private NPCEatObjectScript npceat;
    private int p;
    [SerializeField] GameManager gameManager;

    //位置の基準になるオブジェクトのTransformを収める
    public Transform central;
    private NavMeshAgent agent;
    //ランダムで決める数値の最大値
    [SerializeField] float radius = 3;
    //設定した待機時間
    [SerializeField] float waitTime = 2;
    //待機時間を数える
    [SerializeField] float time = 0;
    [SerializeField] private EatObjectScript eatObj;

    private List<GameObject> destinationList = new List<GameObject>();//NPCの目的地

    //Vector3 pos;
    private int _random;//乱数。NPCの目的地で使う
    private bool flag = true;

    [SerializeField] private GameObject npc_crown;
    private float closeDist;

    void OnDisable()
    {
        npc_crown.SetActive(false);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //目標地点に近づいても速度を落とさなくなる
        agent.autoBraking = false;


        // タグを使って画面上の全ての1pの情報を取得
        targets = GameObject.FindGameObjectsWithTag("1p");
        //初期値の設定
        closeDist = 1000;
        foreach (GameObject t in targets)
        {
            // コンソール画面での確認用コード
            Debug.Log(Vector3.Distance(transform.position, t.transform.position));

            // このオブジェクト（砲弾）と敵までの距離を計測
            float tDist = Vector3.Distance(transform.position, t.transform.position);

            // もしも「初期値」よりも「計測した敵までの距離」の方が近いならば、
            if (closeDist > tDist)
            {
                // 「closeDist」を「tDist（その敵までの距離）」に置き換える。
                // これを繰り返すことで、一番近い敵を見つけ出すことができる。
                closeDist = tDist;

                // 一番近い敵の情報をcloseEnemyという変数に格納する（★）
                closeEnemy = t;
            }
        }
    }
    void Update()
    {
        //経路探索の準備ができておらず目標地点までの距離が0.5m未満ならNavMeshAgentを止める
        //remainigDistance = エージェントの位置および現在の経路での目標地点の間の距離（読み取り専用）
        //pathPending経路探索の準備ができているかどうか（読み取り専用）
        // if (!agent.pathPending && agent.remainingDistance < 1f)
        //     // 目標地点を設定し直す
        //     GotoNextPoint();

        float step = npceat._agent.speed * Time.deltaTime;
        // ★で得られたcloseEnemyを目的地として設定する。
        agent.destination = Vector3.MoveTowards(transform.position, closeObj.transform.position, step);

    }

    void NextDestination()
    {
        foreach (GameObject t in targets)
        {
            // コンソール画面での確認用コード
            Debug.Log("transformのポジション" + Vector3.Distance(transform.position, t.transform.position));

            // このオブジェクト（砲弾）と敵までの距離を計測
            float tDist = Vector3.Distance(transform.position, t.transform.position);

            // もしも「初期値」よりも「計測した敵までの距離」の方が近いならば、
            if (closeDist > tDist)
            {
                // 「closeDist」を「tDist（その敵までの距離）」に置き換える。
                // これを繰り返すことで、一番近い敵を見つけ出すことができる。
                closeDist = tDist;

                // 一番近い敵の情報をcloseEnemyという変数に格納する（★）
                closeObj = t;
            }
        }
    }

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
        p = npceat.point;
        //衝突したオブジェクトにPlayerタグが付いていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            if (npceat.npc_level > eatObj.level)//npcとplayerが同じレベルなら追いかける
            {
                agent.destination = collider.transform.position;
            }
            else
            {
                agent.destination = -collider.transform.position;//playerと反対方向にいく
            }
        }
    }
    // void GotoNextPoint()//NPCのpointに応じて、目標地点のゲームタグ決める
    // {
    //     //NavMeshAgentのストップを解除
    //     agent.isStopped = false;

    //     //eatObjectscriptと変数の値を統一する
    //     int obj2p = eatObj.obj2p;
    //     int obj3p = eatObj.obj3p;
    //     int obj4p = eatObj.obj4p;
    //     int obj5p = eatObj.obj5p;
    //     int obj8p = eatObj.obj8p;
    //     int obj10p = eatObj.obj10p;
    //     int obj12p = eatObj.obj12p;
    //     int obj15p = eatObj.obj15p;
    //     int obj20p = eatObj.obj20p;
    //     int obj30p = eatObj.obj30p;
    //     int obj50p = eatObj.obj50p;

    //     //NPCの大きさをポイントに応じて変更する
    //     p = npceat.point;
    //     //arrangement(配列) を略してarr

    //     // GameObject.Find("ゲームタグ名")で見つけたオブジェクトを配列に格納し、その格納したやつをfor文を使ってListに格納します。
    //     if (0 <= p && p < obj3p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("1p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (0 <= p && p < obj3p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("2p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }

    //     else if (obj3p <= p && p < obj5p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("3p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (obj5p <= p && p < obj8p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("5p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (obj8p <= p && p < obj10p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("8p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (obj10p <= p && p < obj12p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("10p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (obj12p <= p && p < obj15p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("12p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (obj15p <= p && p < obj20p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("15p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (obj20p <= p && p < obj30p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("20p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (obj30p <= p && p < obj50p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("30p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }
    //     }
    //     else if (obj50p <= p)
    //     {
    //         GameObject[] arrObj = GameObject.FindGameObjectsWithTag("50p");
    //         for (int i = 0; i < arrObj.Length; i++)//destinationListnに配列の要素を足していく
    //         {
    //             destinationList.Add(arrObj[i]);
    //         }

    //     }




    //     /*
    //     追いかける目標地点を設定します
    //     */
    //     //destinationListの要素をランダムで取得する
    //     int _random = Random.Range(0, destinationList.Count);
    //     // Debug.Log(this.gameObject.name + "の乱数は" + _random);
    //     //もし、配列の[i]番目のオブジェクトがあったら
    //     if (_random < destinationList.Count && destinationList[_random].transform.gameObject.activeSelf == true)
    //     {
    //         if (Vector3.Distance(agent.destination, destinationList[_random].transform.position) > 0.5f)
    //         {
    //             agent.destination = destinationList[_random].transform.position;
    //             // 処理を軽くするため、消したいindexに一番最後の要素を移す
    //             destinationList[_random] = destinationList[destinationList.Count - 1];//_randomの要素を末尾に持ってくる
    //             destinationList.RemoveAt(destinationList.Count - 1); //Listの_random番目の要素を消す
    //         }
    //     }
    // }

    // void StopHere()
    // {
    //     //NavMeshAgentを止める
    //     agent.isStopped = true;
    //     //待ち時間を数える
    //     time += Time.deltaTime;

    //     //待ち時間が設定された数値を超えると発動
    //     if (time > waitTime)
    //     {
    //         //目標地点を設定し直す
    //         GotoNextPoint();
    //         time = 0;
    //     }
    // }
}




// //目標地点のX軸、Z軸をランダムで決める
// float posX = Random.Range(-1 * radius, radius);
// float posZ = Random.Range(-1 * radius, radius);

// //CentralPointの位置にPosXとPosZを足す
// Vector3 pos = central.position;
// pos.x += posX;
// pos.z += posZ;

// //NavMeshAgentに目標地点を設定する
// agent.destination = pos;