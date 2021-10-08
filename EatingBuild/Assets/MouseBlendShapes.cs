using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBlendShapes : MonoBehaviour
{
    private SkinnedMeshRenderer blendshape;
    float value = 0;

    void Start()
    {
        blendshape = this.GetComponent<SkinnedMeshRenderer>();
        blendshape.SetBlendShapeWeight(0, 0f);//値をせってい。100は口が開いてる状態
    }

    void Update()
    {
        while (value <= 100)
        {
            blendshape.SetBlendShapeWeight(0, value);//blendshapeの番号 0 をセット,セットする値 100がMAX
            value += 1f;
            Debug.Log("value < 100");
        }
        while (value >= 100)
        {
            blendshape.SetBlendShapeWeight(0, value);//blendshapeの番号 0 をセット,セットする値 100がMAX
            value -= 1f;
            Debug.Log("value >= 100");
        }
    }
}
