Shader "Unlit/block_cloud"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Alpha ("Alpha", Range(0,1)) = 0.5 // 控制透明度的屬性
        _DarknessFactor ("Darkness Factor", Range(1, 10)) = 3.0 // 控制漸變強度的屬性
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // 使得shader支持透明
            ZWrite Off  // 禁用深度写入，避免透明物体遮挡问题
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float distance : TEXCOORD1; // 用來存儲物件到相機的距離
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Alpha; // 透明度參數
            float _DarknessFactor; // 控制漸變強度的參數

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);

                // 計算物件到相機的距離
                o.distance = length(ObjSpaceViewDir(v.vertex));

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 將距離轉換成暗化係數，並加強暗化效果
                float darkness = pow(saturate(i.distance / 100.0), _DarknessFactor);

                // 取得材質顏色
                fixed4 col = tex2D(_MainTex, i.uv);

                // 根據距離變暗
                col.rgb *= darkness;

                // 應用透明度
                col.a *= _Alpha;

                // 應用霧效
                UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }
}
