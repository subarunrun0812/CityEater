using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{


    [SerializeField] private GameManager gameManager;

    // Update is called once per frame

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "10p" && gameManager.point < 800)
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
        if (col.gameObject.tag == "10p" && gameManager.point < 800)
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