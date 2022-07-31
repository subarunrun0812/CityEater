using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
public class AnimationTextKO : MonoBehaviour//speed up テキスト
{

    private TextMeshProUGUI textMeshPro;

    [SerializeField] private float time = 1.5f;

    private IEnumerator DisableItemText()
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
    public void OnEnable(string name)
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        Initialize();
        Play(time);
        StartCoroutine("DisableItemText");
        textMeshPro.text = "Killed " + name;
    }

    //Initialize()関数とPlay()関数の処理内容は説明できません。サイトに載っていたGitHubのソースコードを使っているからです。
    // TODO: 解読する。
    private void Initialize()
    {
        textMeshPro.DOFade(0, 0);
        textMeshPro.characterSpacing = -50;
    }
    private void Play(float duration)
    {
        // 文字間隔を開ける
        DOTween.To(() => textMeshPro.characterSpacing, value => textMeshPro.characterSpacing = value, 10, duration)
            .SetEase(Ease.OutQuart);

        // フェード
        DOTween.Sequence()
            .Append(textMeshPro.DOFade(1, duration / 4))
            .AppendInterval(duration / 2)
            .Append(textMeshPro.DOFade(0, duration / 4));
    }
}








// private DOTweenTMPAnimator tmpAnimator;

// [SerializeField] private float time = 2;

// private IEnumerator DisableItemText()
// {
//     yield return new WaitForSeconds(2.5f);
//     this.gameObject.SetActive(false);
// }
// private void OnEnable()
// {
//     var textMeshPro = GetComponent<TextMeshProUGUI>();
//     tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
//     Play(time);
//     StartCoroutine("DisableItemText");
// }

// public void Play(float duration)
// {
//     const float EACH_DELAY_RATIO = 0.01f;
//     var eachDelay = duration * EACH_DELAY_RATIO;
//     var eachDuration = duration - eachDelay;

//     for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
//     {
//         DOTween.Sequence()
//             .Append(tmpAnimator.DOScaleChar(i, new Vector3(1, 2f, 1), eachDuration / 8))
//             .Join(tmpAnimator.DOOffsetChar(i, new Vector3(0, 70f, 0), eachDuration / 8))
//             .Append(tmpAnimator.DOScaleChar(i, new Vector3(1, 1f, 1), eachDuration / 8).SetEase(Ease.InQuad))
//             .Join(tmpAnimator.DOOffsetChar(i, new Vector3(0, 0f, 0), eachDuration / 8).SetEase(Ease.InQuad))
//             .AppendInterval(eachDuration / 4)
//             .Append(tmpAnimator.DOColorChar(i, new Color(1, 0.26f, 0.1f), eachDuration / 8).SetLoops(2, LoopType.Yoyo))
//             .AppendInterval(eachDuration / 8)
//             .Append(tmpAnimator.DOFadeChar(i, 0, eachDuration / 8))
//             .SetDelay(eachDelay * i);
//     }
// }
