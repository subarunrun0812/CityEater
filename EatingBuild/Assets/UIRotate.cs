using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIRotate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private NPCEatObjectScript nPCEatObject;
    void Update()
    {
        _text.text = $"{nPCEatObject.npc_level}";
    }
    void LateUpdate()
    {
        //カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;
    }

}
