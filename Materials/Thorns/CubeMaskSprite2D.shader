Shader "Custom/CubeMaskSprite2D"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint Color", Color) = (1, 1, 1, 1)
    }

    SubShader
    {
        Tags { "Queue"="Overlay" }

        // 顯示正面，背面剔除
        Pass
        {
            Tags { "LightMode"="Always" }
            Cull Front   // 設定背面剔除，只有正面顯示
            ZWrite On    // 開啟深度寫入

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex); // 世界與相機變換
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 c = tex2D(_MainTex, i.uv);
                c *= _Color;  // 顏色修改
                return c;
            }
            ENDCG
        }

        // 這一個 Pass 用來處理正面的渲染
        Pass
        {
            Tags { "LightMode"="Always" }
            Cull Back    // 設定背面剔除，只渲染正面
            ZWrite On
            Blend SrcAlpha OneMinusSrcAlpha
            Offset 10, 10

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex); // 世界與相機變換
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 c = tex2D(_MainTex, i.uv);
                c *= _Color;  // 顏色修改
                return c;
            }
            ENDCG
        }
    }
    FallBack "Sprites/Default"
}
