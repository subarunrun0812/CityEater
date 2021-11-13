using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCamera : MonoBehaviour
{
    /// <summary>
    /// 被写体を指定してください。
    /// </summary>
    [SerializeField]
    private Transform player;

    Ray ray;
    RaycastHit hit;//ヒットしたオブジェクト情報

    // private Vector3 distance;
    private GameObject hitobject;//raycastでhitしたGameObjectを代入する

    void Update()
    {
        Vector3 _difference = (player.transform.position - this.transform.position);
        Vector3 _direction = _difference.normalized;//.normalizedベクトルの正規化を行う
        Ray _ray = new Ray(this.transform.position, _direction);

        if (Physics.Raycast(this.transform.position, _difference, out hit))
        {
            Debug.Log(hit.collider.tag);

            if (hit.collider.tag == "Player")//半透明にしていたGameObjectを不透明に戻す
            {

                hitobject.GetComponent<SampleMaterial>().NotClearMaterialInvoke();
                Debug.Log(hit.collider.tag + "が不透明になったよ！成功だね！");
            }
            else if (hit.collider.tag == "50p")
            {
                hitobject = hit.collider.gameObject;
                hit.collider.GetComponent<SampleMaterial>().ClearMaterialInvoke();
                Debug.Log(hit.collider.tag + "が呼ばれたよ。やったー!!!");
            }

        }
    }
}


//レイキャスト（原点、飛ばす方向、衝突した情報、長さ）
// Debug.DrawRay(this.transform.position, _difference, Color.yellow);
// Debug.DrawRay(this.transform.position, _difference, Color.red);

// //Rayが当たったオブジェクトのtagがPlayerだったら
// if (hit.collider.tag == "Player")