Shader "Custom/TransparentMask2D"
{
    Properties
    {
        _Color ("Mask Color", Color) = (1, 1, 1, 0.5)
    }
    SubShader
    {
        Tags { "Queue"="Overlay" }

        Stencil
        {
            Ref 1
            Comp Always
            Pass Replace
        }

        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask 0 // 不繪製顏色，只是用來標記

        Pass {}
    }
}
