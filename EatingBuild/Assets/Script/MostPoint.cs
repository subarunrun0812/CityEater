using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MostPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] npcArray;
    // private List<NPCEatObjectScript> npceatObj_list;
    private List<int> npc_list = new List<int>();
    private List<NPCEatObjectScript> npcObjlist = new List<NPCEatObjectScript>();

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject crown;//王冠



    void Start()
    {
        npc_list.Add(6);
        crown.SetActive(false);
        for (int i = 0; i < npcObjlist.Count; i++)
        {
            npcObjlist[i] = npcArray[i].GetComponent<NPCEatObjectScript>();
            Debug.LogError(npc_list[i]);
        }
    }

    void Update()
    {
        for (int i = 0; i < npcObjlist.Count; i++)
        {
            npc_list[i] = npcObjlist[i].point;
            Debug.LogError(npcObjlist[i]);
        }
        //npcの最大のpとplayer_pを比較する
        //playerが一番ポイントが高かったら
        if (gameManager.point > npc_list.Max())
        {
            crown.SetActive(true);
        }
        else
        {
            crown.SetActive(false);
        }
        Debug.LogError(npc_list.Max());
    }
}

