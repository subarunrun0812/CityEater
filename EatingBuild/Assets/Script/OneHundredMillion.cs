using DG.Tweening;
using TMPro;
using UnityEngine;
using System.Collections;

public class OneHundredMillion : MonoBehaviour
{
    private DOTweenTMPAnimator tmpAnimator;
    [SerializeField] private float time;

    private IEnumerator DisableItemText()
    {
        Debug.Log("Corutineが呼ばれた");
        yield return new WaitForSeconds(time + 1f);
        this.gameObject.SetActive(false);
    }
    public void OnEnable()
    {
        var textMeshPro = GetComponent<TextMeshProUGUI>();
        tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
        // textMeshPro.text = point + "P";
        Initialize();
        Play(time);
        StartCoroutine("DisableItemText");
    }
    private void Initialize()
    {
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            tmpAnimator.DORotateChar(i, Vector3.right * 90, 0);
            tmpAnimator.DOOffsetChar(i, Vector3.zero, 0);
            tmpAnimator.DOFadeChar(i, 1, 0);
        }
    }

    private void Play(float duration)
    {

        const float EACH_DELAY_RATIO = 0.01f;
        var eachDelay = duration * EACH_DELAY_RATIO;
        var eachDuration = duration - eachDelay;
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            DOTween.Sequence()
                .Append(tmpAnimator.DORotateChar(i, Vector3.right * 360, eachDuration / 2, RotateMode.FastBeyond360))
                .AppendInterval(eachDuration / 4)
                .Append(tmpAnimator.DOOffsetChar(i, Vector3.down * 40f, eachDuration / 4))
                .Join(tmpAnimator.DOFadeChar(i, 0, eachDuration / 4))
                .SetDelay(eachDelay * i);
        }
        Debug.Log("Playが呼ばれた");
    }
}
