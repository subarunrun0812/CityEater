using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class ItemMove : MonoBehaviour
{
    public Transform[] points;

    private int destPoint = 0;
    private NavMeshAgent agentCar;

    void Awake()
    {
        agentCar = GetComponent<NavMeshAgent>();
        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agentCar.autoBraking = false;
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        //地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        //agentCarが現在設定された目標地点に行くように設定します
        agentCar.destination = points[destPoint].position;

        //配列内の次の位置を目標地点に設定し、必要ならば目標地点に戻ります
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        //agentCarが現目標地点に近づいてきたら、次の目標地点を選択します
        //pathPending = 経路探索の準備ができているかどうか（読み取り専用）
        //remainingDistance =  エージェントの位置および現在の経路での目標地点の間の距離（読み取り専用）
        if (!agentCar.pathPending && agentCar.remainingDistance < 1f)
            GotoNextPoint();
    }
}
