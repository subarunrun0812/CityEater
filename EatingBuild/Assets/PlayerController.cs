using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float up = 0.1f;
    float right = 0.1f;

    // 辞書型の変数を使ってます。
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"up", false },
        {"down", false },
        {"right", false },
        {"left", false },
    };

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move["up"] = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        move["down"] = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        move["right"] = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        move["left"] = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    }

    void FixedUpdate()//移動処理のためFixedUpdateを
    {
        if (move["up"])
        {
            transform.Translate(0f, 0f, up);
        }
        if (move["down"])
        {
            transform.Translate(0f, 0f, -up);
        }
        if (move["right"])
        {
            transform.Translate(right, 0f, 0f);
        }
        if (move["left"])
        {
            transform.Translate(-right, 0f, 0f);
        }
    }
}
