using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DynamicJoystick joystick;
    public float speed = 0.3f;
    private Vector3 latestPos;  //前回のPosition

    Collider playerCollider;


    void Start()
    {
        playerCollider = GetComponent<Collider>();
        playerCollider.isTrigger = true;//IsTriggerをON
        // transform.Rotate(0, 0, 0);//なぜか向きが変わる。このコードがうまくいっていない
    }
    void Update()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;
        transform.position += new Vector3(x * speed, 0, z * speed);

        Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新
        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliderに当たった");
        if (other.gameObject.tag == "Wall")
        {
            playerCollider.isTrigger = false;
            Debug.Log("Wallに当たり、IsTriggerがOFFになった。");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            playerCollider.isTrigger = true;
            Debug.Log("Wallから離れ、IsTriggerがONになった");
        }
    }
}