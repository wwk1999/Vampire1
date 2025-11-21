Shader "Hidden/Glitch" {
    //���һЩ�Ӿ��ϵġ����ϡ�Ч��
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        _GlitchAmount ("Glitch Amount", Range(0, 20)) = 3 //ƫ����ƶ���Χ��С
        _GlitchSize ("Glitch Size", Range(0.25, 5)) = 1 //ƫ��Ŀ�����С

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
            half _GlitchAmount, _GlitchSize;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            //����α�����
            half rand2(half2 seed, half offset) {
                //50 + (_Time % 1.0) * 12����ʱ������һ�������float�ͱ���
                //�������������half2(127.1, 311.7)�õ�һ���µ�����
                //����˽���������Һ����У������������
                //frac���ڻ�ȡ��������С�����ֵĺ��� �м����һ���ܴ���޹��ɵ����ټ���ƫ�������ڵ���������ķ�Χ
                //�����ȡ��1.0��ȷ���������[0, 1)��Χ��
                return (frac(sin(dot(seed * floor(50 + (_Time % 1.0) * 12), half2(127.1, 311.7))) * 43758.5453123) + offset) % 1.0;
            }

            v2f vert(appdata v) {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv);
                
                //_GlitchSize ��һ�����������ڵ���������������ű�����
                //�������������half2(24, 19)����������ķ�Χ���ŵ����ʵķ�Χ
                //Ȼ�����_GlitchSize����ȡfloor���������ճ���4��������������Ƶ��
                //�����õ�����һ������������ӣ����ڲ�������
                //��rand2������һ�������
                //���ɵ�������������������㣬�⽫����������ǿ�ȣ�ʹ���������
                //�ڶ���������һ��������ƣ�ֻ��ʹ���˲�ͬ�Ĳ������ڶ����������������һ����������������������һ�𣬲������Ӹ��ӵ�Ч��
                //lineNoise �����洢�����������ĳ˻������������Ŷ���������
                half lineNoise = pow(rand2(floor(i.uv * half2(24, 19) * _GlitchSize) * 4, 1), 3.0) * _GlitchAmount
                * pow(rand2(floor(i.uv * half2(38, 14) * _GlitchSize) * 4, 1), 3.0);
                //���������ɵ������������Ӧ�õ���ǰ���ص����������ϣ��Ӷ������˺�����Ŷ����ٽ��в���
                col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv + half2(lineNoise * 0.02 * rand2(half2(2.0, 1), 1), 0));
                
                return col;
            }
            ENDHLSL
        }
    }
}