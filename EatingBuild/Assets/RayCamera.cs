using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCamera : MonoBehaviour
{
    [SerializeField, Header("Player")]
    private GameObject player;

    Ray ray;
    RaycastHit hit;//ヒットしたオブジェクト情報

    private Vector3 distance;
    private void Update()
    {
        //cameraとplayerの距離
        distance = transform.position - player.transform.position;
        //レイの設定
        ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        //レイキャスト（原点、飛ばす方向、衝突した情報、長さ）
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
