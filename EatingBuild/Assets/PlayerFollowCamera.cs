using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player; // playerオブジェクトをアタッチする
    [SerializeField] private float distance = 15.0f; //注視対象プレイヤーからカメラを話す距離
    [SerializeField] private Quaternion vRotation; //カメラの垂直回転(見下ろし回転)
    [SerializeField] private Quaternion hRotation; //カメラの水平回転

}
