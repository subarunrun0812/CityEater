using UnityEngine;
using UnityEngine.UI;
using TMPro;

//https://qiita.com/o8que/items/46e486f62bdf05c29559
//↑この記事を参考にした
[RequireComponent(typeof(RectTransform))]
public class TargetIndicator : MonoBehaviour
{
    [SerializeField] private Transform target = default;

    [SerializeField] private Image arrow = default;
    [SerializeField] private TextMeshProUGUI npc_name;
    [SerializeField] private Color _color;

    private Camera mainCamera;
    private RectTransform rectTransform;

    private void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        npc_name.text = target.gameObject.name;
        npc_name.color = _color;
        arrow.color = _color;
    }

    private void LateUpdate()
    {
        //もし、targetが非オブジェクトになったら、
        if (target.transform.gameObject.activeSelf == false)
        {
            this.transform.gameObject.SetActive(false);
        }
        // ルート（Canvas）のスケール値を取得する
        float canvasScale = transform.root.localScale.z;
        var center = 0.5f * new Vector3(Screen.width, Screen.height);

        var pos = mainCamera.WorldToScreenPoint(target.position) - center;
        if (pos.z < 0f)
        {
            pos.x = -pos.x;
            pos.y = -pos.y;

            if (Mathf.Approximately(pos.y, 0f))
            {
                pos.y = -center.y;
            }
        }
        // UI座標系の値をスクリーン座標系の値に変換する
        var halfSize = 0.5f * canvasScale * rectTransform.sizeDelta;
        float d = Mathf.Max(
            Mathf.Abs(pos.x / (center.x - halfSize.x)),
            Mathf.Abs(pos.y / (center.y - halfSize.y))
        );

        bool isOffscreen = (pos.z < 0f || d > 1f);
        if (isOffscreen)
        {
            pos.x /= d;
            pos.y /= d;
        }
        // スクリーン座標系の値をUI座標系の値に変換する
        rectTransform.anchoredPosition = pos / canvasScale;

        arrow.enabled = isOffscreen;
        npc_name.enabled = false;
        if (isOffscreen)
        {
            arrow.rectTransform.eulerAngles = new Vector3(
                0f, 0f,
                Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg
            );
            npc_name.enabled = true;

        }
    }
}