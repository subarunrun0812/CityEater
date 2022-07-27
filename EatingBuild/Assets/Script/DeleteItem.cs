using System.Collections;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    private int maximumNum = 2;//アイテムを表示する最大数
    [SerializeField] private AppearanceItems appearanceItems;
    void Awake()
    {
        StartCoroutine("DeleteThisObject");
    }
    IEnumerator DeleteThisObject()
    {
        yield return new WaitForSeconds(appearanceItems.itemTime * maximumNum);
        Destroy(this.gameObject);
        Debug.Log(this.gameObject.tag + "削除された");
    }
}
