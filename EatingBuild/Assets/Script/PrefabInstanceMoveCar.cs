using UnityEngine;

public class PrefabInstanceMoveCar : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;//
    [SerializeField] private GameObject[] items;
    int itemsNumber = 0;

    void Start()
    {
        //InvokeRepeating("関数名,初回呼び出しまでの秒数,次回呼び出しまでの秒数)
        InvokeRepeating("TimeInstantiateCar", 1f, 7f);
        InvokeRepeating("TimeInstantiateItem", 2.5f, 21f);

    }

    private void TimeInstantiateCar()//この関数は一定時間ごとに呼ばれる
    {
        int random = Random.Range(0, cars.Length);//
        Instantiate(cars[random], this.transform.position, cars[random].transform.rotation);

    }
    private void TimeInstantiateItem()//この関数は一定時間ごとに呼ばれる
    {
        if (itemsNumber == items.Length)
        {
            itemsNumber = 0;
        }
        Instantiate(items[itemsNumber], this.transform.position, items[itemsNumber].transform.rotation);
        itemsNumber++;

    }
}
