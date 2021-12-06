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

    [SerializeField] private Rigidbody rigidbody;

    private bool flag = false;

    void Start()
    {
        playerCollider = GetComponent<Collider>();
        playerCollider.isTrigger = true;//IsTriggerをON
        // transform.Rotate(0, 0, 0);//なぜか向きが変わる。このコードがうまくyouいっていない
    }

    void FixedUpdate()
    {
        if (this.gameObject.transform.position.y != 0.11f)//y =0にする
        {
            Vector3 playerPos = this.transform.position;
            playerPos.y = 0.11f;
        }

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
        if (x == 0 && z == 0 && flag == true)//joystickで操作していない間
        {
            transform.Translate(Vector3.forward * speed);//常に前に進み続ける処理
        }
        else if (x != 0 && z != 0)//最初は自動で動かないようにする
        {
            flag = true;
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
    void OnTriggerStay(Collider other)
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