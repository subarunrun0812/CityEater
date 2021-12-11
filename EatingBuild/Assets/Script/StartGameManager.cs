using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject changeSkinbutton;

    [SerializeField]
    private GameObject scrollviewbutton;

    private int totalScore;

    void Start()
    {
        changeSkinbutton.SetActive(true);
        startButton.SetActive(true);
        scrollviewbutton.SetActive(false);
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Demo");
    }

    public void ActiveChangeSkinButton()//buttonが押されたらscrollviewを表示する
    {
        changeSkinbutton.SetActive(false);
        startButton.SetActive(true);
        scrollviewbutton.SetActive(true);
    }

    public void CloseChangeSkinButton() //buttonが押されたらscrollviewを非表示にする
    {
        changeSkinbutton.SetActive(true);
        startButton.SetActive(true);

        scrollviewbutton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StartScene");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
            Debug.LogError("セーブデータを全て削除した");
        }
    }

}
