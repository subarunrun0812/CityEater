using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine("DeleteThisObject");
    }
    IEnumerator DeleteThisObject()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
        Debug.Log(this.gameObject.tag + "削除された");
    }
}
