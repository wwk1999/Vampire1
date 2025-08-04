Shader "Hidden/Pixel" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        _PixelateSize ("Pixelate size", Range(4, 512)) = 32 //���ش�С

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
            float _PixelateSize;//����_PixelateSize��ֵΪ2����ζ��ÿ����������ᱻ�Ŵ�����

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                half4 color : COLOR;
            };

            v2f vert(appdata v) {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                //����ǰ���ص�����������зŴ� ���ԭʼ������������(0.3, 0.7),�� _PixelateSize��2����ô�Ŵ�����������ͻ���(0.6, 1.4)��
                //round()�������Ŵ�������������������ȡ��������Ŵ�������������(0.6, 1.4)����ô����ȡ����ͻ���(1, 1)���ٴ���С_PixelateSize ������ػ�
                i.uv = round(i.uv * _PixelateSize) / _PixelateSize;
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv) * i.color;//���²���
                clip(col.a - 0.51);//����discard ��alphaС��0.51��ʱ��������ظ��޳�
                return col;
            }
            ENDHLSL
        }
    }
}