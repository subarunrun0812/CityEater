using DG.Tweening;
using TMPro;
using UnityEngine;
using System.Collections;

//https://unity-yuji.xyz/dotween-pro-textmeshpro-animation/
//↑このサイトを参考にしました
public class AnimationTextKO : MonoBehaviour
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
