Shader "Hidden/Shadow" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        _ShadowX ("Shadow X Axis", Range(-0.5, 0.5)) = 0.1 //x��ƫ��ֵ
        _ShadowY ("Shadow Y Axis", Range(-0.5, 0.5)) = -0.05 //y��ƫ��ֵ
        _ShadowAlpha ("Shadow Alpha", Range(0, 1)) = 0.5 //Ӱ��alphaֵ

    }
    SubShader {
        Tags { "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl" 
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            TEXTURE2D (_MainTex);SAMPLER(sampler_MainTex);
            half _ShadowX, _ShadowY, _ShadowAlpha;
            half4 _ShadowColor;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v) {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                return o;
            }

            //ͨ���������ص�alphaֵ��ʹ��_MainTex�����ϵ�һ���������������Ӱ���
            half4 frag(v2f i) : SV_Target {
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv);
                half shadowA = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv + half2(_ShadowX, _ShadowY)).a;//��ƫ�ƹ���uv���в��� ���Ҽ�¼alphaֵ �������ΪӰ�ӵ�alpha
                col.a = max(shadowA * _ShadowAlpha, col.a);//�����˵�ǰ���ص�alphaֵ ȡ���ֵ��Ϊ��ȷ����Ӱ��alphaֵ�������ƬԪ��ɫ��alphaֵ��
                return col;
            }
            ENDHLSL
        }
    }
}