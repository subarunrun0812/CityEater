using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItemHuman : MonoBehaviour
{
    [SerializeField] private HumanAppearanceItems humanAppearanceItems;
    void Awake()
    {
        StartCoroutine("DeleteThisObject");
    }
    IEnumerator DeleteThisObject()
    {
        yield return new WaitForSeconds(humanAppearanceItems.itemTime * 2);
        Destroy(this.gameObject);
        Debug.Log(this.gameObject.tag + "削除された");
    }
}
