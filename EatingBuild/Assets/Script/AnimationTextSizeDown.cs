using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEditor;
using System.Collections;

public class AnimationTextSizeDown : MonoBehaviour
{
    private DOTweenTMPAnimator tmpAnimator;

    [SerializeField] private float time = 2;

    private IEnumerator DisableItemText()
    {
        yield return new WaitForSeconds(2.5f);
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
        var eachDelay = duration * EACH_DELAY_RATIO;
        var eachDuration = duration - eachDelay;

        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            DOTween.Sequence()
                .Append(tmpAnimator.DOScaleChar(i, new Vector3(1, 2f, 1), eachDuration / 8))
                .Join(tmpAnimator.DOOffsetChar(i, new Vector3(0, 70f, 0), eachDuration / 8))
                .Append(tmpAnimator.DOScaleChar(i, new Vector3(1, 1f, 1), eachDuration / 8).SetEase(Ease.InQuad))
                .Join(tmpAnimator.DOOffsetChar(i, new Vector3(0, 0f, 0), eachDuration / 8).SetEase(Ease.InQuad))
                .AppendInterval(eachDuration / 4)
                .Append(tmpAnimator.DOColorChar(i, new Color(0.3f, 0.3f, 0.3f), eachDuration / 8).SetLoops(2, LoopType.Yoyo))
                .AppendInterval(eachDuration / 8)
                .Append(tmpAnimator.DOFadeChar(i, 0, eachDuration / 8))
                .SetDelay(eachDelay * i);
        }
    }
}