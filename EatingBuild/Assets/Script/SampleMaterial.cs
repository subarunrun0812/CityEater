using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class SampleMaterial : MonoBehaviour
{

    private Color m_color = Color.white;
    private Color color
    {
        get { return m_color; }
    }


    private MeshRenderer[] meshRenderers;
    // private MeshRenderer m_meshRenderer;//start関数でmeshrenderを取得

    private MaterialPropertyBlock m_mpb;

    public MaterialPropertyBlock mpb
    {
        //?? 演算子は、null 合体演算子と呼ばれます。
        //左側のオペランドが null 値でない場合には左側のオペランドを返し、null 値である場合には右側のオペランドを返します。
        get { return m_mpb ?? (m_mpb = new MaterialPropertyBlock()); }
    }
    void Start()
    {
        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
        m_color.a = 0.4f;

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            mpb.SetColor(Shader.PropertyToID("_Color"), color);
            meshRenderers[i].SetPropertyBlock(m_mpb);
            // meshRendererChild.SetPropertyBlock(m_mpb);

        }

    }
}