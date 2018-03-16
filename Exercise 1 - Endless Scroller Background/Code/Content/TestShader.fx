Texture2D MainTexture;
sampler2D _MainTexture = sampler_state { Texture = <MainTexture>; };

float totalSeconds;
float speed = 1;




struct v2f
{
	// required vars
	float4 position : SV_POSITION;
	float4 color : COLOR;

	float2 uv : TEXCOORD;
};


float4 PixelShaderFunction(v2f i) : COLOR
{
	float4 color = tex2D(_MainTexture, i.uv + float2(totalSeconds * speed, 0.0f));
	return color;
}


technique Technique1
{
	pass Pass1
	{
		PixelShader = compile ps_4_0_level_9_1 PixelShaderFunction();
	}
}
