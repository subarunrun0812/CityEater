using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class GameManager : MonoBehaviour
{

    public int point;//大きさを変える時などに使うポイント

    [SerializeField] private EatObjectScript playerEat;
    [SerializeField] private Text scoreText;
    [SerializeField] private TextMeshProUGUI addScoreText;//+1 +2 と画面に何ポイント追加したか表示する
    public Color EndColor;


    public void AddPoint(int number)//ポイントの追加
    {
        point = point + number;
        addScoreText.text = $"+{number}";
        // DOTween.Sequence()
        // .Join(addScoreText.DOFaceFade(0.0f, 3.0f))
        // .Join(addScoreText.DOOutlineColor(EndColor, 3.0f).SetDelay(0.5f))
        // .SetRelative()
        // .Pause()
        // .SetAutoKill(false);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Demo");
        }
        scoreText.text = point.ToString();
    }


}
