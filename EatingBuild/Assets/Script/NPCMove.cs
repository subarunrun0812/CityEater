using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class NPCMove : MonoBehaviour
{

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
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //目標地点に近づいても速度を落とさなくなる
        agent.autoBraking = false;
        //目標地点を決める
        GotoNextPoint();
    }
    void GotoNextPoint()//NPCのpointに応じて、目標地点のゲームタグ決める
    {
        //NavMeshAgentのストップを解除
        agent.isStopped = false;

        //eatObjectscriptと変数の値を統一する
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

        //NPCの大きさをポイントに応じて変更する
        p = npceat.point;
        //arrangement(配列) を略してarr

        if (0 <= p && p < obj3p)
        {
            GameObject[] arrObj1 = GameObject.FindGameObjectsWithTag("1p");
            for (int i = 0; i < arrObj1.Length; i++)//destinationListnに配列の要素を足していく
            {
                destinationList.Add(arrObj1[i]);
                Debug.Log(arrObj1[i]);
            }
        }

        //destinationListの要素をランダムで取得する
        int _random = Random.Range(0, destinationList.Count);
        //もし、配列の[i]番目のオブジェクトがあったら
        if (_random < destinationList.Count && destinationList[_random].transform.gameObject.activeSelf == true)
        {
            if (Vector3.Distance(agent.destination, destinationList[_random].transform.position) > 0.5f)
            {
                agent.destination = destinationList[_random].transform.position;
                destinationList.RemoveAt(_random); //Listの_random番目の要素を消す
            }
        }
        Debug.Log(destinationList.Count);
        // Debug.Log(destinationList[_random].transform.gameObject.name);
        // Debug.Log(destinationList.Count);

    }
    void Update()
    {
        //経路探索の準備ができておらず目標地点までの距離が0.5m未満ならNavMeshAgentを止める
        //remainigDistance = エージェントの位置および現在の経路での目標地点の間の距離（読み取り専用）
        //pathPending経路探索の準備ができているかどうか（読み取り専用）
        if (!agent.pathPending && agent.remainingDistance < 1f)
            // 目標地点を設定し直す
            GotoNextPoint();
    }

    void StopHere()
    {
        //NavMeshAgentを止める
        agent.isStopped = true;
        //待ち時間を数える
        time += Time.deltaTime;

        //待ち時間が設定された数値を超えると発動
        if (time > waitTime)
        {
            //目標地点を設定し直す
            GotoNextPoint();
            time = 0;
        }
    }

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
        p = npceat.point;
        //衝突したオブジェクトにPlayerタグが付いていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            if (p >= gameManager.point)
            {
                agent.destination = collider.transform.position;
            }
            else
            {
                agent.destination = -collider.transform.position;//playerと反対方向にいく
            }
        }
    }
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