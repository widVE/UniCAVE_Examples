Shader "Custom/TransparentReflective" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
         _Cube ("Cubemap", CUBE) = "" {}
    }
    SubShader {
        Tags {"Queue"="transparent" "RenderType"="transparent" }

        Cull Off

        CGPROGRAM
        #pragma surface surf Lambert alpha



        struct Input {
            float3 worldRefl;
            float4 _Color;
        };
        samplerCUBE _Cube;
        float4 _Color;
        void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = _Color.rgb;
            o.Emission = texCUBE (_Cube, IN.worldRefl).rgb*_Color.rgb;
            o.Alpha = _Color.a;
        }
        ENDCG
    } 
    FallBack "Transparent/Diffuse"
}