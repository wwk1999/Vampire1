// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Dong/ice"
{
	Properties
	{
		[HDR]_Color("Color", Color) = (0,0,0,0)
		[HDR]_emm_color("emm_color", Color) = (0,0,0,0)
		_emm_fanwei("emm_fanwei", Float) = 0
		_base("base", 2D) = "white" {}
		_normal("normal", 2D) = "white" {}
		_refra("refra", 2D) = "white" {}
		_cucaodu("cucaodu", Float) = 0
		_jinshu("jinshu", Float) = 0
		[HDR]_fre_Color("fre_Color", Color) = (0,0,0,0)
		_fre_scale("fre_scale", Float) = 1
		_fre_power("fre_power", Float) = 5
		[Header(Refraction)]
		_ChromaticAberration("Chromatic Aberration", Range( 0 , 0.3)) = 0.1
		[Toggle(_FANGXIANG_ON)] _fangxiang("fangxiang", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha , SrcAlpha OneMinusSrcAlpha
		
		GrabPass{ }
		CGPROGRAM
		#pragma target 3.0
		#pragma shader_feature _FANGXIANG_ON
		#pragma multi_compile _ALPHAPREMULTIPLY_ON
		#pragma surface surf Standard keepalpha finalcolor:RefractionF noshadow exclude_path:deferred noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
			float3 worldPos;
			float3 worldNormal;
			INTERNAL_DATA
			float4 vertexColor : COLOR;
			float4 screenPos;
		};

		uniform sampler2D _normal;
		uniform float4 _normal_ST;
		uniform float4 _fre_Color;
		uniform float _fre_scale;
		uniform float _fre_power;
		uniform sampler2D _base;
		uniform float4 _base_ST;
		uniform float4 _Color;
		uniform float _emm_fanwei;
		uniform float4 _emm_color;
		uniform float _jinshu;
		uniform float _cucaodu;
		uniform sampler2D _GrabTexture;
		uniform float _ChromaticAberration;
		uniform sampler2D _refra;
		uniform float4 _refra_ST;

		inline float4 Refraction( Input i, SurfaceOutputStandard o, float indexOfRefraction, float chomaticAberration ) {
			float3 worldNormal = o.Normal;
			float4 screenPos = i.screenPos;
			#if UNITY_UV_STARTS_AT_TOP
				float scale = -1.0;
			#else
				float scale = 1.0;
			#endif
			float halfPosW = screenPos.w * 0.5;
			screenPos.y = ( screenPos.y - halfPosW ) * _ProjectionParams.x * scale + halfPosW;
			#if SHADER_API_D3D9 || SHADER_API_D3D11
				screenPos.w += 0.00000000001;
			#endif
			float2 projScreenPos = ( screenPos / screenPos.w ).xy;
			float3 worldViewDir = normalize( UnityWorldSpaceViewDir( i.worldPos ) );
			float3 refractionOffset = ( ( ( ( indexOfRefraction - 1.0 ) * mul( UNITY_MATRIX_V, float4( worldNormal, 0.0 ) ) ) * ( 1.0 / ( screenPos.z + 1.0 ) ) ) * ( 1.0 - dot( worldNormal, worldViewDir ) ) );
			float2 cameraRefraction = float2( refractionOffset.x, -( refractionOffset.y * _ProjectionParams.x ) );
			float4 redAlpha = tex2D( _GrabTexture, ( projScreenPos + cameraRefraction ) );
			float green = tex2D( _GrabTexture, ( projScreenPos + ( cameraRefraction * ( 1.0 - chomaticAberration ) ) ) ).g;
			float blue = tex2D( _GrabTexture, ( projScreenPos + ( cameraRefraction * ( 1.0 + chomaticAberration ) ) ) ).b;
			return float4( redAlpha.r, green, blue, redAlpha.a );
		}

		void RefractionF( Input i, SurfaceOutputStandard o, inout half4 color )
		{
			#ifdef UNITY_PASS_FORWARDBASE
			float2 uv_refra = i.uv_texcoord * _refra_ST.xy + _refra_ST.zw;
			color.rgb = color.rgb + Refraction( i, o, tex2D( _refra, uv_refra ).r, _ChromaticAberration ) * ( 1 - color.a );
			color.a = 1;
			#endif
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Normal = float3(0,0,1);
			float2 uv_normal = i.uv_texcoord * _normal_ST.xy + _normal_ST.zw;
			o.Normal = tex2D( _normal, uv_normal ).rgb;
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float fresnelNdotV12 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode12 = ( 0.0 + _fre_scale * pow( 1.0 - fresnelNdotV12, _fre_power ) );
			float2 uv_base = i.uv_texcoord * _base_ST.xy + _base_ST.zw;
			float4 tex2DNode1 = tex2D( _base, uv_base );
			o.Albedo = ( ( _fre_Color * fresnelNode12 ) + ( tex2DNode1 * i.vertexColor * _Color ) ).rgb;
			#ifdef _FANGXIANG_ON
				float staticSwitch28 = i.uv_texcoord.y;
			#else
				float staticSwitch28 = i.uv_texcoord.x;
			#endif
			o.Emission = ( saturate( ( tex2DNode1 * ( staticSwitch28 + _emm_fanwei ) ) ) * _emm_color ).rgb;
			o.Metallic = _jinshu;
			o.Smoothness = _cucaodu;
			o.Alpha = i.vertexColor.a;
			o.Normal = o.Normal + 0.00001 * i.screenPos * i.worldPos;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16600
554;408;1906;971;1376.458;18.14549;1.6;True;True
Node;AmplifyShaderEditor.TextureCoordinatesNode;21;-1578.021,496.2064;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;28;-1311.59,411.4507;Float;False;Property;_fangxiang;fangxiang;14;0;Create;True;0;0;False;0;0;0;1;True;;Toggle;2;Key0;Key1;Create;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;24;-1514.062,684.3219;Float;False;Property;_emm_fanwei;emm_fanwei;2;0;Create;True;0;0;False;0;0;0.28;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-1460.4,-116;Float;True;Property;_base;base;3;0;Create;True;0;0;False;0;None;4db015e106ffb374bb6a06536efa5a12;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;23;-1034.995,517.5261;Float;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;-1188.559,-199.9938;Float;False;Property;_fre_power;fre_power;11;0;Create;True;0;0;False;0;5;2.82;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;14;-1191.559,-274.9938;Float;False;Property;_fre_scale;fre_scale;10;0;Create;True;0;0;False;0;1;0.9;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;5;-1441.531,190.9587;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-624.9026,305.5828;Float;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;9;-1140.976,96.5069;Float;False;Property;_Color;Color;0;1;[HDR];Create;True;0;0;False;0;0,0,0,0;1.498039,1.498039,1.498039,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;18;-779.4609,-587.8226;Float;False;Property;_fre_Color;fre_Color;9;1;[HDR];Create;True;0;0;False;0;0,0,0,0;8.359743,15.22324,20.37087,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FresnelNode;12;-919.0201,-351.5996;Float;False;Standard;WorldNormal;ViewDir;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;31;-526.2628,578.0193;Float;False;Property;_emm_color;emm_color;1;1;[HDR];Create;True;0;0;False;0;0,0,0,0;0.2924528,0.2800374,0.2800374,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;26;-401.6729,313.1074;Float;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-907.6719,-88.44466;Float;True;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-516.559,-305.9938;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-239.2615,383.8496;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;16;-257.5593,-105.9938;Float;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-285.98,180.6734;Float;False;Property;_cucaodu;cucaodu;7;0;Create;True;0;0;False;0;0;0.78;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-281.1729,104.7002;Float;False;Property;_jinshu;jinshu;8;0;Create;True;0;0;False;0;0;0.58;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;2;-679.6542,18.19572;Float;True;Property;_normal;normal;4;0;Create;True;0;0;False;0;None;665b2e9dbee1b8443a866a772c6efb63;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;3;-304.6699,826.5436;Float;True;Property;_refra;refra;6;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;702.9999,111.7;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Dong/ice;False;False;False;False;True;True;True;True;True;True;True;True;False;False;True;False;False;False;False;False;False;Back;1;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Transparent;;Geometry;ForwardOnly;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;2;5;False;-1;10;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;5;-1;12;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.139;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;28;1;21;1
WireConnection;28;0;21;2
WireConnection;23;0;28;0
WireConnection;23;1;24;0
WireConnection;19;0;1;0
WireConnection;19;1;23;0
WireConnection;12;2;14;0
WireConnection;12;3;15;0
WireConnection;26;0;19;0
WireConnection;7;0;1;0
WireConnection;7;1;5;0
WireConnection;7;2;9;0
WireConnection;17;0;18;0
WireConnection;17;1;12;0
WireConnection;30;0;26;0
WireConnection;30;1;31;0
WireConnection;16;0;17;0
WireConnection;16;1;7;0
WireConnection;0;0;16;0
WireConnection;0;1;2;0
WireConnection;0;2;30;0
WireConnection;0;3;10;0
WireConnection;0;4;11;0
WireConnection;0;8;3;1
WireConnection;0;9;5;4
ASEEND*/
//CHKSM=44B54BDDDBBBAFBEE592362108026BD2DDFA7CA0