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

    Ray ray;
    RaycastHit hit;//ヒットしたオブジェクト情報


    private GameObject hitobject;//raycastでhitしたGameObjectを代入する

    void Update()
    {
        Vector3 _difference = (player.transform.position - this.transform.position);
        Vector3 _direction = _difference.normalized;//.normalizedベクトルの正規化を行う
        Ray _ray = new Ray(this.transform.position, _direction);

        if (Physics.Raycast(this.transform.position, _difference, out hit))
        {

            if (hit.collider.tag == "Player")//半透明にしていたGameObjectを不透明に戻す
            {
                //10p~50pでヒットしたオブジェクトhitobject変数に代入しているため、前rayがhitしていたオブジェクトに参照ができる
                hitobject.GetComponent<SampleMaterial>().NotClearMaterialInvoke();
                Debug.Log(hit.collider.tag + "が不透明になったよ！成功だね！");

            }
            else if (hit.collider.tag == "10p")
            {
                if (gameManager.point < 800)
                {
                    hitobject = hit.collider.gameObject;
                    SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////hitしたオブジェクトのSampleMaterialコンポーネントを取得
                    if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                    {
                        hit.collider.gameObject.AddComponent<SampleMaterial>();
                    }
                    sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                    Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
                }
                else
                {
                    //なにもしない
                }
            }
            else if (hit.collider.tag == "10p")
            {
                if (gameManager.point < 800)
                {
                    hitobject = hit.collider.gameObject;
                    SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////hitしたオブジェクトのSampleMaterialコンポーネントを取得
                    if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                    {
                        hit.collider.gameObject.AddComponent<SampleMaterial>();
                    }
                    sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                    Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
                }
                else
                {
                    //なにもしない
                }
            }
            else if (hit.collider.tag == "12p")
            {
                if (gameManager.point < 1500)
                {
                    hitobject = hit.collider.gameObject;
                    SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////hitしたオブジェクトのSampleMaterialコンポーネントを取得
                    if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                    {
                        hit.collider.gameObject.AddComponent<SampleMaterial>();
                    }
                    sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                    Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
                }
                else
                {
                    //なにもしない
                }

            }
            else if (hit.collider.tag == "15p")
            {
                if (gameManager.point < 3000)
                {
                    hitobject = hit.collider.gameObject;
                    SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////hitしたオブジェクトのSampleMaterialコンポーネントを取得
                    if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                    {
                        hit.collider.gameObject.AddComponent<SampleMaterial>();
                    }
                    sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                    Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
                }
                else
                {
                    //なにもしない
                }

            }
            else if (hit.collider.tag == "20p")
            {
                if (gameManager.point < 5000)
                {
                    hitobject = hit.collider.gameObject;
                    SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////hitしたオブジェクトのSampleMaterialコンポーネントを取得
                    if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                    {
                        hit.collider.gameObject.AddComponent<SampleMaterial>();
                    }
                    sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                    Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
                }
                else
                {
                    //なにもしない
                }

            }
            else if (hit.collider.tag == "30p")
            {
                if (gameManager.point < 5000)
                {
                    hitobject = hit.collider.gameObject;
                    SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////hitしたオブジェクトのSampleMaterialコンポーネントを取得
                    if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                    {
                        hit.collider.gameObject.AddComponent<SampleMaterial>();
                    }
                    sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                    Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
                }
                else
                {
                    //なにもしない
                }

            }
            else if (hit.collider.tag == "50p")
            {
                if (gameManager.point < 5000)
                {
                    hitobject = hit.collider.gameObject;
                    SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();////hitしたオブジェクトのSampleMaterialコンポーネントを取得
                    if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                    {
                        hit.collider.gameObject.AddComponent<SampleMaterial>();
                    }
                    sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                    Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
                }
                else
                {
                    //なにもしない
                }

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
