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
        Tags { "Queue"="Overlay" }

        // Pass 1: 標記 Cube 內部的區域 (Stencil Buffer 設定)
        Pass
        {
            Tags { "LightMode"="Always" }
            
            // 標記 Cube 內部區域
            Stencil
            {
                Ref 1
                Comp Always
                Pass Replace
            }
            
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMask 0 // 這個 Pass 不會顯示顏色，只是標記區域
        }

        // Pass 2: 顯示 Sprite，並依照 Stencil Buffer 的結果來隱形
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

            CGPROGRAM
            #include "UnityCG.cginc"

            sampler2D _MainTex;   // 主貼圖
            float4 _Color;         // 顏色 (通常是 tint 顏色)
            float4 _CubeCenter;    // Cube 中心
            float4 _CubeSize;      // Cube 大小

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

            // 頂點著色器，將頂點座標轉換為 Clip 空間
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex); // 將物體的局部座標轉換為螢幕座標
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz; // 世界空間座標
                o.uv = v.uv; // 傳遞 UV 坐標
                return o;
            }

            // 片段著色器，處理每個像素的顯示
            half4 frag(v2f i) : SV_Target
            {
                half4 c = tex2D(_MainTex, i.uv); // 從 _MainTex 讀取顏色
                c *= _Color; // 應用 tint 顏色

                // 檢查物體是否在 Cube 內部
                bool isInsideCube = (i.worldPos.x >= _CubeCenter.x - _CubeSize.x / 2 &&
                                     i.worldPos.x <= _CubeCenter.x + _CubeSize.x / 2 &&
                                     i.worldPos.y >= _CubeCenter.y - _CubeSize.y / 2 &&
                                     i.worldPos.y <= _CubeCenter.y + _CubeSize.y / 2 &&
                                     i.worldPos.z >= _CubeCenter.z - _CubeSize.z / 2 &&
                                     i.worldPos.z <= _CubeCenter.z + _CubeSize.z / 2);

                // 如果在 Cube 內部，設置透明度為 0 (隱形)
                if (isInsideCube)
                {
                    c.a = 0; // 隱形
                }

                return c;
            }
            ENDCG
        }
    }

    // 如果需要兼容舊版或特殊情況，保持兼容性
    SubShader
    {
        Pass
        {
            Tags { "LightMode"="Always" }
            ZWrite Off
            Cull Front
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha
            Stencil
            {
                Ref 1
                Comp Always
                Pass Replace
            }
        }
    }
}
