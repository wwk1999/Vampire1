Shader "Hidden/Gradient" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        _GradBlend ("GradientBlend", Range(0, 1)) = 1 //��ɫ��ϵĳ̶�
        _GradTopLeftCol ("TopLeftCol", Color) = (1, 0, 0, 1) //���Ͻǵ���ɫ
        _GradTopRightCol ("TopRightColor", Color) = (1, 1, 0, 1) //���Ͻǵ���ɫ
        _GradBottomLeftColor ("BottomLeftColor", Color) = (0, 0, 1, 1) //���½ǵ���ɫ
        _GradBottomRightColor ("BottomRightColor", Color) = (0, 1, 0, 1) //���½ǵ���ɫ
        _GradBoostX ("GradBoostX", Range(0.1, 2)) = 1.2 //��ߺ��ұߵ�ռ��
        _GradBoostY ("_GradBoostY", Range(0.1, 2)) = 1.2 //�ϱߺ��±ߵ�ռ��

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
            float2 _MainTex_ST;
            float _GradBlend, _GradBoostX, _GradBoostY;
            half4 _GradTopRightCol, _GradTopLeftCol, _GradBotRightCol, _GradBotLeftCol;

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

            half4 frag(v2f i) : SV_Target {
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv);

                float gradXLerpFactor = saturate(pow(i.uv.x, _GradBoostX));//ˮƽ�ݶȵ�ƽ������ ��pow���㣬��Ҳ��֪��Ϊʲô
                float gradYLerpFactor = saturate(pow(i.uv.y, _GradBoostY));//��ֱ�ݶȵ�ƽ������
                //����ˮƽ�ʹ�ֱ����Ĳ�ֵ����,�Լ���ɫ�ݶȵ��ĸ���ɫ����ɫ,ֵͨ��˫���Բ�ֵ��������յ���ɫ�ݶ�Ч����
                half4 gradientResult = lerp(lerp(_GradBotLeftCol, _GradBotRightCol, gradXLerpFactor),
                lerp(_GradTopLeftCol, _GradTopRightCol, gradXLerpFactor), gradYLerpFactor);
                gradientResult = lerp(col, gradientResult, _GradBlend);//����ɫ�ݶ�Ч����ԭʼ������ɫ���л�ϣ�����_GradBlend��ֵ���в�ֵ��
                col.rgb = gradientResult.rgb * col.a;//����Ϻ����ɫӦ�õ�ԭʼ��ɫ��RGB�����ϣ�ͬʱ����ԭʼ��ɫ��͸���ȣ���ȷ����ɫ��Ϻ��͸������ȷ
                return col;
            }
            ENDHLSL
        }
    }
}