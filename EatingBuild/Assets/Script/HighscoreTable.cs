using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    [Header("highscoreEntryContainer"), SerializeField]
    private Transform entryContainer;

    [Header("highscoreEntryTemplate"), SerializeField]
    private Transform entryTemplate;
    void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        float temlateHeight = 70f;
        for (int i = 0; i < 10; i++)
        {
            //objectをinstantiateで複製します
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);//Instantiate(コピーするPrefab、生成する位置)
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            //複製した時に配置する位置を70 * i
            entryRectTransform.anchoredPosition = new Vector2(0, -temlateHeight * i);
            entryTransform.gameObject.SetActive(true);

            //最上位のランクを0位にしたくないので、i+1をする
            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;

                case 1: rankString = "1ST"; break;//1位の場合
                case 2: rankString = "2ND"; break;//2位の場合            
                case 3: rankString = "3RD"; break;//3位の場合
            }
            //順位のテキストを取得
            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

            int score = Random.Range(0, 100);//テスト用

            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

            string name = "AAA";
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;
            Debug.Log("処理された回数は" + i);

        }
    }
}
