Shader "Hidden/Hologram" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        _HologramStripesAmount ("Stripes Amount", Range(0, 1)) = 0.1 //��������
        _HologramStripesSpeed ("Stripes Speed", Range(-20, 20)) = 4.5 //�����ƶ��ٶ�
        _HologramMinAlpha ("Min Alpha", Range(0, 1)) = 0.1 //��С��alphaֵ
        _HologramMaxAlpha ("Max Alpha", Range(0, 1)) = 0.75 //����alphaֵ
        _HologramStripeColor ("Stripes Color", Color) = (0, 1, 1, 1) //������ɫ
        _HologramBlend ("Hologram Blend", Range(0, 1)) = 1 //��ɫ��ϳ̶�

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
            half _HologramStripesAmount, _HologramMinAlpha, _HologramStripesSpeed, _HologramMaxAlpha, _HologramBlend;
            half4 _HologramStripeColor;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            //���ڽ�һ����Χ�ڵ�ֵӳ�䵽��һ����Χ��
            half RemapFloat(half inValue, half inMin, half inMax, half outMin, half outMax) {
                return outMin + (inValue - inMin) * (outMax - outMin) / (inMax - inMin);
            }

            v2f vert(appdata v) {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target {
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex, i.uv);

                half totalHologram = _HologramStripesAmount;
                half hologramYCoord = ((i.uv.y + (((_Time.x) % 1) * _HologramStripesSpeed)) % totalHologram) / totalHologram;//����ȫϢ���Ƶ�Y����λ��
                hologramYCoord = abs(hologramYCoord);//ȡȫϢ���Ƶľ���ֵ��ȷ��Y������������Χ��
                half alpha = RemapFloat(saturate(hologramYCoord), 0.0, 1.0, _HologramMinAlpha, saturate(_HologramMaxAlpha));//�������Ƶ�Y�������alphaֵ
                half hologramMask = max(sign(-hologramYCoord), 0.0);//����һ�����ڿ���ȫϢЧ������ʾ��Χ��ֵ
                half4 hologramResult = col;
                hologramResult.a *= lerp(alpha, 1, hologramMask);//���ݼ����alphaֵ������ֵ������hologramResult��alphaͨ��ֵ
                hologramResult.rgb *= max(1, _HologramMaxAlpha * max(sign(hologramYCoord), 0.0));//�������Ƶ�Y����λ�ã�����hologramResult��RGB��ɫֵ
                hologramMask = 1 - step(0.01, hologramMask);//��������ֵ������һ���������롣�������ֵС��0.01����������Ϊ1����������Ϊ0
                hologramResult.rgb += hologramMask * _HologramStripeColor * col.a;//���ݷ������룬���ȫϢ���Ƶ���ɫ
                col = lerp(col, hologramResult, _HologramBlend);//��ԭʼ��ɫcol�;���ȫϢЧ����������ɫhologramResult���л��

                return col;
            }
            ENDHLSL
        }
    }
}