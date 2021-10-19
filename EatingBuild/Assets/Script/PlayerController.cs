using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;//移動方向
    [SerializeField] private float moveSpeed = 5f;//移動速度

    void Update()
    {
        //WASD入力から、XZ平面（水平な地面）を移動する方向（velocity）を得ます
        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            velocity.z += 1;
        if (Input.GetKey(KeyCode.S))
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;

        //速度ベクトルの長さを１秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;


        //いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            //プレイヤーの位置(transform.position)の更新
            //移動方向ベクトル(velocity)を足しこみます
            transform.position += velocity;
        }
    }
}