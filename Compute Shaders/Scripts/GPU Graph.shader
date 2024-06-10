Shader "Graph/Point Surface GPU1" {

	Properties {
		_Smoothness ("Smoothness", Range(0,1)) = 0.5
	}
	
	SubShader {
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows addshadow
		#pragma instancing_options assumeuniformscaling procedural:ConfigureProcedural
		#pragma editor_sync_compilation
		#pragma target 4.5
		#if defined(UNITY_PROCEDURAL_INSTANCING_ENABLED)
StructuredBuffer<float3> _Positions;
#endif

float _Step;

void ConfigureProcedural () {
    #if defined(UNITY_PROCEDURAL_INSTANCING_ENABLED)
    float3 position = _Positions[unity_InstanceID];

    unity_ObjectToWorld = 0.0;
    unity_ObjectToWorld._m03_m13_m23_m33 = float4(position, 1.0);
    unity_ObjectToWorld._m00_m11_m22 = _Step;
    #endif
}

void ShaderGraphFunction_float (float3 In, out float3 Out) {
    Out = In;
}

void ShaderGraphFunction_half (half3 In, out half3 Out) {
    Out = In;
}

		struct Input {
			float3 worldPos;
		};

		float _Smoothness;
		
		void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
			surface.Albedo = saturate(input.worldPos * 0.5 + 0.5);
			surface.Smoothness = _Smoothness;
		}
		ENDCG
	}

	FallBack "Diffuse"
}