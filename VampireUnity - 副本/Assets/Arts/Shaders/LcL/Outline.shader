Shader "Hidden/Outline" {
    Properties {
        [Space]
        _MainTex("Texture", 2D) = "white" { }
        _OutlineColor ("OutlineColor", Color) = (1, 1, 1, 1) //�����ɫ
        _OutlineAlpha ("OutlineAlpha", Range(0, 1)) = 1 //���͸����
        _OutlinePixelWidth ("OutlinePixelWidth", Int) = 1 //������ص�

        _OutlineDistortTex ("OutlineDistortionTex", 2D) = "white" { }//��ߵı��ε�����ͼ
        _OutlineDistortAmount ("OutlineDistortionAmount", Range(0, 2)) = 0.5 //����ͼ�����Ĵ�Сϵ��
        _OutlineDistortTexXSpeed ("OutlineDistortTexXSpeed", Range(-50, 50)) = 5 //����ͼ������X���ٶ�
        _OutlineDistortTexYSpeed ("OutlineDistortTexYSpeed", Range(-50, 50)) = 5 //����ͼ������Y���ٶ�
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
            float4 _MainTex_TexelSize;//_MainTex������ÿ�����صĳߴ�

            half4 _OutlineColor;
            float _OutlineAlpha;
            int _OutlinePixelWidth;

            TEXTURE2D (_OutlineDistortTex);SAMPLER(sampler_OutlineDistortTex);
            float4 _OutlineDistortTex_ST;
            float _OutlineDistortTexXSpeed, _OutlineDistortTexYSpeed, _OutlineDistortAmount;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float2 uvOutDistTex : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v) {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uvOutDistTex = TRANSFORM_TEX(v.uv, _OutlineDistortTex);//�õ�_OutlineDistortTex�ռ��µ�uv����
                o.uv = v.uv;
                return o;
            }



            half4 frag(v2f i) : SV_Target {
                //------Outline------
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv);//�����������в���
                float originalAlpha = col.a;//ԭʼ��alphaֵ

                float2 destUv = float2(_OutlinePixelWidth * _MainTex_TexelSize.x, _OutlinePixelWidth * _MainTex_TexelSize.y);//�õ���߿ռ�����ش�С

                i.uvOutDistTex.x += (_Time * _OutlineDistortTexXSpeed) % 1;//����������ͼ��ʱ��ɱ��������ƶ�
                i.uvOutDistTex.y += (_Time * _OutlineDistortTexYSpeed) % 1;

                //ͨ����������ͼ��rֵ���õ����εĴ�С����
                float outDistortAmnt = (SAMPLE_TEXTURE2D(_OutlineDistortTex,sampler_OutlineDistortTex, i.uvOutDistTex).r - 0.5) * 0.2 * _OutlineDistortAmount;
                destUv.x += outDistortAmnt;//��߿ռ��xy����������εĲ�����ʹ��߱���
                destUv.y += outDistortAmnt;

                //�õ��˸����������ߵı߽�ֵ��alphaֵ ��Ϊ�����������Ҫ����destUv��ɵ�float2ֵ
                float spriteLeft = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv + float2(destUv.x, 0)).a;
                float spriteRight = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv - float2(destUv.x, 0)).a;
                float spriteBottom = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv + float2(0, destUv.y)).a;
                float spriteTop = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv - float2(0, destUv.y)).a;
                float spriteTopLeft = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv + float2(destUv.x, destUv.y)).a;
                float spriteTopRight = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv + float2(-destUv.x, destUv.y)).a;
                float spriteBotLeft = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv + float2(destUv.x, -destUv.y)).a;
                float spriteBotRight = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv + float2(-destUv.x, -destUv.y)).a;
                float result = spriteLeft + spriteRight + spriteBottom + spriteTop + spriteTopLeft + spriteTopRight + spriteBotLeft + spriteBotRight;

                result = step(0.05, saturate(result));//������Ľ��alphaֵ����0.05����Ϊ1���������0��Ҳ���Ǳ߽��ж���
                result *= (1 - originalAlpha) * _OutlineAlpha;//������ߵ�alphaֵ

                half4 outline = _OutlineColor;//��ߵ���ɫ
                col = lerp(col, outline, result);//��ֵ�����õ�������ɫ

                //------Rotate-----                
                  return col;
            }
            ENDHLSL
        }
    }
}