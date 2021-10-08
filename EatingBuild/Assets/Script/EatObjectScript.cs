using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EatObjectScript : MonoBehaviour
{

    [SerializeField] private int smallTime = 2;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("cube"))
        {
            col.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), smallTime)
            .OnComplete(() =>//dotween終了後、cubeを消す
            {
                col.gameObject.SetActive(false);
                Debug.Log("消えた");
            });
        }

    }
}