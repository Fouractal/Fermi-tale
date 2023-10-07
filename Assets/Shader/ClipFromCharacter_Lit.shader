Shader "Custom/Lit/ClipFromCharacter"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Intensity("Range Sample", Range(0, 1)) = 0.5

        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _PivotPoint ("Pivot Point", Vector) = (0, 0, 0, 0)
        _CutoffDistance ("Cutoff Distance", Range(0.0, 10.0)) = 5.0

        [MaterialToggle] _IsStartGame ("Is Start Game", Float) = 0
        [MaterialToggle] _IsRenderDirection ("Is Render Direction", Float) = 0
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float4 _PivotPoint;
        float _CutoffDistance;
        float _Intensity;
        float _IsStartGame;
        float _IsRenderDirection;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
        // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            float distance_x = abs(_PivotPoint.x - IN.worldPos.x);
            float distance_z = abs(_PivotPoint.z - IN.worldPos.z);

            if(_IsStartGame > 0.5f)
            {
                clip(_CutoffDistance - distance_x);
                clip(_CutoffDistance - distance_z);    
            }
            
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb * _Intensity;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;

            if(_IsRenderDirection > 0.5f)
            {
                o.Alpha = c.a;
            }
            else
            {
                o.Alpha = 0;
            }
        }
        ENDCG
    }
    FallBack "Standard"
}