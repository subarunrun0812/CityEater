using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSkin : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _changeskin;
    void Awake()//タイトル画面で設定したスキンをロードする
    {
        for (int i = 0; i < _changeskin.Length; i++)//保存したスキンのchangeNumberと同じの場合、それを表示する
        {
            if (i == ChangeSkin.changeNumber)
            {
                _changeskin[i].SetActive(true);
            }
            else
            {
                _changeskin[i].SetActive(false);
            }
        }
    }

}

