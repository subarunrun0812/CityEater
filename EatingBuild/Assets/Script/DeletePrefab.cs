using UnityEngine;

//巡回しているアイテムと車を削除するスクリプト
public class DeletePrefab : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        //carのgameobject.tag = 5p
        if (col.gameObject.tag == "5p" || col.gameObject.tag == "AT" ||
            col.gameObject.tag == "INCR" || col.gameObject.tag == "DEC" ||
            col.gameObject.tag == "QUESTION")
        {
            Destroy(col.gameObject);
        }
    }
}
