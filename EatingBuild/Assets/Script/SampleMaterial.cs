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

    private int n;

    //Getで値を返しています。return 変数名;
    // private MeshRenderer meshRenderer
    // {
    //     // set //値をmeshRendererに代入する
    //     // {
    //     //     foreach (var child in meshRenderers)//foreach(型名 変数名 in コレクション)
    //     //     {
    //     //         // meshRenderers = child.GetComponents<MeshRenderer>();
    //     //     }
    //     // }
    //     get//meshRenderers配列から要素を１つずつ取り出し
    //     {
    //         for (int i = 0; i < meshRenderers.Length; i++)
    //         {
    //             n = i;
    //             // return meshRenderers[i];
    //         }
    //         return meshRenderers[n];
    //     }

    // }

    // private MeshRenderer meshRendererChild
    // {
    //     get { return m_meshRenderer; }
    // }
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