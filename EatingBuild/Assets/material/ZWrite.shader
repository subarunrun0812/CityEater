Shader "Transparent/Diffuse ZWrite" {//表示される名前
    Properties {//materialからいじれるようにする値
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}//テクスチャ、インスペクターで変更可能
    }

    SubShader {
        //描画方法を決めるためのタグ
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 200

        // extra pass that renders to depth buffer only
        Pass {
            ZWrite On////深度情報は考慮する
            ColorMask 0
        }

        // paste in forward rendering passes from Transparent/Diffuse
        UsePass "Transparent/Diffuse/FORWARD"
    }

    Fallback "Transparent/VertexLit"
}

