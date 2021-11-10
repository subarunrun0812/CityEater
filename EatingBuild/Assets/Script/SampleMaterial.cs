using UnityEngine;

public class SampleMaterial : MonoBehaviour
{
    [SerializeField, Header("適用する色")]//Inspectorの変数の上にヘッダーをつけることができます。
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
        //?? 演算子は、null 合体演算子と呼ばれます。
        //左側のオペランドが null 値でない場合には左側のオペランドを返し、null 値である場合には右側のオペランドを返します。
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