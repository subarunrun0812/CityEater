using UnityEngine;
using System.Collections;
// ジェネリックコレクションを利用するので追加
using System.Collections.Generic;

public class CustomerInStore : MonoBehaviour
{
    public GameObject[] characters = new GameObject[10];

    float nextSpawnTime = 0;

    [SerializeField]
    float interval = 5.0f;
    [SerializeField]
    public bool isCanComeCustomer = false;
    // キャラクターの種類の最大数
    const int CHARACTER_NUM_MAX = 7;
    // 存在しないキャラクターのリスト
    //キャラのいないリストの生成
    private List<int> nonExistence = new List<int>();

    void LocalInstantate()
    {
        // ランダムでインデックスからキャラを選択
        int _customerIndex = Random.Range(0, nonExistence.Count);

        //存在しないキャラクターのリストの中から
        //キャラクターの種類をランダムで選択してインスタンス化（クローン）
        int _customerNum = nonExistence[_customerIndex];
        GameObject obj = (GameObject)Instantiate(characters[_customerNum]);

        obj.transform.parent = transform;
        obj.transform.localPosition = new Vector3(-3.35f, -1.44f, 0);

        // インスタンス（クローン）化したのでリストから削除
        nonExistence.RemoveAt(_customerIndex);
    }

    // 生成していないキャラクターをリストに追加
    public void AddNonExistenceList(int num)
    {
        nonExistence.Add(num);
    }

    // Use this for initialization
    void Start()
    {
        // 最初にキャラのいないリストを初期化
        for (int i = 0; i < CHARACTER_NUM_MAX; i++)
        {
            AddNonExistenceList(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // キャラクターの生成までの時間
        if (nextSpawnTime < Time.timeSinceLevelLoad && isCanComeCustomer == true)
        {
            nextSpawnTime = Time.timeSinceLevelLoad + interval;
            // リストの要素数が0より大きいときにのみ実行する
            if (0 < nonExistence.Count) LocalInstantate();
        }
    }
}