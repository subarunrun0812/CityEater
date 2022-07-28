using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{


    [SerializeField] private GameManager gameManager;

    [SerializeField] private EatObjectScript eatobj;//eatobjectscriptを入れる

    //街のオブジェクト全てに半透明に出来るスクリプトを追加する。。
    void Awake()
    {
        GameObject[] obj2p = GameObject.FindGameObjectsWithTag("2p");
        foreach (var item in obj2p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj3p = GameObject.FindGameObjectsWithTag("3p");
        foreach (var item in obj3p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj4p = GameObject.FindGameObjectsWithTag("4p");
        foreach (var item in obj4p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj5p = GameObject.FindGameObjectsWithTag("5p");
        foreach (var item in obj5p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj8p = GameObject.FindGameObjectsWithTag("8p");
        foreach (var item in obj8p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj10p = GameObject.FindGameObjectsWithTag("10p");
        foreach (var item in obj10p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj12p = GameObject.FindGameObjectsWithTag("12p");
        foreach (var item in obj12p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj15p = GameObject.FindGameObjectsWithTag("15p");
        foreach (var item in obj15p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj20p = GameObject.FindGameObjectsWithTag("20p");
        foreach (var item in obj20p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj30p = GameObject.FindGameObjectsWithTag("30p");
        foreach (var item in obj30p)
        {
            item.AddComponent<SampleMaterial>();
        }
        GameObject[] obj50p = GameObject.FindGameObjectsWithTag("50p");
        foreach (var item in obj50p)
        {
            item.AddComponent<SampleMaterial>();
        }
    }
    void OnTriggerEnter(Collider col)
    {
        SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();
        if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
        {
            col.gameObject.AddComponent<SampleMaterial>();
        }

        if (col.gameObject.tag == "2p" && gameManager.point < eatobj.obj2p || col.gameObject.tag == "3p" && gameManager.point < eatobj.obj3p ||
            col.gameObject.tag == "4p" && gameManager.point < eatobj.obj4p || col.gameObject.tag == "5p" && gameManager.point < eatobj.obj5p ||
            col.gameObject.tag == "8p" && gameManager.point < eatobj.obj8p || col.gameObject.tag == "10p" && gameManager.point < eatobj.obj10p ||
            col.gameObject.tag == "12p" && gameManager.point < eatobj.obj12p || col.gameObject.tag == "15p" && gameManager.point < eatobj.obj15p ||
            col.gameObject.tag == "20p" && gameManager.point < eatobj.obj20p || col.gameObject.tag == "30p" && gameManager.point < eatobj.obj30p ||
            col.gameObject.tag == "50p" && gameManager.point < eatobj.obj50p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
        }
    }

    void OnTriggerExit(Collider col)
    {
        SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();
        if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
        {
            col.gameObject.AddComponent<SampleMaterial>();
        }
        if (col.gameObject.tag == "2p" && gameManager.point < eatobj.obj2p || col.gameObject.tag == "3p" && gameManager.point < eatobj.obj3p ||
            col.gameObject.tag == "4p" && gameManager.point < eatobj.obj4p || col.gameObject.tag == "5p" && gameManager.point < eatobj.obj5p ||
            col.gameObject.tag == "8p" && gameManager.point < eatobj.obj8p || col.gameObject.tag == "10p" && gameManager.point < eatobj.obj10p ||
            col.gameObject.tag == "12p" && gameManager.point < eatobj.obj12p || col.gameObject.tag == "15p" && gameManager.point < eatobj.obj15p ||
            col.gameObject.tag == "20p" && gameManager.point < eatobj.obj20p || col.gameObject.tag == "30p" && gameManager.point < eatobj.obj30p ||
            col.gameObject.tag == "50p" && gameManager.point < eatobj.obj50p)
        {
            sampleMaterial.NotClearMaterialInvoke();//NotClearMaterialInvoke関数を呼び出す
        }


    }

}