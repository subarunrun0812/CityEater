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
        }
        else if (col.gameObject.tag == "AT")
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "INCR")
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "DEC")
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "QUESTION")
        {
            Destroy(col.gameObject);
        }
    }
}
