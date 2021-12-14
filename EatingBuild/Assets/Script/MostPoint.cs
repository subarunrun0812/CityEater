using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MostPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] npcArray;
    [Header("npcArrayの要素の順番とその子オブジェクトの順番を合わす!絶対!!!"), SerializeField] private GameObject[] npcCrown;
    // private List<NPCEatObjectScript> npceatObj_list;
    [SerializeField] private List<NPCEatObjectScript> nPCEatObjList = new List<NPCEatObjectScript>();
    [SerializeField] private List<int> npcPoints = new List<int>();

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject crown;//王冠



    void Start()
    {
        for (int i = 0; i < npcArray.Length; i++)
        {
            nPCEatObjList.Add(npcArray[i].GetComponent<NPCEatObjectScript>());
        }
        for (int i = 0; i < nPCEatObjList.Count; i++)
        {
            //要素数を増やす
            npcPoints.Add(nPCEatObjList[i].point);
        }
        // Debug.LogError("npcArray.Length" + npcArray.Length);
        // Debug.LogError("npcPoints.Count" + npcPoints.Count);

    }

    void Update()
    {
        for (int i = 0; i < nPCEatObjList.Count; i++)
        {
            //値を上書きする
            npcPoints[i] = nPCEatObjList[i].point;
            // npcPoints.Add(nPCEatObjList[i].point);
            if (npcPoints[i] == npcPoints.Max())
            {
                npcCrown[i].SetActive(true);
            }
        }
        //npcの最大のpとplayer_pを比較する
        if (gameManager.point > npcPoints.Max())//playerが一番ポイントが高かったら
        {
            crown.SetActive(true);//playerの王冠を表示する
            for (int i = 0; i < npcCrown.Length; i++)//それ以外のNPCの王冠は非表示
            {
                npcCrown[i].SetActive(false);
            }
        }
        else//NPCが1位の場合
        {
            crown.SetActive(false);//Playerの王冠は非表示にする
            for (int i = 0; i < nPCEatObjList.Count; i++)
            {
                if (npcPoints[i] == npcPoints.Max())//npcPoints.Maxの値とnpcPointsの値が一致したら
                {
                    npcCrown[i].SetActive(true);//その要素の番号の王冠を表示する
                }
            }
        }
        // Debug.LogError(npcPoints.Max());
    }
}

