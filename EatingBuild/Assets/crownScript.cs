using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class crownScript : MonoBehaviour
{
    void OnEnable()
    {
        //６秒かけてまわり続ける
        transform.DOLocalRotate(new Vector3(0, 360f, 0), 2f, RotateMode.FastBeyond360)
     .SetEase(Ease.Linear)
     .SetLoops(-1, LoopType.Restart);
    }
}
