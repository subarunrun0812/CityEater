using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstanceMoveCar : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    [Header("190,0,-8"), SerializeField] private Vector3 point1;
    [SerializeField] private Vector3 point2;

    void Start()
    {
        //InvokeRepeating("関数名,初回呼び出しまでの秒数,次回呼び出しまでの秒数)
        InvokeRepeating("TimeInstantiateCar", 0f, 7f);


    }

    private void TimeInstantiateCar()//一定時間ごとにprefabを生成する
    {

        int random = Random.Range(0, cars.Length);
        Instantiate(cars[random], point1, cars[random].transform.rotation);
    }
}
