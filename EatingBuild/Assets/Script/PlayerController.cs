using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DynamicJoystick joystick;

    [Header("初期のspeedは0.12")]
    public float speed = 0.12f;
    private float oldspeed;

    // public float rotationSpeed = 1f;
    private Vector3 latestPos;  //前回のPosition

    Collider playerCollider;

    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private GameObject description;//最初の説明UI
    private bool flag = false;
    private bool speedFlag = true;
    void Start()
    {
        playerCollider = GetComponent<Collider>();
        playerCollider.isTrigger = true;//IsTriggerをON
        // transform.Rotate(0, 0, 0);//なぜか向きが変わる。このコードがうまくyouいっていない
        description.SetActive(true);
    }

    void FixedUpdate()
    {
        if (this.gameObject.transform.position.y != 0.11f)//プレイヤーが浮いたとき場合、設定したyの値に戻す
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
        else if (x != 0 && z != 0)//ゲーム開始時は自動で動かないようにする
        {
            flag = true;
            description.SetActive(false);
        }
    }

    //Playerがステージ外に出れない処理↓
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Wall")
        {
            if (speedFlag == true)
            {
                oldspeed = speed;
                speedFlag = false;
            }
            playerCollider.isTrigger = false;
            Debug.Log("Wallに当たり、IsTriggerがOFFになった");
            speed = 0.08f;//壁に当たったら強制的にspeedを0.08にする
            Debug.Log(oldspeed);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            playerCollider.isTrigger = false;
            Debug.Log("Wallに当たり、IsTriggerがOFFになった");
            speed = 0.08f;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            playerCollider.isTrigger = true;
            speed = oldspeed;
            Debug.Log(oldspeed);
            speedFlag = true;
        }
    }
}