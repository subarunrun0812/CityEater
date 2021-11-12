Shader "Custom/Transparent" {//表示される名前
     Properties {//マテリアルからいじれるようになる値
         _BaseColor ("Base Color", Color) = (1,1,1,1) //テクスチャ、インスペクターで変更可能
    }

    SubShader {
        Tags {//描画方法を決めるためのタグ

            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }
        CGPROGRAM
        #pragma surface surf Lambert alpha


        struct Input {
        float2 uv_MainTex;//テクスチャのuv
        };
        fixed4 _BaseColor;//ローカルのポジションが入ってくる

        void surf(Input IN, inout SurfaceOutput o) {
            o.Albedo = _BaseColor.rgb;
            o.Alpha  = 0.5;
        }
        ENDCG
    }
}