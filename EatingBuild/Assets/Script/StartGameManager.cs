using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class StartGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject changeSkinbutton;

    [SerializeField]
    private GameObject scrollviewbutton;


    //https://hirokuma.blog/?p=3003
    //App Tracking Transparency許可リクエストを発行する際のUnityのサンプルコードを示します。

#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void _requestIDFA();
#endif

    void Start()
    {
        #if UNITY_IOS
        _requestIDFA();
#endif
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
            DeleteSave();
        }
    }
    public void DeleteSave()//test用
    {
        PlayerPrefs.DeleteAll();
        Debug.LogError("セーブデータを全て削除した");
        SceneManager.LoadScene("StartScene");
    }

}
