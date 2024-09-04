Shader "Custom/Lit Shader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // 主要的貼圖
        _Glossiness ("Smoothness", Range(0,1)) = 0.5 // 表面的光滑度
        _Metallic ("Metallic", Range(0,1)) = 0.0 // 金屬度
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Name "FORWARD"
            ZWrite On
            ZTest LEqual
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha
            // 確保支持光照和陰影
            // #pragma multi_compile_shadowcaster
            // #pragma shader_feature_local_shadow
            // #pragma shader_feature_local_shadow

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };

            sampler2D _MainTex;
            float _Glossiness;
            float _Metallic;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o, o.pos);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 取得貼圖顏色
                fixed4 c = tex2D(_MainTex, i.uv);
                // 根據光滑度和金屬度設置顏色
                return c;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
