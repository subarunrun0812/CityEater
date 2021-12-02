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
    void Start()
    {
        //InvokeRepeating("関数名,初回呼び出しまでの秒数,次回呼び出しまでの秒数)
        InvokeRepeating("TimeInstantiateItems", 0f, 3f);
    }

    private void TimeInstantiateItems()//一定時間ごとにItemを生成する
    {
        Debug.LogWarning("placesの数は" + places.Count);
        Debug.LogWarning("itemの数は" + items.Count);
        if (places.Count != 0)
        {
            if (items.Count != 0)
            {
                int itemsRandom = Random.Range(0, items.Count);
                int placesRandom = Random.Range(0, places.Count);
                Instantiate(items[itemsRandom], places[placesRandom].transform.position, items[itemsRandom].transform.rotation);
                // places[placesRandom] = places[places.Count - 1];//placesRandomの要素を末尾に持ってくる
                revivalList.Add(places[placesRandom]);
                places.RemoveAt(placesRandom);
                revivalItm.Add(items[itemsRandom]);
                items.RemoveAt(itemsRandom);
            }
            else
            {
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
            }
        }
        else//nullだったらplacesリストに再び全て追加する
        {
            places.Clear();
            //リストで保持しているインスタンスを削除
            for (int i = 0; i < revivalList.Count; i++)
            {
                places.Add(revivalList[i]);
            }
            for (int i = 0; i < revivalList.Count; i++)
            {
                revivalList.RemoveAt(i);
            }
            //リスト自体をキレイにする
            revivalList.Clear();
        }
    }
}

