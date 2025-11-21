Shader "Hidden/ColorSwap" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        [NoScaleOffset] _ColorSwapTex ("Color Swap Texture", 2D) = "black" { }//����ɫ�õ�RGBͼ
        [HDR]_ColorSwapRed ("Red Channel", Color) = (1, 1, 1, 1) //��ɫͨ������ʲô��ɫ
        _ColorSwapRedLuminosity ("Red luminosity", Range(-1, 1)) = 0.5 //��ɫͨ��Ӱ��Ĵ�С
        [HDR]_ColorSwapGreen ("Green Channel", Color) = (1, 1, 1, 1) //��ɫͨ������ʲô��ɫ
        _ColorSwapGreenLuminosity ("Green luminosity", Range(-1, 1)) = 0.5 //��ɫͨ��Ӱ��Ĵ�С
        [HDR]_ColorSwapBlue ("Blue Channel", Color) = (1, 1, 1, 1) //��ɫͨ������ʲô��ɫ
        _ColorSwapBlueLuminosity ("Blue luminosity", Range(-1, 1)) = 0.5 //��ɫͨ��Ӱ��Ĵ�С
        _ColorSwapBlend ("Color Swap Blend", Range(0, 1)) = 1 //��ɫ��ϳ̶ȵĴ�С

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
            TEXTURE2D (_ColorSwapTex);SAMPLER(sampler_ColorSwapTex);
            half4 _ColorSwapRed, _ColorSwapGreen, _ColorSwapBlue;
            float _ColorSwapRedLuminosity, _ColorSwapGreenLuminosity, _ColorSwapBlueLuminosity, _ColorSwapBlend;

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
                
                float luminance = 0.3 * col.r + 0.59 * col.g + 0.11 * col.b;//�����˵�ǰ���ص����ȣ��Ҷ�ֵ������һЩ��Ӱ�����ܿ�����
                half4 swapMask = SAMPLE_TEXTURE2D(_ColorSwapTex,sampler_ColorSwapTex, i.uv);//��RGBͼ���в���
                swapMask.rgb *= swapMask.a;//ȷ����ɫ������������ȷӦ�� RGBͼû�еĵط����Ǻڵ�
                half3 redSwap = _ColorSwapRed * swapMask.r * saturate(luminance + _ColorSwapRedLuminosity);//�����˺�ɫͨ������ɫ����Ч��
                half3 greenSwap = _ColorSwapGreen * swapMask.g * saturate(luminance + _ColorSwapGreenLuminosity);//��������ɫͨ������ɫ����Ч��
                half3 blueSwap = _ColorSwapBlue * swapMask.b * saturate(luminance + _ColorSwapBlueLuminosity);//��������ɫͨ������ɫ����Ч��
                swapMask.rgb = col.rgb * saturate(1 - swapMask.r - swapMask.g - swapMask.b);//�����˵�ǰƬԪÿ����ɫ��������ɫ�����ĳ̶�
                col.rgb = lerp(col.rgb, swapMask.rgb + redSwap + greenSwap + blueSwap, _ColorSwapBlend);//��ԭʼɫ�뽻������ɫ��� ����_ColorSwapBlend����

                return col;
            }
            ENDHLSL
        }
    }
}