Shader "Hidden/Glow" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        _GlowColor ("Glow Color", Color) = (1, 1, 1, 1) //ȫ��������ɫ
        _GlowIntensity ("GlowIntensity", Range(0, 10)) = 2 //���������ɫ���ò�λ�ķ����ǿ��
        [NoScaleOffset] _GlowTex ("GlowTexture", 2D) = "white" { }//��������

        _DistortTex ("DistortionTex", 2D) = "white" { }//��������Ť��������ͼ
        _DistortAmount ("DistortionAmount", Range(0, 2)) = 2 //����ͼ�����Ĵ�Сϵ��
        _DistortTexXSpeed ("DistortTexXSpeed", Range(-50, 50)) = 0 //����ͼ������X���ٶ�
        _DistortTexYSpeed ("DistortTexYSpeed", Range(-50, 50)) = -5 //����ͼ������Y���ٶ�

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
            TEXTURE2D (_GlowTex);SAMPLER(sampler_GlowTex);
            half4 _GlowColor;
            float _GlowIntensity;

            TEXTURE2D (_DistortTex);SAMPLER(sampler_DistortTex);
            float4 _DistortTex_ST;
            float _DistortTexXSpeed, _DistortTexYSpeed, _DistortAmount;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float2 uvOutDistTex : TEXCOORD1;
                half4 color : COLOR;
            };

            v2f vert(appdata v) {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                o.uvOutDistTex = TRANSFORM_TEX(v.uv, _DistortTex);//�õ�_DistortTex�ռ��µ�uv����
                o.color = v.color;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv);//�ȶ�ԭ��ͼƬ��������в����õ���������ɫ

                i.uvOutDistTex.x += (_Time * _DistortTexXSpeed) % 1;//����������ͼ��ʱ��ɱ��������ƶ�
                i.uvOutDistTex.y += (_Time * _DistortTexYSpeed) % 1;
                float outDistortAmnt = (SAMPLE_TEXTURE2D(_DistortTex,sampler_DistortTex, i.uvOutDistTex).r - 0.5) * 0.2 * _DistortAmount;//ͨ����������ͼ��rֵ���õ����εĴ�С����
                float2 destUv = (0, 0);
                destUv.x += outDistortAmnt;//��߿ռ��xy����������εĲ�����ʹ��߱���
                destUv.y += outDistortAmnt;
                float4 noiseCol = SAMPLE_TEXTURE2D(_DistortTex,sampler_DistortTex, destUv);


                half4 emission = SAMPLE_TEXTURE2D(_GlowTex,sampler_GlowTex, i.uv);//�ٶԷ�������ͼ�����õ��������ɫ

                emission.rgb *= emission.a * col.a * _GlowIntensity * _GlowColor;//�ٳ��Է����ǿ�Ⱥͷ������ɫ�õ�һ�����ǿ���ͨ�����ݿ��Ƶ���ɫ
                col.rgb += emission.rgb * noiseCol;//����ԭ����ɫ���Ϸ�����ɫ�ټ���Ť����ɫ

                return col;
            }
            ENDHLSL
        }
    }
}