// Made with Amplify Shader Editor v1.9.1.5
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BGLight"
{
	Properties
	{
		_noise("noise", 2D) = "white" {}
		_speed("speed", Vector) = (0.3,0.3,0,0)
		[HDR]_Color0("Color 0", Color) = (5.992157,0,0,0)
		_back("back", 2D) = "white" {}
		_back_speed("back_speed", Vector) = (2,2,0.2,0.2)
		_addtex("addtex", 2D) = "white" {}
		_noisetex("noisetex", 2D) = "white" {}
		_noise_speed("noise_speed", Vector) = (1,1,0.2,0.2)
		_lerp("lerp", Range( 0 , 1)) = 0.2352941
		_MainTex("MainTex", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Opaque" "Queue"="Transparent" }
	LOD 100

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaToMask Off
		Cull Back
		ColorMask RGBA
		ZWrite Off
		ZTest LEqual
		Offset 0 , 0
		
		
		
		Pass
		{
			Name "Unlit"

			CGPROGRAM

			

			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			//only defining to not throw compilation error over Unity 5.5
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"
			#include "UnityShaderVariables.cginc"


			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 worldPos : TEXCOORD0;
				#endif
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform sampler2D _noise;
			uniform float2 _speed;
			uniform float4 _Color0;
			uniform sampler2D _back;
			uniform float4 _back_speed;
			uniform sampler2D _addtex;
			uniform sampler2D _noisetex;
			uniform float4 _noise_speed;
			uniform float _lerp;

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				o.ase_texcoord1.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord1.zw = 0;
				float3 vertexValue = float3(0, 0, 0);
				#if ASE_ABSOLUTE_VERTEX_POS
				vertexValue = v.vertex.xyz;
				#endif
				vertexValue = vertexValue;
				#if ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif
				o.vertex = UnityObjectToClipPos(v.vertex);

				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				#endif
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
				fixed4 finalColor;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 WorldPosition = i.worldPos;
				#endif
				float2 uv_MainTex = i.ase_texcoord1.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				float2 texCoord3 = i.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float2 panner2 = ( 1.0 * _Time.y * _speed + texCoord3);
				float2 appendResult22 = (float2(_back_speed.z , _back_speed.w));
				float2 texCoord17 = i.ase_texcoord1.xy * float2( 1,1 ) + float2( 0,0 );
				float2 temp_output_38_0 = (texCoord17).xy;
				float2 appendResult21 = (float2(_back_speed.x , _back_speed.y));
				float2 panner16 = ( 1.0 * _Time.y * appendResult22 + ( temp_output_38_0 * appendResult21 ));
				float2 appendResult30 = (float2(_noise_speed.z , _noise_speed.w));
				float2 appendResult28 = (float2(_noise_speed.x , _noise_speed.y));
				float2 panner26 = ( 1.0 * _Time.y * appendResult30 + ( temp_output_38_0 * appendResult28 ));
				float2 temp_cast_0 = (tex2D( _noisetex, panner26 ).r).xx;
				float2 lerpResult31 = lerp( temp_output_38_0 , temp_cast_0 , _lerp);
				
				
				finalColor = ( tex2D( _MainTex, uv_MainTex ) + ( pow( tex2D( _noise, panner2 ).r , 1.5 ) * _Color0 ) + ( tex2D( _back, panner16 ) + tex2D( _addtex, lerpResult31 ) ) );
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	Fallback Off
}
/*ASEBEGIN
Version=19105
Node;AmplifyShaderEditor.CommentaryNode;57;-2411.101,-32.30973;Inherit;False;2936.891;962.6047;噪声流光;19;19;21;16;23;25;26;29;28;30;27;31;32;33;35;22;18;15;38;17;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;14;-1536.063,-1100.341;Inherit;False;1609.59;805.8;背景光;9;2;3;4;1;9;6;5;8;56;;1,1,1,1;0;0
Node;AmplifyShaderEditor.PannerNode;2;-1162.063,-811.3416;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;3;-1486.063,-822.3416;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;4;-1463.063,-624.3417;Inherit;False;Property;_speed;speed;1;0;Create;True;0;0;0;False;0;False;0.3,0.3;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SamplerNode;1;-867.0637,-806.3416;Inherit;True;Property;_noise;noise;0;0;Create;True;0;0;0;False;0;False;-1;0c8bc51d86c687d40b903749535bfb90;0c8bc51d86c687d40b903749535bfb90;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PowerNode;9;-546.0636,-741.3416;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-353.0632,-766.3416;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-667.0636,-577.3417;Inherit;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;0;False;0;False;1.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;5;-820.0635,-502.3419;Inherit;False;Property;_Color0;Color 0;2;1;[HDR];Create;True;0;0;0;False;0;False;5.992157,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-897.142,49.05298;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;21;-1114.142,95.05296;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;16;-720.1417,43.05298;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;23;-504.142,429.0529;Inherit;True;Property;_addtex;addtex;5;0;Create;True;0;0;0;False;0;False;-1;33ac78a97bfd14c9caffc2e125c28380;33ac78a97bfd14c9caffc2e125c28380;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;25;-1326.741,652.1304;Inherit;True;Property;_noisetex;noisetex;6;0;Create;True;0;0;0;False;0;False;-1;061eb21adf6997f4c8451d6001ee578a;061eb21adf6997f4c8451d6001ee578a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;26;-1643.383,660.1721;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;29;-1899.709,524.4687;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;28;-2113.82,606.8962;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;30;-2066.575,766.7244;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector4Node;27;-2361.101,603.8806;Inherit;False;Property;_noise_speed;noise_speed;7;0;Create;True;0;0;0;False;0;False;1,1,0.2,0.2;1,1,0.2,0.2;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;31;-912.5947,443.0468;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;32;-1193.048,560.6565;Inherit;False;Property;_lerp;lerp;8;0;Create;True;0;0;0;False;0;False;0.2352941;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;33;-466.2822,722.4954;Inherit;False;Property;_Color1;Color 1;9;1;[HDR];Create;True;0;0;0;False;0;False;1,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;35;290.64,267.1346;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;22;-1039.142,231.0529;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector4Node;18;-1309.142,150.0529;Inherit;False;Property;_back_speed;back_speed;4;0;Create;True;0;0;0;False;0;False;2,2,0.2,0.2;1,1,1,1;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;15;-508.4818,17.69027;Inherit;True;Property;_back;back;3;0;Create;True;0;0;0;False;0;False;-1;1ffba5434824f4a1db4a27621f6c847a;1ffba5434824f4a1db4a27621f6c847a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ComponentMaskNode;38;-2003.975,105.1621;Inherit;False;True;True;True;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;17;-2299.752,73.09464;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;12;745.076,-570.4532;Inherit;True;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;58;1230.818,-548.6644;Float;False;True;-1;2;ASEMaterialInspector;100;5;BGLight;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;True;True;2;5;False;;10;False;;0;1;False;;0;False;;True;0;False;;0;False;;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;True;True;2;False;;True;3;False;;True;True;0;False;;0;False;;True;2;RenderType=Opaque=RenderType;Queue=Transparent=Queue=0;True;2;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;0;1;True;False;;False;0
Node;AmplifyShaderEditor.SamplerNode;56;-476.6449,-991.3557;Inherit;True;Property;_MainTex;MainTex;10;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
WireConnection;2;0;3;0
WireConnection;2;2;4;0
WireConnection;1;1;2;0
WireConnection;9;0;1;1
WireConnection;9;1;8;0
WireConnection;6;0;9;0
WireConnection;6;1;5;0
WireConnection;19;0;38;0
WireConnection;19;1;21;0
WireConnection;21;0;18;1
WireConnection;21;1;18;2
WireConnection;16;0;19;0
WireConnection;16;2;22;0
WireConnection;23;1;31;0
WireConnection;25;1;26;0
WireConnection;26;0;29;0
WireConnection;26;2;30;0
WireConnection;29;0;38;0
WireConnection;29;1;28;0
WireConnection;28;0;27;1
WireConnection;28;1;27;2
WireConnection;30;0;27;3
WireConnection;30;1;27;4
WireConnection;31;0;38;0
WireConnection;31;1;25;1
WireConnection;31;2;32;0
WireConnection;35;0;15;0
WireConnection;35;1;23;0
WireConnection;22;0;18;3
WireConnection;22;1;18;4
WireConnection;15;1;16;0
WireConnection;38;0;17;0
WireConnection;12;0;56;0
WireConnection;12;1;6;0
WireConnection;12;2;35;0
WireConnection;58;0;12;0
ASEEND*/
//CHKSM=57806A6B8E6BCCEBC964A78AEAC0554E58A2C8F4