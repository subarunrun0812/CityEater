using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{


    [SerializeField] private GameManager gameManager;

    [SerializeField] private EatObjectScript eatobj;//eatobjectscriptを入れる

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
        SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
        if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
        {
            col.gameObject.AddComponent<SampleMaterial>();
        }

        if (col.gameObject.tag == "2p" && gameManager.point < eatobj.obj2p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "3p" && gameManager.point < eatobj.obj3p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "4p" && gameManager.point < eatobj.obj4p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "5p" && gameManager.point < eatobj.obj5p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "8p" && gameManager.point < eatobj.obj8p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "10p" && gameManager.point < eatobj.obj10p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "12p" && gameManager.point < eatobj.obj12p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "15p" && gameManager.point < eatobj.obj15p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "20p" && gameManager.point < eatobj.obj20p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "30p" && gameManager.point < eatobj.obj30p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "50p" && gameManager.point < eatobj.obj50p)
        {
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
    }




    void OnTriggerExit(Collider col)
    {
        SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
        if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
        {
            col.gameObject.AddComponent<SampleMaterial>();
        }
        if (col.gameObject.tag == "2p" && gameManager.point < eatobj.obj2p)
        {
            sampleMaterial.NotClearMaterialInvoke();//NotClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "3p" && gameManager.point < eatobj.obj3p)
        {
            sampleMaterial.NotClearMaterialInvoke();//NotClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "4p" && gameManager.point < eatobj.obj4p)
        {
            sampleMaterial.NotClearMaterialInvoke();//NotClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "5p" && gameManager.point < eatobj.obj5p)
        {
            sampleMaterial.NotClearMaterialInvoke();//NotClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "8p" && gameManager.point < eatobj.obj8p)
        {
            sampleMaterial.NotClearMaterialInvoke();//NotClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
        else if (col.gameObject.tag == "10p" && gameManager.point < eatobj.obj10p)
        {
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "12p" && gameManager.point < eatobj.obj12p)
        {
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "15p" && gameManager.point < eatobj.obj15p)
        {
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "20p" && gameManager.point < eatobj.obj20p)
        {
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "30p" && gameManager.point < eatobj.obj30p)
        {
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "50p" && gameManager.point < eatobj.obj50p)
        {
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
    }

}