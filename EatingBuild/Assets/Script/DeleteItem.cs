using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    [SerializeField] private int Blinking = 5;

    private GameObject child;
    void Awake()
    {
        //子オブジェクトの順番で取得。最初が0で二番目が1となる。つまり↓は最初の子オブジェクト
        child = transform.GetChild(0).gameObject;
        StartCoroutine("DeleteThisObject");
    }
    IEnumerator DeleteThisObject()
    {
        yield return new WaitForSeconds(10f);//12f


        for (int i = 0; i < 6; i++)//2.4秒
        {
            //一周するのに0.4秒
            child.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            child.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
        // for (int i = 0; i < 4; i++)//1.2秒
        // {
        //     //一周するのに0.3秒
        //     child.SetActive(false);
        //     yield return new WaitForSeconds(0.15f);
        //     child.SetActive(true);
        //     yield return new WaitForSeconds(0.15f);
        // }

        Destroy(this.gameObject);
        Debug.Log(this.gameObject.tag + "削除された");
    }

}
