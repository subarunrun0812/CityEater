using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class RayCamera : MonoBehaviour
{
    /// <summary>
    /// 被写体を指定してください。
    /// </summary>
    [SerializeField]
    private Transform player;

    [SerializeField] private GameManager gameManager;

    RaycastHit hit;//ヒットしたオブジェクト情報

    List<string> RayItemList = new List<string>();//ヒットしたオブジェクトを格納するリスト型

    private GameObject hitobject;//raycastでhitしたGameObjectを代入する

    /// 今回の Update で検出された遮蔽物の Renderer コンポーネント。
    public List<GameObject> gameObjectsList = new List<GameObject>();

    public GameObject[] gameObjectsPreves_;

    void Update()
    {
        Vector3 _difference = (player.transform.position - this.transform.position);
        Vector3 _direction = _difference.normalized;//.normalizedベクトルの正規化を行う
        Ray ray = new Ray(this.transform.position, _direction);
        RaycastHit[] _hits = Physics.RaycastAll(ray);
        gameObjectsPreves_ = gameObjectsList.ToArray();
        gameObjectsList.Clear();


        foreach (RaycastHit hit in _hits)
        {
            RayItemList.Add(hit.collider.tag);//hitしたゲームタグを追加する
            Debug.Log("RayItemList" + RayItemList);
            Debug.Log("ヒットしたGameObject.tagは" + hit.collider.tag);
            Debug.Log("RayItemListは" + RayItemList.Count);

            if (hit.collider.tag == "Player")//半透明にしていたGameObjectを不透明に戻す
            {
                //10p~50pでヒットしたオブジェクトhitobject変数に代入しているため、前rayがhitしていたオブジェクトに参照ができる
                hitobject.GetComponent<SampleMaterial>().NotClearMaterialInvoke();
                Debug.Log(hit.collider.tag + "が不透明になったよ！成功だね！");
                RayItemList.Clear();

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

            }
            else if (hit.collider.tag == "30p")
            {
                if (gameManager.point < 8000)
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

            }
            else if (hit.collider.tag == "50p")
            {
                if (gameManager.point < 8000)
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

            }

        }
        foreach (GameObject hitgameObject in gameObjectsPreves_.Except<GameObject>(gameObjectsList))
        {
            ////hitしたオブジェクトのSampleMaterialコンポーネントを取得
            SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();
            if (sampleMaterial != null)
            {
                sampleMaterial.NotClearMaterialInvoke();
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
