Shader "Unlit/BottomViewPlane"
{
    Properties
    {
        _ViewPlaneNumber ("View Plane Number", Range(0, 4)) = 0 // 초기화 안된 경우 0 초기화 된 경우 1~3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        ColorMask 0
        Zwrite off
        
        Stencil{
            // 이 쉐이더는 마스크로 사용된다.
            
            //정수를 저장한다. 다른 함수에서 읽을 수 있다.
            ref 1
            comp always
            pass replace
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
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
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
