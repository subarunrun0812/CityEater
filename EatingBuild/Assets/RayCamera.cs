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

    GameObject[] prevRaycast;//透明にしたGameObjectをいれる



    void Update()
    {
        Vector3 _difference = (player.transform.position - this.transform.position);
        Vector3 _direction = _difference.normalized;//.normalizedベクトルの正規化を行う
        Ray _ray = new Ray(this.transform.position, _direction);
        // Rayが衝突した全てのコライダーの情報を得る
        RaycastHit[] rayCastHits = Physics.RaycastAll(_ray);

        foreach (var item in prevRaycast)
        {

        }



        for (int index = 0; index < rayCastHits.Length; index++)
        {
            RaycastHit hit = rayCastHits[index];
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
                //     for (int i = 0; i < hit.length; i++)//透~明にしたオブジェクトを格納する
                //     {
                //         RaycastHit prevRaycast[] =
                //    }
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