using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePrefab : MonoBehaviour
{
    // [SerializeField] private GameObject delArea;//prefabを消したい場所

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "5p")//carのgameobject.tag = 5p
        {
            Destroy(col.gameObject);//Carを削除する
            Debug.Log("carを削除した");
        }
    }
}
