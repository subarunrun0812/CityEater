using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ChangeSkin : MonoBehaviour//キャラのスキン変更について
{
    [SerializeField]
    private GameObject[] _changeskin;
    // private int skin_number;

    //スキンをアンロックしセーブする時にint型の変数を使ったら楽そうだから
    public static int changeNumber;//staticはシーン遷移しても保存させる


    void Start()//初期は0番目のスキン
    {
        changeNumber = 0;
        _changeskin[0].SetActive(true);
        Debug.Log(_changeskin.Length);
    }
    public void ChangeSkinButton0()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 0;
        _changeskin[0].SetActive(true);
        Debug.Log(changeNumber);
    }
    public void ChangeSkinButton1()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 1;
        _changeskin[1].SetActive(true);
        Debug.Log(changeNumber);
    }
    public void ChangeSkinButton2()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 2;
        _changeskin[2].SetActive(true);
        Debug.Log(changeNumber);

    }
    private void Resetchangeskin()//全ての着せ替えを非表示にする
    {
        for (int i = 0; i < _changeskin.Length; i++)
        {
            _changeskin[i].SetActive(false);
        }
    }
}
