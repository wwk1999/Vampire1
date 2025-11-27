Shader "Hidden/Outline"
{
    Properties
    {
        [Space]
        _MainTex("Texture", 2D) = "white" {}

        _OutlineAlpha("OutlineAlpha", Range(0, 1)) = 1 // 描边透明度
        _OutlinePixelWidth("OutlinePixelWidth", Int) = 1 // 描边像素宽度

        _OutlineDistortTex("OutlineDistortionTex", 2D) = "white" {} // 描边扰动图
        _OutlineDistortAmount("OutlineDistortionAmount", Range(0, 2)) = 0.5 // 扰动强度
        _OutlineDistortTexXSpeed("OutlineDistortTexXSpeed", Range(-50, 50)) = 5 // 扰动图 X 方向速度
        _OutlineDistortTexYSpeed("OutlineDistortTexYSpeed", Range(-50, 50)) = 5 // 扰动图 Y 方向速度

        // 描边颜色纹理
        _OutlineTex("Outline Color Tex", 2D) = "white" {}
        // 描边颜色纹理流动速度（让颜色纹理本身也流动）
        _OutlineTexXSpeed("OutlineTexXSpeed", Range(-50, 50)) = 5
        _OutlineTexYSpeed("OutlineTexYSpeed", Range(-50, 50)) = 5
        
        // 描边渐变参数
        _OutlineFadeStart("OutlineFadeStart", Range(0, 1)) = 0.3 // 开始淡出的位置（0=边缘，1=最外侧）
        _OutlineFadeEnd("OutlineFadeEnd", Range(0, 1)) = 1.0 // 完全透明的位置
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex);
            float4 _MainTex_TexelSize;

            float _OutlineAlpha;
            int _OutlinePixelWidth;

            TEXTURE2D(_OutlineDistortTex); SAMPLER(sampler_OutlineDistortTex);
            float4 _OutlineDistortTex_ST;
            float _OutlineDistortTexXSpeed, _OutlineDistortTexYSpeed, _OutlineDistortAmount;

            TEXTURE2D(_OutlineTex); SAMPLER(sampler_OutlineTex);
            float4 _OutlineTex_ST;
            float _OutlineTexXSpeed, _OutlineTexYSpeed;
            
            float _OutlineFadeStart, _OutlineFadeEnd;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv            : TEXCOORD0;
                float2 uvOutDistTex  : TEXCOORD1;
                float2 uvOutlineTex  : TEXCOORD2;
                float4 vertex        : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uvOutDistTex = TRANSFORM_TEX(v.uv, _OutlineDistortTex);
                o.uv = v.uv;
                o.uvOutlineTex = TRANSFORM_TEX(v.uv, _OutlineTex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                //------------ 原图采样 ------------
                half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                float originalAlpha = col.a;

                // 计算时间偏移
                float timeX = _Time.x * _OutlineDistortTexXSpeed;
                float timeY = _Time.x * _OutlineDistortTexYSpeed;

                // 描边取样偏移（像素宽度）
                float2 destUv = float2(
                    _OutlinePixelWidth * _MainTex_TexelSize.x,
                    _OutlinePixelWidth * _MainTex_TexelSize.y
                );

                // 扰动 UV 随时间移动
                float2 uvDistort = i.uvOutDistTex + float2(timeX, timeY);

                // 利用扰动图的 r 通道控制描边膨胀大小
                float outDistortAmnt = (SAMPLE_TEXTURE2D(_OutlineDistortTex, sampler_OutlineDistortTex, uvDistort).r - 0.5) * 0.2 * _OutlineDistortAmount;
                destUv += outDistortAmnt;

                // 八方向采样 alpha 检测是否在描边区域
                float spriteLeft      = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2( destUv.x,  0       )).a;
                float spriteRight     = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2(-destUv.x,  0       )).a;
                float spriteBottom    = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2( 0,         destUv.y)).a;
                float spriteTop       = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2( 0,        -destUv.y)).a;
                float spriteTopLeft   = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2( destUv.x,  destUv.y)).a;
                float spriteTopRight  = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2(-destUv.x,  destUv.y)).a;
                float spriteBotLeft   = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2( destUv.x, -destUv.y)).a;
                float spriteBotRight  = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2(-destUv.x, -destUv.y)).a;

                float result = spriteLeft + spriteRight + spriteBottom + spriteTop +
                               spriteTopLeft + spriteTopRight + spriteBotLeft + spriteBotRight;

                // 计算描边区域（不使用 step，保留原始值用于渐变计算）
                float outlineMask = saturate(result);
                
                // 计算到边缘的距离（通过多次采样来估算距离）
                // 使用更小的偏移量来检测边缘附近的区域
                float2 smallDestUv = destUv * 0.5;
                float nearLeft      = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2( smallDestUv.x,  0       )).a;
                float nearRight     = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2(-smallDestUv.x,  0       )).a;
                float nearBottom    = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2( 0,         smallDestUv.y)).a;
                float nearTop       = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2( 0,        -smallDestUv.y)).a;
                float nearResult = nearLeft + nearRight + nearBottom + nearTop;
                float nearMask = saturate(nearResult);
                
                // 计算距离因子：nearMask 接近 1 表示离边缘近，outlineMask 接近 1 表示在描边区域
                // 使用两者的差值来估算距离边缘的远近
                float distanceFactor = outlineMask - nearMask * 0.5; // 归一化到 0-1，离边缘越远值越大
                distanceFactor = saturate(distanceFactor);
                
                // 创建渐变：离边缘越近（distanceFactor 越小）越清晰，离边缘越远（distanceFactor 越大）越透明
                float fadeAlpha = 1.0 - smoothstep(_OutlineFadeStart, _OutlineFadeEnd, distanceFactor);
                
                // 确保只在描边区域显示
                float finalOutlineAlpha = outlineMask * fadeAlpha * (1 - originalAlpha) * _OutlineAlpha;

                //------------ 方案二：结合扰动图让颜色纹理也有噪声感 ------------
                float outlineTimeX = _Time.x * _OutlineTexXSpeed;
                float outlineTimeY = _Time.x * _OutlineTexYSpeed;
                float2 uvOutlineAnimated = i.uvOutlineTex + float2(outlineTimeX, outlineTimeY);
                
                // 使用扰动图来影响颜色纹理的采样位置，让颜色也有噪声流动
                float2 outlineDistort = (SAMPLE_TEXTURE2D(_OutlineDistortTex, sampler_OutlineDistortTex, uvDistort).rg - 0.5) * _OutlineDistortAmount * 0.1;
                uvOutlineAnimated += outlineDistort;
                
                half4 outlineTexColor = SAMPLE_TEXTURE2D(_OutlineTex, sampler_OutlineTex, uvOutlineAnimated);
                half4 outline = outlineTexColor;
                outline.a *= finalOutlineAlpha; // 应用渐变透明度

                col = lerp(col, outline, finalOutlineAlpha);

                return col;
            }

            ENDHLSL
        }
    }
}