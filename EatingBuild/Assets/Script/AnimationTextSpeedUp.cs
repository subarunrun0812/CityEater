using DG.Tweening;
using TMPro;
using UnityEngine;
using System.Collections;

//https://unity-yuji.xyz/dotween-pro-textmeshpro-animation/
//↑このサイトを参考にしました
public class AnimationTextSpeedUp : MonoBehaviour
{
    private DOTweenTMPAnimator tmpAnimator;
    [SerializeField] private float time = 2;
    private IEnumerator DisableItemText()
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        var textMeshPro = GetComponent<TextMeshProUGUI>();
        tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
        Play(time);
        StartCoroutine("DisableItemText");
    }

    public void Play(float duration)
    {
        const float EACH_DELAY_RATIO = 0.01f;
        //文字を非表示にする時間
        var eachDelay = duration * EACH_DELAY_RATIO;
        //文字を表示する期間
        var eachDuration = duration - eachDelay;

        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            DOTween.Sequence()
                .Append(tmpAnimator.DOScaleChar(i, new Vector3(1, 2f, 1), eachDuration / 8))
                .Join(tmpAnimator.DOOffsetChar(i, new Vector3(0, 70f, 0), eachDuration / 8))
                .Append(tmpAnimator.DOScaleChar(i, new Vector3(1, 1f, 1), eachDuration / 8).SetEase(Ease.InQuad))
                .Join(tmpAnimator.DOOffsetChar(i, new Vector3(0, 0f, 0), eachDuration / 8).SetEase(Ease.InQuad))
                .AppendInterval(eachDuration / 4)
                .Append(tmpAnimator.DOColorChar(i, new Color(1, 0.75f, 0.4f), eachDuration / 8).SetLoops(2, LoopType.Yoyo))
                .AppendInterval(eachDuration / 8)
                .Append(tmpAnimator.DOFadeChar(i, 0, eachDuration / 8))
                .SetDelay(eachDelay * i);
        }
    }
}