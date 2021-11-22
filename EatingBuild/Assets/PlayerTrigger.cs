using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{


    [SerializeField] private GameManager gameManager;

    [SerializeField] private EatObjectScript eatobj;//eatobjectscriptを入れる

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "10p" && gameManager.point < eatobj.obj10p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
        else if (col.gameObject.tag == "12p" && gameManager.point < eatobj.obj12p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
        else if (col.gameObject.tag == "15p" && gameManager.point < eatobj.obj15p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
        else if (col.gameObject.tag == "20p" && gameManager.point < eatobj.obj20p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
        else if (col.gameObject.tag == "30p" && gameManager.point < eatobj.obj30p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
        else if (col.gameObject.tag == "50p" && gameManager.point < eatobj.obj50p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
    }




    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "10p" && gameManager.point < eatobj.obj10p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "12p" && gameManager.point < eatobj.obj12p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "15p" && gameManager.point < eatobj.obj15p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "20p" && gameManager.point < eatobj.obj20p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "30p" && gameManager.point < eatobj.obj30p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }

        else if (col.gameObject.tag == "50p" && gameManager.point < eatobj.obj50p)
        {

            SampleMaterial sampleMaterial = col.GetComponent<SampleMaterial>();////colしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                col.gameObject.AddComponent<SampleMaterial>();
            }
            sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
            Debug.Log(col.tag + "が呼ばれたよ。やったー!!!");
        }
    }

}