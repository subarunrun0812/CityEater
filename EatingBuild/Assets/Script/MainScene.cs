using UnityEngine;
using UnityEngine.SceneManagement;

using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;

public class MainScene : MonoBehaviour
{
    InterstitialAdGameObject interstitialAd;
    RewardedAdGameObject rewardedAdGameObject;
    [SerializeField] private GameObject itemsText;
    [SerializeField] private CountDownTimer countDownTimer;
    [SerializeField] private GameObject notime;
    [SerializeField] private GameObject continue_b;
    [SerializeField] private GameObject quit_b;
    void Start()
    {
        //リワード
        rewardedAdGameObject = MobileAds.Instance
            .GetAd<RewardedAdGameObject>("Rewarded_Ad");

        //インタースティシャルを準備
        interstitialAd = MobileAds.Instance
            .GetAd<InterstitialAdGameObject>("Interstitial_Ad");//Interstitial Adを入れる

        MobileAds.Initialize((initStatus) =>
        {
            // Debug.Log("Initialized MobileAds");
        });
        //最初に広告を読み込んでおく
        interstitialAd.LoadAd();
    }

    //広告を表示する時の処理
    //interstitialの広告表示
    //returnstartScene画面に戻る時の処理
    public void OnClickInterstitialShowButton()
    {
        // Display an interstitial ad
        interstitialAd.ShowIfLoaded();
    }
    //rewardの広告表示
    public void OnClickRewardShowButton()
    {
        // Display an interstitial ad
        rewardedAdGameObject.ShowIfLoaded();
        Time.timeScale = 0;

    }



    //閉じた時の処理
    public void OnCloseInterstitialButton()
    {
        Debug.LogError("Interstitialを閉じた");
    }
    public void OnCloseRewardButton()
    {
        countDownTimer.seconds += 30;//30秒追加
        Debug.LogError("Rewardを閉じた");
        itemsText.SetActive(true);
    }
    public void OnAdFailedButton()//リワード広告のボタンを押して広告が表示されなかったとき
    {
        Time.timeScale = 1;
        countDownTimer.seconds += 30;//30秒追加
        Debug.LogError("OnAdFailedを閉じた");
        itemsText.SetActive(true);
    }
    public void OnAdClosed()//Userが途中で閉じってしまった時の対処
    {
        Time.timeScale = 1;
    }




    //実行されている処理の確認するためのコード↓
    //reward
    public void ReOnAdFailedToLoad()
    {
        Debug.Log("Rew広告の読み込みが失敗すると呼び出されます。");
    }
    public void ReOnAdFailedToShow()
    {
        Debug.Log("Rew広告の表示に失敗すると呼び出されます。");
    }
    public void ReOnAdLoaded()
    {
        Debug.Log("Rew広告の読み込みが完了すると呼び出されます。");
    }

    //Interstitial
    public void IntOnAdFailedToLoad()
    {
        Debug.Log("Int広告の読み込みに失敗すると呼び出されます");
    }
    public void IntOnAdLoaded()
    {
        Debug.Log("Int広告の読み込みが完了すると呼び出されます。");
    }

}