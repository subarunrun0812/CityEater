using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestscoreText;

    void Start()
    {
        int playerBestscore = PlayerPrefs.GetInt("PlayerBestScore");//ロードする
        bestscoreText.text = "Best: " + playerBestscore + "P";
    }
}
