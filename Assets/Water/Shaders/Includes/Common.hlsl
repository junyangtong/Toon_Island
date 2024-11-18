struct SceneDepth
{
	float raw;
	float linear01;
	float eye;
};

struct SceneData
{
    float3 positionWS;
	float viewDepth;
	float verticalDepth;
};

SceneDepth SampleDepth(float4 screenPos)
{
	SceneDepth depth = (SceneDepth)0;
	
	screenPos.xyz /= screenPos.w;

	depth.raw = SampleSceneDepth(screenPos.xy);
	depth.eye = LinearEyeDepth(depth.raw, _ZBufferParams);
	depth.linear01 = Linear01Depth(depth.raw, _ZBufferParams);

	return depth;
}

float3 ReconstructWorldPosition(float4 screenPos, float3 viewDir, SceneDepth sceneDepth)
{
	#if UNITY_REVERSED_Z
	real rawDepth = sceneDepth.raw;
	#else
	// Adjust z to match NDC for OpenGL
	real rawDepth = lerp(UNITY_NEAR_CLIP_VALUE, 1, sceneDepth.raw);
	#endif

	//Projection to world position
	float3 camPos = GetCurrentViewPosition().xyz;
	float3 worldPos = sceneDepth.eye * (viewDir/screenPos.w) - camPos;
	float3 perspWorldPos = -worldPos;

	return perspWorldPos;
}

//Linear depth difference between scene and current (transparent) geometry pixel
float SurfaceDepth(SceneDepth depth, float4 positionCS)
{
	const float sceneDepth = (unity_OrthoParams.w == 0) ? depth.eye : LinearDepthToEyeDepth(depth.raw);
	const float clipSpaceDepth = (unity_OrthoParams.w == 0) ? LinearEyeDepth(positionCS.z, _ZBufferParams) : LinearDepthToEyeDepth(positionCS.z / positionCS.w);

	return sceneDepth - clipSpaceDepth;
}

float DepthDistance(float3 wPos, float3 viewPos, float3 normal)
{
	return length((wPos - viewPos) * normal);
}
