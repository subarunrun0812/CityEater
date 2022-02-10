using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItemHuman : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine("DeleteThisObject");
    }
    IEnumerator DeleteThisObject()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
        Debug.Log(this.gameObject.tag + "削除された");
    }
}
