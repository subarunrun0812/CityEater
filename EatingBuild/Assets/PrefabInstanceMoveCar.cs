using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstanceMoveCar : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    // [Header("190,0,-8 または -150,0,-2"), SerializeField] private Vector3 places;

    void Start()
    {
        //InvokeRepeating("関数名,初回呼び出しまでの秒数,次回呼び出しまでの秒数)
        InvokeRepeating("TimeInstantiateCar", 5f, 7f);
    }

    private void TimeInstantiateCar()//一定時間ごとにprefabを生成する
    {
        int random = Random.Range(0, cars.Length);//
        Instantiate(cars[random], this.transform.position, cars[random].transform.rotation);
    }
}
