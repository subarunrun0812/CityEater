using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class crownScript : MonoBehaviour
{

    Vector3 def;

    void Awake()
    {
        def = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        Vector3 _parent = transform.parent.transform.localRotation.eulerAngles;

        //修正箇所
        transform.localRotation = Quaternion.Euler(def - _parent);

        //ログ用
        Vector3 result = transform.localRotation.eulerAngles;
        Debug.Log("def=" + def + "     _parent=" + _parent + "     result=" + result);
    }


    void OnEnable()
    {
        //     //６秒かけてまわり続ける
        //     transform.DOLocalRotate(new Vector3(0, 360f, 0), 1f, RotateMode.FastBeyond360)
        //  .SetEase(Ease.Linear)
        //  .SetLoops(-1, LoopType.Restart);
    }

}
