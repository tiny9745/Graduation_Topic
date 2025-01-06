Shader "Custom/DebugTextureWithNormal"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _NormalTex ("Normal Map", 2D) = "bump" {}
        _DebugColor ("Debug Color", Color) = (1, 0, 0, 1)
    }
    SubShader
    {
        Tags { "Queue"="Overlay" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;  // 主貼圖
            sampler2D _NormalTex; // 法線貼圖
            float4 _DebugColor;  // 調試顏色

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;  // 頂點法線
                float2 uv : TEXCOORD0;   // UV 座標
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD1; // 傳遞法線
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);  // 轉換為 Clip 空間
                o.uv = v.uv;
                o.normal = mul((float3x3)unity_ObjectToWorld, v.normal); // 將法線轉換為世界空間
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // 獲取主貼圖顏色
                half4 texColor = tex2D(_MainTex, i.uv);

                // 若貼圖像素透明度為 0，顯示調試顏色
                if (texColor.a == 0)
                {
                    return _DebugColor;
                }

                // 獲取法線貼圖並進行處理
                half3 normal = tex2D(_NormalTex, i.uv).rgb * 2.0 - 1.0;  // 將法線貼圖的範圍調整為 -1 到 1
                normal = normalize(normal);

                // 計算簡單的光照效果，這裡使用的是漫反射光照模型
                half3 lightDir = normalize(float3(0.5, 1.0, -1.0));  // 假設的光源方向
                half diff = max(dot(normal, lightDir), 0.0); // 計算漫反射光照

                // 最終顏色根據光照進行調整
                half4 finalColor = texColor * diff;

                return finalColor; // 返回最終顏色
            }
            ENDCG
        }
    }
}
