Shader "Hidden/Blur" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        _BlurIntensity ("Blur Intensity", Range(0, 12)) = 10 //ģ��ǿ��

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
            half _BlurIntensity;

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

            //�����˹ģ���еĸ�˹������ֵ�ĺ���
            half BlurHD_G(half bhqp, half x) {//bhqp��һ��Ӱ���˹������״�Ĳ�������x�����Ա���
                return exp( - (x * x) / (2.0 * bhqp * bhqp));//exp��ʾ��Ȼָ������,����e��x���� -(x*x)/(2.0*bhqp*bhqp):���Ǹ�˹������ָ������
            }

            //ʵ���˸�˹ģ���Ĺ���
            //uv��ʾ��ǰ���ص��������꣬source�����������Intensity��ģ����ǿ�ȣ�xScale��yScale�ֱ��ʾˮƽ�ʹ�ֱ��������ű�����
            half4 BlurHD(half2 uv, sampler2D source, half Intensity, half xScale, half yScale) {
                int iterations = 16;//������ģ���ĵ�������������ģ�������в����Ĵ���
                int halfIterations = iterations / 2;//�������������һ�룬����ȷ��ģ���˵�����λ��
                half sigmaX = 0.1 + Intensity * 0.5;//����ˮƽ�ʹ�ֱ����ĸ�˹ģ���ı�׼�Intensity�������ڵ���ģ����ǿ�ȣ�Խ����ģ���̶�Խ��
                half sigmaY = sigmaX;
                half total = 0.0;//��ʼ����Ȩ��
                half4 ret = half4(0, 0, 0, 0);//��ʼ��ģ�����
                for (int iy = 0; iy < iterations; ++iy) {//�ڲ�ѭ������ˮƽ����ĵ�������
                    half fy = BlurHD_G(sigmaY, half(iy) - half(halfIterations));//���㵱ǰˮƽ����ĸ�˹Ȩ��
                    half offsetY = half(iy - halfIterations) * 0.00390625 * xScale;//���㵱ǰ���������������е�ƫ����
                    for (int ix = 0; ix < iterations; ++ix) {////�ڲ�ѭ��������ֱ����ĵ�������
                        half fx = BlurHD_G(sigmaX, half(ix) - half(halfIterations));//���㵱ǰ���������������е�ˮƽƫ����
                        half offsetX = half(ix - halfIterations) * 0.00390625 * yScale;//���㵱ǰ���������������е�ˮƽƫ����
                        total += fx * fy;//�ۼӵ�ǰ���ص�Ȩ��
                        ret += SAMPLE_TEXTURE2D(source,samplersource, uv + half2(offsetX, offsetY)) * fx * fy;//���ݵ�ǰ���ص�Ȩ�أ������������������ģ�������
                    }
                }
                return ret / total;//�������յ�ģ�������������Ȩ���Թ�һ�������
            }

            v2f vert(appdata v) {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv);
                col = BlurHD(i.uv, _MainTex, _BlurIntensity, 1, 1) * i.color;
                return col;
            }
            ENDHLSL
        }
    }
}