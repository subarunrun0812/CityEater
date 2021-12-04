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
    public int changeNumber;//


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
        SaveDate();
    }
    public void ChangeSkinButton1()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 1;
        _changeskin[1].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    public void ChangeSkinButton2()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 2;
        _changeskin[2].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    public void ChangeSkinButton3()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 3;
        _changeskin[3].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }

    public void ChangeSkinButton4()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 4;
        _changeskin[4].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    private void Resetchangeskin()//全ての着せ替えを非表示にする
    {
        for (int i = 0; i < _changeskin.Length; i++)
        {
            _changeskin[i].SetActive(false);
        }
    }

    public void SaveDate()
    {
        //変更したスキンの要素の順番をPlayerPrefsで記憶する
        PlayerPrefs.SetInt("ChangeNumber", changeNumber);
        PlayerPrefs.Save();
    }
}
