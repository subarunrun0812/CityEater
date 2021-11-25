using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ChangeSkin : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _changeskin;
    private int skin_number;


    void Start()
    {
        skin_number = 0;
        _changeskin[0].SetActive(true);
    }
    public void ChangeSkin_1()
    {

    }
    void Update()
    {
        //なにも設定されていないときに返します
        if (_changeskin.Length == 0)
            return;


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            skin_number++;
            _changeskin[skin_number].SetActive(true);
        }

    }
}
