using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SampleMaterial : MonoBehaviour
{
    private Color color = Color.white;
    private MeshRenderer[] meshRenderers;//親 子オブジェクトを格納。
    private MaterialPropertyBlock m_mpb;

    //Materialのインスタンスは変えずに一部のプロパティだけ変更できるようにする
    public MaterialPropertyBlock mpb
    {
        //TODO: このコードを説明できるようにしっかり理解する
        //?? 演算子は、null 合体演算子と呼ばれます。
        //左側のオペランドが null 値でない場合には左側のオペランドを返し、null 値である場合には右側のオペランドを返します。
        get { return m_mpb ?? (m_mpb = new MaterialPropertyBlock()); }
    }

    void Awake()
    {
        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();//子オブジェクトと親オブジェクトのmeshrendererを取得
    }
    public void ClearMaterialInvoke()//objecを半透明にする関数
    {
        color.a = 0.15f;
        mpb.SetColor(Shader.PropertyToID("_Color"), color);
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse ZWrite");
            meshRenderers[i].SetPropertyBlock(mpb);//一部のプロパティだけ変更できるようにする。
        }
    }
    public void NotClearMaterialInvoke()//objecを非透明に戻す関数
    {
        color.b = 1f;
        mpb.SetColor(Shader.PropertyToID("_Color"), color);
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].GetComponent<Renderer>().material.shader = Shader.Find("Mobile/Diffuse");
            meshRenderers[i].SetPropertyBlock(mpb);//一部のプロパティだけ変更できるようにする。
        }
    }
}