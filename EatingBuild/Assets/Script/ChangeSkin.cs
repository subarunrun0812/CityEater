using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour//キャラのスキン変更について
{

    [SerializeField]
    private GameObject[] _changeskin;


    public static int changeNumber;//demoシーンで同期させるためにstatic修飾子を使う


    void Awake()
    {
        changeNumber = PlayerPrefs.GetInt("ChangeNumber");//ロードする

        LoadSkin();
        //ユ―ザーネームがあるかチェック
        if (PlayerPrefs.HasKey("ChangeNumber"))
        {
            Debug.Log("スキンの順番のデータがあるよ！");
        }
        else
        {
            Debug.Log("スキンの順番のデータがないよ！");
            //ない場合名前を入力させる処理をここから入れる
        }
    }
    void Start()//初期は0番目のスキン
    {
        // Debug.Log(_changeskin.Length);
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
    public void ChangeSkinButton5()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 5;
        _changeskin[5].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    public void ChangeSkinButton6()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 6;
        _changeskin[6].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    public void ChangeSkinButton7()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 7;
        _changeskin[7].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    public void ChangeSkinButton8()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 8;
        _changeskin[8].SetActive(true);
        Debug.Log(changeNumber);
        SaveDate();
    }
    public void ChangeSkinButton9()//buttonを押したらスキンが変わっていく
    {
        Resetchangeskin();
        changeNumber = 9;
        _changeskin[9].SetActive(true);
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
    private void LoadSkin()//スキンをロードする
    {
        for (int i = 0; i < _changeskin.Length; i++)
        {
            if (i == changeNumber)
            {
                _changeskin[i].SetActive(true);
            }
            else
            {
                _changeskin[i].SetActive(false);
            }
        }
    }

    public void SaveDate()//スキンを保存する
    {
        //変更したスキンの要素の順番をPlayerPrefsで記憶する
        PlayerPrefs.SetInt("ChangeNumber", changeNumber);
        PlayerPrefs.Save();
    }
}
