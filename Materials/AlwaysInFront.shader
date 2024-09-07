Shader "Custom/AlwaysInFront"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}  // 定義主要的貼圖
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" }  // 渲染順序設定為 Overlay，確保總是在最上層
        Pass
        {
            ZWrite Off  // 不寫入深度緩衝區
            ZTest Always  // 始終通過深度測試
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}