using UnityEngine;
using UnityEngine.UI;
using TMPro;

//https://qiita.com/o8que/items/46e486f62bdf05c29559
[RequireComponent(typeof(RectTransform))]
public class TargetIndicator : MonoBehaviour
{
    [SerializeField] private Transform target = default;
    [SerializeField] private Image arrow = default;
    [SerializeField] private TextMeshProUGUI npc_name;

    private Camera mainCamera;
    private RectTransform rectTransform;

    private void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        npc_name.text = target.gameObject.name;
    }

    private void LateUpdate()
    {
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