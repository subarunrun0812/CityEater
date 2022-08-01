using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class crownScript : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Transform player;
    public Vector3 offset;
    private Vector3 kero;

    void Update()
    {
        Vector3 addScale = new Vector3(player.transform.localScale.x * 1.5f,
        player.transform.localScale.y * 0.5f, player.transform.localScale.z * 1.5f);
        offset = new Vector3(0, 0f, 0);
        this.transform.position = target.position + offset;
        this.transform.localScale = player.transform.localScale + addScale;
    }

}
