Shader "Custom/CubeMaskSprite2D"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Color ("Tint Color", Color) = (1, 1, 1, 1)
        _CubeCenter ("Cube Center", Vector) = (0, 0, 0, 0)  // Cube 的中心位置
        _CubeSize ("Cube Size", Vector) = (1, 1, 1, 0)      // Cube 的大小 (寬, 高, 深)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }

        Pass
        {
            Tags { "LightMode"="Always" }

            // 如果像素位於 Cube 內部，則不顯示
            Stencil
            {
                Ref 1
                Comp NotEqual
                Pass Keep
            }

            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

            CGPROGRAM
            #include "UnityCG.cginc"

            sampler2D _MainTex;       // 主貼圖
            float4 _Color;           // Tint 顏色
            float4 _CubeCenter;      // Cube 的中心點
            float4 _CubeSize;        // Cube 的大小

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD1;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD1;
                float3 worldPos : TEXCOORD0; // 世界空間位置
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex); // 局部空間轉換為 Clip 空間
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz; // 世界空間座標
                o.uv = v.uv; // 傳遞 UV 坐標
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 c = tex2D(_MainTex, i.uv); // 從貼圖讀取顏色
                c *= _Color; // 應用 Tint 顏色

                // Cube 的半徑
                float3 cubeHalfSize = _CubeSize.xyz * 0.5;

                // 判斷像素是否在 Cube 內
                bool isInsideCube = 
                    i.worldPos.x >= _CubeCenter.x - cubeHalfSize.x &&
                    i.worldPos.x <= _CubeCenter.x + cubeHalfSize.x &&
                    i.worldPos.y >= _CubeCenter.y - cubeHalfSize.y &&
                    i.worldPos.y <= _CubeCenter.y + cubeHalfSize.y &&
                    i.worldPos.z >= _CubeCenter.z - cubeHalfSize.z &&
                    i.worldPos.z <= _CubeCenter.z + cubeHalfSize.z;

                // 如果像素在 Cube 內部，設置透明
                if (isInsideCube)
                {
                    c.a = 0.0; // 隱藏
                }

                return c;
            }
            ENDCG
        }
    }
}
