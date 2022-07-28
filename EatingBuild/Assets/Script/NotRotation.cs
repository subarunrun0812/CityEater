using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotRotation : MonoBehaviour
{
    Vector3 def;

    void Awake()
    {
        def = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        Vector3 _parent = transform.parent.transform.localRotation.eulerAngles;

        transform.localRotation = Quaternion.Euler(def - _parent);

        Vector3 result = transform.localRotation.eulerAngles;
    }
}
