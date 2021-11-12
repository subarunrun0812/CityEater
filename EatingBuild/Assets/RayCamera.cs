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

    private void Update()
    {
        Vector3 _difference = (player.transform.position - this.transform.position);
        Vector3 _direction = _difference.normalized;
        Ray _ray = new Ray(this.transform.position, _direction);
        // //cameraとplayerの距離
        // distance = transform.position - player.transform.position;
        // //レイの設定
        // ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        Debug.DrawRay(this.transform.position, _difference, Color.yellow);
        //レイキャスト（原点、飛ばす方向、衝突した情報、長さ）
        if (Physics.Raycast(ray, out hit))
        {
            // //Rayが当たったオブジェクトのtagがPlayerだったら
            // if (hit.collider.tag == "Player")
            Debug.Log(hit.collider.tag);
        }
    }
}
