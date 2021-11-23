using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{


    [SerializeField] private GameManager gameManager;

    [SerializeField] private EatObjectScript eatobj;//eatobjectscriptを入れる

    void OnTriggerEnter(Collider col)
    {
        SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
        if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
        {
            col.gameObject.AddComponent<SampleMaterial>();
        }

        if (col.gameObject.tag == "10p" && gameManager.point < eatobj.obj10p)
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
        if (col.gameObject.tag == "10p" && gameManager.point < eatobj.obj10p)
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