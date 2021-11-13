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

    Ray ray;
    RaycastHit hit;//ヒットしたオブジェクト情報

    private GameObject hitobject;//raycastでhitしたGameObjectを代入する

    void Update()
    {
        Vector3 _difference = (player.transform.position - this.transform.position);
        Vector3 _direction = _difference.normalized;//.normalizedベクトルの正規化を行う
        Ray _ray = new Ray(this.transform.position, _direction);
        var raycastHits = new RaycastHit[5];//// 当たり判定の結果を格納する変数を事前に確保しておく

        if (Physics.Raycast(this.transform.position, _difference, out hit))
        {
            Debug.Log(hit.collider.tag);

            var hitCount = Physics.RaycastNonAlloc(this.transform.position, _difference, raycastHits); // 結果は事前に確保したhitに前方から順番に書き込みされます
            var length = raycastHits.Length;
            Debug.Log("raycastHit配列は" + raycastHits);
            Debug.Log("hitCountは" + hitCount);
            if (hit.collider.tag == "Player")//半透明にしていたGameObjectを不透明に戻す
            {
                //10p~50pでヒットしたオブジェクトhitobject変数に代入しているため、前rayがhitしていたオブジェクトに参照ができる
                hitobject.GetComponent<SampleMaterial>().NotClearMaterialInvoke();
                Debug.Log(hit.collider.tag + "が不透明になったよ！成功だね！");
                // 配列をクリアします。
                Array.Clear(raycastHits, 0, length);
                Debug.Log("配列をクリアにした");
            }
            // for (int i = 0; i < hitCount; i++)
            // {

            // }
            else if (hit.collider.tag == "10p")
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
            else if (hit.collider.tag == "12p")
            {
                hitobject = hit.collider.gameObject;
                SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();
                if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                {
                    hit.collider.gameObject.AddComponent<SampleMaterial>();
                }
                sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
            }
            else if (hit.collider.tag == "15p")
            {
                hitobject = hit.collider.gameObject;
                SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();
                if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                {
                    hit.collider.gameObject.AddComponent<SampleMaterial>();
                }
                sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
            }
            else if (hit.collider.tag == "20p")
            {
                hitobject = hit.collider.gameObject;
                SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();
                if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                {
                    hit.collider.gameObject.AddComponent<SampleMaterial>();
                }
                sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
            }
            else if (hit.collider.tag == "30p")
            {
                hitobject = hit.collider.gameObject;
                SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();
                if (sampleMaterial == null)//もし、sampleMaterialスクリプトがついていなかったら追加する
                {
                    hit.collider.gameObject.AddComponent<SampleMaterial>();
                }
                sampleMaterial.ClearMaterialInvoke();//ClearMaterialInvoke関数を呼び出す
                Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
            }
            else if (hit.collider.tag == "50p")
            {
                hitobject = hit.collider.gameObject;
                SampleMaterial sampleMaterial = hit.collider.GetComponent<SampleMaterial>();
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


//レイキャスト（原点、飛ばす方向、衝突した情報、長さ）
// Debug.DrawRay(this.transform.position, _difference, Color.yellow);
// Debug.DrawRay(this.transform.position, _difference, Color.red);

// //Rayが当たったオブジェクトのtagがPlayerだったら
// if (hit.collider.tag == "Player")