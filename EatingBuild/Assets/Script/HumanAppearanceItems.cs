using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAppearanceItems : MonoBehaviour
{
    [Header("placesと要素数を合わせる"), SerializeField] private List<GameObject> items;//アイテムを格納する
    [SerializeField] private List<GameObject> revivalItm;//アイテムを格納する
    [Header("itemsと要素数を合わせる"), SerializeField] private List<GameObject> places = new List<GameObject>();//出現するポイントを事前に決めておく

    [SerializeField] private List<GameObject> revivalList = new List<GameObject>();//削除したplacesの要素を格納する.listの中を初期化
    int placesNumber = 0;
    int itemsRandom;
    public int itemTime;
    void Start()
    {
        //InvokeRepeating("関数名,初回呼び出しまでの秒数,次回呼び出しまでの秒数)
        InvokeRepeating("TimeInstantiateItems", 0f, itemTime);
    }

    private void TimeInstantiateItems()//一定時間ごとにこの関数が呼ばれる
    {
        if (places.Count != 0)
        {
            if (items.Count != 0)
            {
                if (placesNumber == places.Count)
                {
                    placesNumber = 0;
                }

                int itemsRandom = Random.Range(0, items.Count);
                Instantiate(items[itemsRandom], places[placesNumber].transform.position, items[itemsRandom].transform.rotation);
                revivalItm.Add(items[itemsRandom]);
                items.RemoveAt(itemsRandom);
                placesNumber++;
            }
            else
            {
                if (placesNumber == places.Count)
                {
                    placesNumber = 0;
                }
                items.Clear();
                //リストで保持しているインスタンスを削除
                for (int i = 0; i < revivalItm.Count; i++)
                {
                    items.Add(revivalItm[i]);
                }

                //リスト自体をキレイにする
                revivalItm.Clear();
                int itemsRandom = Random.Range(0, items.Count);
                Instantiate(items[itemsRandom], places[placesNumber].transform.position, items[itemsRandom].transform.rotation);
                revivalItm.Add(items[itemsRandom]);
                items.RemoveAt(itemsRandom);
                placesNumber++;
            }
        }
    }
}

