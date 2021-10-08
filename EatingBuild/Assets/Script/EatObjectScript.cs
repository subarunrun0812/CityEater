using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EatObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("cube"))
        {
            col.transform.DOScale(new Vector3(0.5f, 0.5f), 3f);
        }
    }

    private void EatBuildScale()//オブジェクトを回転＆小さくしてdeleteする
    {

    }
}
