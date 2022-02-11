using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AppearanceItems : MonoBehaviour
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
        itemTime = 5;
        //InvokeRepeating("関数名,初回呼び出しまでの秒数,次回呼び出しまでの秒数)
        InvokeRepeating("TimeInstantiateItems", 0f, itemTime);
    }

    private void TimeInstantiateItems()//一定時間ごとにItemを生成する
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
                // int placesRandom = Random.Range(0, places.Count);
                Instantiate(items[itemsRandom], places[placesNumber].transform.position, items[itemsRandom].transform.rotation);
                // revivalList.Add(places[placesNumber]);
                // places.RemoveAt(placesNumber);
                revivalItm.Add(items[itemsRandom]);
                items.RemoveAt(itemsRandom);
                placesNumber++;
                // Debug.LogError("placesNumber : " + placesNumber);
                // Debug.LogError("itemsRandom : " + itemsRandom);
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
                for (int i = 0; i < revivalItm.Count; i++)
                {
                    revivalItm.RemoveAt(i);
                }
                //リスト自体をキレイにする
                revivalItm.Clear();
                int itemsRandom = Random.Range(0, items.Count);
                // int placesRandom = Random.Range(0, places.Count);
                Instantiate(items[itemsRandom], places[placesNumber].transform.position, items[itemsRandom].transform.rotation);
                // revivalList.Add(places[placesNumber]);
                // places.RemoveAt(placesNumber);
                revivalItm.Add(items[itemsRandom]);
                items.RemoveAt(itemsRandom);
                placesNumber++;
                // Debug.LogError("placesNumber : " + placesNumber);
                // Debug.LogError("itemsRandom : " + itemsRandom);
            }
        }
    }
}
// else//nullだったらplacesリストに再び全て追加する
// {
//     places.Clear();
//     //リストで保持しているインスタンスを削除
//     for (int i = 0; i < revivalList.Count; i++)
//     {
//         places.Add(revivalList[i]);
//     }
//     for (int i = 0; i < revivalList.Count; i++)
//     {
//         revivalList.RemoveAt(i);
//     }
//     //リスト自体をキレイにする
//     revivalList.Clear();
// }


