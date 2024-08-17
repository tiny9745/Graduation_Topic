Shader "Unlit/block_cloud"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Alpha ("Alpha", Range(0,1)) = 0.5 
        _DarknessFactor ("Darkness Factor", Range(1, 10)) = 3.0 
        _FogDensity ("Fog Density", Range(1, 10)) = 2.0
        _NearDarkness ("Near Darkness", Range(0, 1)) = 0.5
        _MinFogEffect ("Min Fog Effect", Range(0, 1)) = 0.4
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha 
            ZWrite Off  
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Alpha; 
            float _DarknessFactor;
            float _FogDensity;
            float _NearDarkness;
            float _MinFogEffect;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                UNITY_TRANSFER_FOG(o, o.vertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float distance = length(i.worldPos - _WorldSpaceCameraPos);

                float darkness = pow(saturate(distance / 100.0), _DarknessFactor) * _FogDensity;
                float fogEffect = max(_MinFogEffect, darkness);

                fixed4 col = tex2D(_MainTex, i.uv);

                col.rgb *= fogEffect;
                col.a *= _Alpha;

                UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }
}
