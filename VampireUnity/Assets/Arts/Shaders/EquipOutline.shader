Shader "Custom/EquipOutline"
{
    Properties
    {
        [Header(Main Texture)]
        _MainTex ("Main Texture", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,1)
        
        [Header(Outline Settings)]
        [HDR]_OutlineColor ("Outline Color", Color) = (1, 0.5, 0, 1)
        _OutlineWidth ("Outline Width", Int) = 1
        _OutlineAlpha ("Outline Alpha", Range(0.0, 1.0)) = 1.0
        
        [Header(Advanced)]
        [Toggle] _UseVertexColor ("Use Vertex Color", Float) = 0
    }
    
    SubShader
    {
        Tags 
        { 
            "RenderType"="Transparent" 
            "Queue"="Transparent"
        }
        LOD 200
        
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float4 color : COLOR;
                UNITY_FOG_COORDS(1)
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;
            float4 _Color;
            float4 _OutlineColor;
            int _OutlineWidth;
            float _OutlineAlpha;
            float _UseVertexColor;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                UNITY_TRANSFER_FOG(o, o.pos);
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                // 采样主纹理
                fixed4 texColor = tex2D(_MainTex, i.uv);
                float originalAlpha = texColor.a;
                
                // 计算描边偏移量（基于像素大小）
                float2 outlineOffset = float2(_OutlineWidth * _MainTex_TexelSize.x, _OutlineWidth * _MainTex_TexelSize.y);
                
                // 采样周围8个方向的alpha值来检测边缘
                float spriteLeft = tex2D(_MainTex, i.uv + float2(outlineOffset.x, 0)).a;
                float spriteRight = tex2D(_MainTex, i.uv - float2(outlineOffset.x, 0)).a;
                float spriteBottom = tex2D(_MainTex, i.uv + float2(0, outlineOffset.y)).a;
                float spriteTop = tex2D(_MainTex, i.uv - float2(0, outlineOffset.y)).a;
                float spriteTopLeft = tex2D(_MainTex, i.uv + float2(outlineOffset.x, outlineOffset.y)).a;
                float spriteTopRight = tex2D(_MainTex, i.uv + float2(-outlineOffset.x, outlineOffset.y)).a;
                float spriteBotLeft = tex2D(_MainTex, i.uv + float2(outlineOffset.x, -outlineOffset.y)).a;
                float spriteBotRight = tex2D(_MainTex, i.uv + float2(-outlineOffset.x, -outlineOffset.y)).a;
                
                // 计算周围是否有像素（用于检测边缘）
                float outlineMask = spriteLeft + spriteRight + spriteBottom + spriteTop + 
                                    spriteTopLeft + spriteTopRight + spriteBotLeft + spriteBotRight;
                
                // 如果周围有像素但当前像素是透明的，说明这是描边区域
                outlineMask = step(0.05, saturate(outlineMask));
                outlineMask *= (1.0 - originalAlpha) * _OutlineAlpha;
                
                // 混合描边颜色和原始颜色
                fixed4 col = texColor * _Color;
                
                // 使用顶点颜色
                if (_UseVertexColor > 0.5)
                {
                    col *= i.color;
                }
                
                // 应用描边
                col = lerp(col, _OutlineColor, outlineMask);
                
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
    
    FallBack "Sprites/Default"
}

