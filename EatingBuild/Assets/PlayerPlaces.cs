using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaces : MonoBehaviour
{
    [SerializeField] private GameObject[] places;
    void Awake()//Playerのスタート地点をランダムに設定する
    {
        int _random = Random.Range(0, places.Length);
        this.gameObject.transform.position = places[_random].transform.position;
    }
}
