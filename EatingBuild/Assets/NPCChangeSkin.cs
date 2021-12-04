using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChangeSkin : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _changeskin;

    private int npcRandomNumber;
    void Start()
    {
        npcRandomNumber = Random.Range(0, _changeskin.Length);
        for (int i = 0; i < _changeskin.Length; i++)
        {
            if (i == npcRandomNumber)
            {
                _changeskin[i].SetActive(true);
            }
            else
            {
                _changeskin[i].SetActive(false);
            }
        }
    }
}
