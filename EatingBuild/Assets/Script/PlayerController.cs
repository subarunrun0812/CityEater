using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DynamicJoystick joystick;

    [Header("初期のspeedは0.08")]
    public float speed = 0.08f;
    // public float rotationSpeed = 1f;
    private Vector3 latestPos;  //前回のPosition

    Collider playerCollider;


    void Start()
    {
        playerCollider = GetComponent<Collider>();
        playerCollider.isTrigger = true;//IsTriggerをON
        // transform.Rotate(0, 0, 0);//なぜか向きが変わる。このコードがうまくyouいっていない
    }
    void FixedUpdate()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;
        transform.position += new Vector3(x * speed, 0, z * speed);

        // Vector3 movementDirection = new Vector3(x, 0, z);
        // movementDirection.Normalize();
        // this.transform.Translate(movementDirection * speed, Space.World);
        // if (movementDirection != Vector3.zero)
        // {
        //     Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
        // }

        // this.transform.Rotate(new Vector3(0, speed * joystick.Horizontal, 0));

        Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新
        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }


        if (this.gameObject.transform.position.y != 0)//y =0にする
        {
            Vector3 playerPos = this.transform.position;
            playerPos.y = 0.0f;
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Wall")
        {
            playerCollider.isTrigger = false;
            Debug.Log("Wallに当たり、IsTriggerがOFFになった");
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "WallCollider")
        {
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