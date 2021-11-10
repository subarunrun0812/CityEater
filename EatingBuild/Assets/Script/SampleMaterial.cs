using UnityEngine;

public class SampleMaterial : MonoBehaviour
{
    [SerializeField, Header("適用する色")]
    private Color m_color;
    public Color color
    {
        get { return m_color; }
    }

    [SerializeField, Header("メッシュレンダラー")]
    private MeshRenderer m_meshRenderer;
    public MeshRenderer meshRenderer
    {
        get { return m_meshRenderer; }
    }

    /// 追加!!!
    private MaterialPropertyBlock m_mpb;
    public MaterialPropertyBlock mpb
    {
        get { return m_mpb ?? (m_mpb = new MaterialPropertyBlock()); }
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        if (meshRenderer != null)
        {
            mpb.SetColor(Shader.PropertyToID("_Color"), color);
            meshRenderer.SetPropertyBlock(m_mpb);
        }
    }
}