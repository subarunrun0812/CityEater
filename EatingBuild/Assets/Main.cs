using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public DynamicJoystick joystick;
    void Update()
    {
        // ジョイスティックの状態表示
        print("Horizontal: " + joystick.Horizontal);
        print("Vertical: " + joystick.Vertical);
    }
}
