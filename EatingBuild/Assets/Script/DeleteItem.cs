using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    [SerializeField] private AppearanceItems appearanceItems;
    void Awake()
    {
        StartCoroutine("DeleteThisObject");
    }
    IEnumerator DeleteThisObject()
    {
        yield return new WaitForSeconds(appearanceItems.itemTime * 2);// * n,4/n 常時表示アイテムを表示される数
        Destroy(this.gameObject);
        Debug.Log(this.gameObject.tag + "削除された");
    }
}
