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

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreentryTransformList;
    void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{score = 53532,name = "AAA"},
            new HighscoreEntry{score = 12483,name = "ANN"},
            new HighscoreEntry{score = 70813,name = "CAT"},
            new HighscoreEntry{score = 47209,name = "JON"},
            new HighscoreEntry{score = 31842,name = "JOE"},
            new HighscoreEntry{score = 41802,name = "MIK"},
            new HighscoreEntry{score = 09331,name = "DAV"},
            new HighscoreEntry{score = 30804,name = "MAX"},
        };

        //sort entry list by
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {//swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }


        highscoreentryTransformList = new List<Transform>();//初期化
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreentryTransformList);
        }
    }


    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float temlateHeight = 70f;

        //objectをinstantiateで複製します
        Transform entryTransform = Instantiate(entryTemplate, container);//Instantiate(コピーするPrefab、生成する位置)
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        //複製した時に配置する位置を70 * i
        entryRectTransform.anchoredPosition = new Vector2(0, -temlateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        //最上位のランクを0位にしたくないので、i+1をする
        int rank = transformList.Count + 1;
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

        int score = highscoreEntry.score;//

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;
        transformList.Add(entryTransform);//transformListにentyTransformの要素を追加する

    }
    /*
    *Represents a single High score entry
    **/
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
