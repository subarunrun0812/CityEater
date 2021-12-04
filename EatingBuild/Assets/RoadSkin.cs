using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSkin : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _changeskin;
    private int changeNumber;//skinの要素が何番目かロードする時に使う
    void Awake()//タイトル画面で設定したスキンをロードする
    {
        changeNumber = PlayerPrefs.GetInt("ChangeNumber", 1);//PlayerPrefs.GetInt(保存した時に使ったキーデフォルト値,データが保存されなかった時に表示する値)
        for (int i = 0; i < _changeskin.Length; i++)//保存したスキンのchangeNumberと同じの場合、そを表示する
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

