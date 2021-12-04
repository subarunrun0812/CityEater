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

    [SerializeField]
    private GameObject returnstart_b;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject[] nPC;

    private List<HighscoreEntry> highscoreEntryList;//HighscoreEntryクラスにscoreとnameの要素を格納します
    private List<Transform> highscoreentryTransformList;


    void Awake()
    {
        entryTemplate.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        returnstart_b.SetActive(true);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{score = gameManager.point,name = "Player"},
            new HighscoreEntry{score = nPC[0].GetComponent<NPCEatObjectScript>().point,name = "Liam"},
            new HighscoreEntry{score = nPC[1].GetComponent<NPCEatObjectScript>().point,name = "Noah"},
            new HighscoreEntry{score = nPC[2].GetComponent<NPCEatObjectScript>().point,name = "Oliver"},
            new HighscoreEntry{score = nPC[3].GetComponent<NPCEatObjectScript>().point,name = "Elijah"},
            new HighscoreEntry{score = nPC[4].GetComponent<NPCEatObjectScript>().point,name = "Emma"},
            new HighscoreEntry{score = nPC[5].GetComponent<NPCEatObjectScript>().point,name = "Ava"},
            // new HighscoreEntry{score = nPC[6].GetComponent<NPCEatObjectScript>().point,name = "NPC6"},
            // new HighscoreEntry{score = nPC[7].GetComponent<NPCEatObjectScript>().point,name = "NPC7"},
            // new HighscoreEntry{score = nPC[8].GetComponent<NPCEatObjectScript>().point,name = "NPC8"},
            // new HighscoreEntry{score = nPC[9].GetComponent<NPCEatObjectScript>().point,name = "NPC9"},
        };

        //スコアが高い順に並べる
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
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)//foreach(型名 オブジェクト名 in コレクション) 
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreentryTransformList);
        }

        //PlayerBestScoreの処理について↓
        int score = gameManager.point;
        int playerBestscore = PlayerPrefs.GetInt("PlayerBestScore");//ロードする

        Debug.LogError("playerBestscore" + playerBestscore);
        //セーブ状態があるかどうか
        if (PlayerPrefs.HasKey("PlayerBestScore"))
        {
            Debug.Log("PlayerBestScoreのデータがあるよ！");
            //今回のscoreがPlayerBestScoreより高かったら更新する
            if (score > playerBestscore)
            {
                Debug.LogError("PlayerBestScoreが更新された!!!");
                PlayerPrefs.SetInt("PlayerBestScore", score);
                PlayerPrefs.Save();
            }
        }
        //ない場合は今回のscoreをそのままPlayerBestScoreに保存する
        else
        {
            Debug.LogError("PlayerBestScoreのデータがないよ！");
            PlayerPrefs.SetInt("PlayerBestScore", score);
            PlayerPrefs.Save();
        }
    }


    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float temlateHeight = 70f;

        //objectをinstantiateで複製します
        Transform entryTransform = Instantiate(entryTemplate, container);//Instantiate(コピーするPrefab、生成する位置)
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        //複製した時に配置する位置を70 * transformListの要素の数
        entryRectTransform.anchoredPosition = new Vector2(0, -temlateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        //最上位のランクを0位にしたくないので、i+1をする
        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            case 1: rankString = "1ST"; break;//1位の場合
            case 2: rankString = "2ND"; break;//2位の場合            
            case 3: rankString = "3RD"; break;//3位の場合
            default:
                rankString = rank + "TH"; break;

        }
        //順位のテキストを取得
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        //HighscoreEntryのscoreに返り値を渡す
        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        //HighscoreEntryのnameに返り値を渡す
        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        //transformListにentyTransformの要素を追加する
        transformList.Add(entryTransform);

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
