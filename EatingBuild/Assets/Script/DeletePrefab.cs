using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//巡回しているアイテムと車を削除するスクリプト
public class DeletePrefab : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "5p")//carのgameobject.tag = 5p
        {
            Destroy(col.gameObject);
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
