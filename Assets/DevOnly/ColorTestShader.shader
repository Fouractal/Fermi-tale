Shader "Unlit/ClipFromCharacterWithColor"
{
    Properties
    {
        _TintColor("Test Color", color) = (1, 1, 1, 1)
        _Intensity("Range Sample", Range(0, 1)) = 0.5
        _Alpha("Alpha", Range(0,1)) = 0.5

        _MainTex ("Texture", 2D) = "white" {}
        _PivotPoint("PivotPoint", Vector) = (0, 0, 0, 0)
        _CutoffDistance("Cutoff Distance", Range(0.0, 10.0)) = 5.0
    }

    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 100

        Pass
        {
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
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _PivotPoint;
            float _CutoffDistance;
            half4 _TintColor;
            float _Intensity;
            float _Alpha;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv; // 한 줄 더있음
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                //float3 distanceVector = _PivotPoint - i.worldPos;
                //float distance = length(distanceVector);

                float distance_x = abs(_PivotPoint.x - i.worldPos.x);
                float distance_y = abs(_PivotPoint.y - i.worldPos.y);
                float distance_z = abs(_PivotPoint.z - i.worldPos.z);

                //clip(_CutoffDistance - (distance_x+distance_z));
                //clip(_CutoffDistance - distance_y);

                clip(_CutoffDistance - distance_x);
                //clip(_CutoffDistance - distance_y);
                clip(_CutoffDistance - distance_z);

                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb *= _TintColor * _Intensity;
                col.a = col.a * _Alpha;
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}