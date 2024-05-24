Shader "Graph/Point Surface"
{
	Properties{
		_Smoothness("Smoothness",Range(0,1)) =0.5
		}
	SubShader
	{
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		#pragma target 3.0
		struct Input {
			float3 worldPos;
			};
			float _Smoothness;
			void ConfigureSurface(Input input,inout SurfaceOutputStandard surface){
				surface.Smoothness = _Smoothness;
				float  x = abs(input.worldPos.x);
				float y= abs(input.worldPos.y);
				float z  = abs(input.worldPos.z);
				surface.Albedo = float3(sin(x),cos(x),1.0)*0.5;
				}
		ENDCG
	}
	FallBack "Diffuse"
}