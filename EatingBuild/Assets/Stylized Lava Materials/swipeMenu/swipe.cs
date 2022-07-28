using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=xBxvqxsxdR8
//↑この動画を見て作り、コードの全ての解読は出来なかったため、説明できません。
public class swipe : MonoBehaviour
{
    public Color[] colors; // 下の小さいボタンの通常時の色 または 選択(拡大)された時の色
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    private bool runIt = false;
    private float time;
    private Button takeTheBtn;
    int btnNumber;

    [SerializeField] private ChangeSkin changeSkinScript;
    private GameObject[] _changeskin;
    void Start()
    {
        _changeskin = changeSkinScript._changeskin;
    }
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);//横幅か間隔？？ (例)pos = 3 の時、2分の1

        if (runIt)
        {
            GecisiDuzenle(distance, pos, takeTheBtn);
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }

        //子オブジェクト(スキンの種類 or ボタン)の数で次のボタンまでの間隔を決める
        for (int i = 0; i < pos.Length; i++)
        {
            //子オブジェクトが少ないほど、感覚が広くなる
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))//もし、マウスの左クリックしたとき
        {
            ///<summary>
            ///スクロールバーの現在値。0 と 1 の間で表現されます。
            ///</summary>
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {

                //ずっと呼ばれているけど、なにかわからない
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        // .Lerp(始点となるベクトル位置（型：Vector3）,終点となるベクトル位置（型：Vector3), 両端の距離を1とした時の割合（型：float, 0~1の範囲のみ）

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                Debug.LogWarning("Current Selected Level" + i);//何番目のButtonを表示しているか、コンソールに表示する

                //スキンの画像が選択(拡大)された時の大きさ。
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.9f, 0.7f), 0.1f);

                //大きくした画像のskinを表示する
                for (int m = 0; m < _changeskin.Length; m++)
                {
                    if (m == i)
                    {
                        if (m == 3)
                        {
                            changeSkinScript.ChangeSkinButton3();
                        }
                        else if (m == 4)
                        {
                            changeSkinScript.ChangeSkinButton4();
                        }
                        else if (m == 5)
                        {
                            changeSkinScript.ChangeSkinButton5();
                        }
                        else if (m == 6)
                        {
                            changeSkinScript.ChangeSkinButton6();
                        }
                        else if (m == 7)
                        {
                            changeSkinScript.ChangeSkinButton7();
                        }
                        else if (m == 8)
                        {
                            changeSkinScript.ChangeSkinButton8();
                        }
                        else if (m == 9)
                        {
                            changeSkinScript.ChangeSkinButton9();
                        }
                        else if (m == 10)
                        {
                            changeSkinScript.ChangeSkinButton10();
                        }
                        else if (m == 11)
                        {
                            changeSkinScript.ChangeSkinButton11();
                        }
                        else
                        {
                            _changeskin[m].SetActive(true);
                            ChangeSkin.changeNumber = m;
                            //変更したスキンの要素の順番をPlayerPrefsで記憶する
                            PlayerPrefs.SetInt("ChangeNumber", ChangeSkin.changeNumber);
                            PlayerPrefs.Save();
                        }
                    }
                    else
                    {
                        _changeskin[m].SetActive(false);
                    }
                }

                // 下の小さいボタンが選択(拡大)された時の大きさ。
                imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f); ;

                // 下の小さいボタンが選択(拡大)された時の色
                imageContent.transform.GetChild(i).GetComponent<Image>().color = colors[1];

                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)//何も選択していない時(通常時)に表示されるボタンの設定
                    {
                        // 下の小さいボタンの色
                        imageContent.transform.GetChild(j).GetComponent<Image>().color = colors[0];

                        //下に表示されるボタン大きさ
                        imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);

                        //スキンの画像の大きさ
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.7f, 0.5f), 0.1f);
                    }
                }
            }
        }


    }

    private void GecisiDuzenle(float distance, float[] pos, Button btn)
    {
        // btnSayi = System.Int32.Parse(btn.transform.name);

        for (int i = 0; i < pos.Length; i++)
        {

            //配列の0番目の要素を選択したら、呼ばれる
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                //Mathf = 一般的な数学関数を扱います。
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);
            }
        }

        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            //多分、下にある小さいボタンを追加する
            btn.transform.name = ".";
        }

    }
    public void WhichBtnClicked(Button btn)
    {
        btn.transform.name = "clicked";
        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            //押したボタンの順番と 変数i が一致したら処理を行う
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {
                btnNumber = i;
                takeTheBtn = btn;
                time = 0;
                scroll_pos = (pos[btnNumber]);
                runIt = true;
            }
        }


    }

}