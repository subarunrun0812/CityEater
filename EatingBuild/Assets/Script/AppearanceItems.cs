using System.Collections.Generic;
using UnityEngine;

public class AppearanceItems : MonoBehaviour
{
    [Header("placesと要素数を合わせる"), SerializeField] private List<GameObject> items;//アイテムを格納する
    [SerializeField] private List<GameObject> revivalItem;//アイテムを格納する
    [Header("itemsと要素数を合わせる"), SerializeField] private List<GameObject> places = new List<GameObject>();//出現するポイントを事前に決めておく

    int placesNumber = 0;
    public int itemTime;
    void Start()
    {
        //InvokeRepeating("関数名,初回呼び出しまでの秒数,次回呼び出しまでの秒数)
        InvokeRepeating("InstantiateItems", 0f, itemTime);
    }

    private void InstantiateItems()//この関数は一定時間ごとに呼ばれる。
    {
        if (places.Count != 0)
        {
            //imtesのリストが空じゃなかったら
            if (items.Count != 0)
            {
                if (placesNumber == places.Count)
                {
                    placesNumber = 0;
                }

                int itemsRandom = Random.Range(0, items.Count);
                Instantiate(items[itemsRandom], places[placesNumber].transform.position, items[itemsRandom].transform.rotation);
                //出現したアイテムをrevivalItemリスト追加
                revivalItem.Add(items[itemsRandom]);
                //出現したアイテムをitemsリストから削除
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
                //revivalItemリストで保持しているインスタンスをitemsリストに追加する
                for (int i = 0; i < revivalItem.Count; i++)
                {
                    items.Add(revivalItem[i]);
                }
                //リストをキレイにする
                revivalItem.Clear();
                //itemを生成
                int itemsRandom = Random.Range(0, items.Count);
                Instantiate(items[itemsRandom], places[placesNumber].transform.position, items[itemsRandom].transform.rotation);
                revivalItem.Add(items[itemsRandom]);
                items.RemoveAt(itemsRandom);
                placesNumber++;
            }
        }
    }
}


