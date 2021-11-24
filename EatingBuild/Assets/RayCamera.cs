using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RayCamera : MonoBehaviour
{
    /// <summary>
    /// 被写体を指定してください。
    /// </summary>
    [SerializeField]
    private Transform player;


    [SerializeField] private GameManager gameManager;

    [SerializeField] private EatObjectScript eatObject;

    Ray ray;
    RaycastHit rayhits;//ヒットしたオブジェクト情報
    private GameObject hitobject;//raycastでhitしたGameObjectを代入する



    {
        Vector3 _difference = (player.transform.position - this.transform.position);
    Vector3 _direction = _difference.normalized;//.normalizedベクトルの正規化を行う
    Ray _ray = new Ray(this.transform.position, _direction);
    // Rayが衝突した全てのコライダーの情報を得る
    RaycastHit[] rayCastHits = Physics.RaycastAll(_ray);


        //playerタグに当たったら、配列の中にあるplayer以外のオブジェクトを透明から不透明に戻したい
        // if (hit.collider.tag == "Player")//半透明にしていたGameObjectを不透明に戻す
        // {
        //     // sampleMaterial.NotClearMaterialInvoke();
        //     Debug.Log(sampleMaterial.tag + "が不透明になったよ！成功だね！");
        // }
        if (Physics.Raycast(this.transform.position, _difference, out rayhits))
        {

        if (rayhits.collider.tag == "Player")//半透明にしていたGameObjectを不透明に戻す
        {
            for (int obj = 0; obj < rayCastHits.Length; obj++)
            {

                RaycastHit rayhit = rayCastHits[obj];
                SampleMaterial sampleMaterial = rayhit.collider.GetComponent<SampleMaterial>();////objしたオブジェクトのSampleMaterialコンポーネントを取得
                if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                {
                    rayhit.collider.gameObject.AddComponent<SampleMaterial>();//これの場合 rayhit == Player;
                }

                if (
                rayhit.collider.tag == "10p" && gameManager.point < eatObject.obj10p || rayhit.collider.tag == "12p" && gameManager.point < eatObject.obj12p ||
                rayhit.collider.tag == "15p" && gameManager.point < eatObject.obj15p || rayhit.collider.tag == "20p" && gameManager.point < eatObject.obj20p ||
                rayhit.collider.tag == "30p" && gameManager.point < eatObject.obj30p || rayhit.collider.tag == "50p" && gameManager.point < eatObject.obj50p)
                {
                    sampleMaterial.NotClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                                                            // Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
                }
            }
        }
    }



        for (int obj = 0; obj<rayCastHits.Length; obj++)
        {
            RaycastHit hit = rayCastHits[obj];
    Debug.Log("RaycastAllで" + hit.transform.tag + "があたった");
            SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////objしたオブジェクトのSampleMaterialコンポーネントを取得
            if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
            {
                hit.collider.gameObject.AddComponent<SampleMaterial>();//これの場合 hit == Player;
            }

if (
hit.collider.tag == "10p" && gameManager.point < eatObject.obj10p || hit.collider.tag == "12p" && gameManager.point < eatObject.obj12p ||
hit.collider.tag == "15p" && gameManager.point < eatObject.obj15p || hit.collider.tag == "20p" && gameManager.point < eatObject.obj20p ||
hit.collider.tag == "30p" && gameManager.point < eatObject.obj30p || hit.collider.tag == "50p" && gameManager.point < eatObject.obj50p)
{
    sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                                         // Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
}
        }
    }
}


// else if (hit.collider.tag == "10p" || hit.collider.tag == "12p" || hit.collider.tag == "15p" || hit.collider.tag == "20p"
//             || hit.collider.tag == "30p" || hit.collider.tag == "50p")
// {
//     hitobject = hit.collider.gameObject;
//     SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////hitしたオブジェクトのSampleMaterialコンポーネントを取得
//     if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
//     {
//         hit.collider.gameObject.AddComponent<SampleMaterial>();
//     }
//     sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
//     Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
// }