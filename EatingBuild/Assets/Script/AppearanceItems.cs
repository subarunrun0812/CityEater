using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AppearanceItems : MonoBehaviour
{
    [SerializeField] private GameObject[] items;//アイテムを格納する
    [SerializeField] private List<GameObject> places;//出現するポイントを事前に決めておく

    private List<GameObject> revivalList;//削除したplacesの要素を格納する
    void Start()
    {
        //InvokeRepeating("関数名,初回呼び出しまでの秒数,次回呼び出しまでの秒数)
        InvokeRepeating("TimeInstantiateItems", 0f, 5f);
    }

    private void TimeInstantiateItems()//一定時間ごとにItemを生成する
    {
        if (places != null)
        {
            int itemsRandom = Random.Range(0, items.Length);
            int placesRandom = Random.Range(0, places.Count);
            Instantiate(items[itemsRandom], places[placesRandom].transform.position, items[itemsRandom].transform.rotation);
            places[placesRandom] = places[places.Count - 1];//placesRandomの要素を末尾に持ってくる
            revivalList.Add(places[places.Count - 1]);
            places.RemoveAt(places.Count - 1);
        }
        else if (places == null)//nullだったらplacesリストに再び全て追加する
        {
            AddPlacesList();
        }
        else
        {
            Debug.Log("何もしない");
        }
    }
    private void AddPlacesList()//removeした要素を再び追加
    {
        foreach (var item in revivalList)
        {
            places.Add(item);
        }
        revivalList.Clear();
    }

}

