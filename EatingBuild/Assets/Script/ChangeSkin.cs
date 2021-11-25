using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ChangeSkin : MonoBehaviour//キャラのスキン変更について
{
    [SerializeField]
    private GameObject[] _changeskin;
    // private int skin_number;


    void Start()
    {
        _changeskin[0].SetActive(true);
        Debug.Log(_changeskin.Length);
    }
    public void ChangeSkinButton0()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        _changeskin[0].SetActive(true);
    }
    public void ChangeSkinButton1()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        _changeskin[1].SetActive(true);
    }
    private void Resetchangeskin()//全ての着せ替えを非表示にする
    {
        for (int i = 0; i < _changeskin.Length; i++)
        {
            _changeskin[i].SetActive(false);
        }
    }
}
