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
        Time.timeScale = 1;
    }
    public void OnAdClosed()//Userが途中で閉じってしまった時の対処
    {
        Time.timeScale = 0;
        notime.SetActive(true);
        continue_b.SetActive(false);
        quit_b.SetActive(true);
    }
}