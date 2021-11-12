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

    void Update()
    {
        Vector3 _difference = (player.transform.position - this.transform.position);//cameraとplayerの距離
        Vector3 _direction = _difference.normalized;//.normalizedベクトルの正規化を行う方法の紹介です。
        Ray _ray = new Ray(this.transform.position, _direction);

        Debug.DrawRay(this.transform.position, _direction, Color.yellow);
        //レイキャスト（原点、飛ばす方向、衝突した情報、長さ）
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.tag);
            // //Rayが当たったオブジェクトのtagがPlayerだったら
            // if (hit.collider.tag == "Player")
        }
    }
}
