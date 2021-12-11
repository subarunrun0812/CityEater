using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MostPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] npcArray;
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
        // for (int i = 0; i < nPCEatObjList.Count; i++)
        // {
        //     npcPoints.Add(nPCEatObjList[i].point);
        // }
        Debug.LogError(npcPoints.Count);
    }

    void Update()
    {

        for (int i = 0; i < nPCEatObjList.Count; i++)
        {
            //要素を置き換える
            // npcPoints[i] = nPCEatObjList[i].point;
            npcPoints.Add(nPCEatObjList[i].point);

        }
        //npcの最大のpとplayer_pを比較する
        //playerが一番ポイントが高かったら
        if (gameManager.point > npcPoints.Max())
        {
            crown.SetActive(true);
        }
        else
        {
            crown.SetActive(false);
        }
        Debug.LogError(npcPoints.Max());
        for (int i = 0; i < npcPoints.Count; i++)
        {
            npcPoints.RemoveAt(npcPoints[i]);
        }
        npcPoints.Clear();

    }
}

