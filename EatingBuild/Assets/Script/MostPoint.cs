using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MostPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] npcArray;
    // private List<NPCEatObjectScript> npceatObj_list;
    private List<int> npcp_list = new List<int>();

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject crown;//王冠



    void Start()
    {
        npcp_list.Add(6);
        crown.SetActive(false);
    }

    void Update()
    {
        for (int i = 0; i < npcp_list.Count; i++)
        {
            npcp_list[i] = npcArray[i].GetComponent<NPCEatObjectScript>().point;
            Debug.LogError(npcp_list[i]);
        }
        //npcの最大のpとplayer_pを比較する
        //playerが一番ポイントが高かったら
        if (gameManager.point > npcp_list.Max())
        {
            crown.SetActive(true);
        }
        else
        {
            crown.SetActive(false);
        }
        Debug.LogError(npcp_list.Max());
    }
}

