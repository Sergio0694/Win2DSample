using ComputeSharp;
using ComputeSharp.D2D1;

namespace Win2DRenderer.Shaders;

[D2DInputCount(2)]
[D2DInputSimple(0)]
[D2DInputSimple(1)]
[D2DShaderProfile(D2D1ShaderProfile.PixelShader40)]
[AutoConstructor]
internal readonly partial struct HeightmapShader : ID2D1PixelShader
{
    private readonly float time;
    private readonly float3 factors;

    public float4 Execute()
    {
        // Read the inputs from both textures, at the current position
        float4 texturePixel = D2D.GetInput(0);
        float4 heightmapPixel = D2D.GetInput(1);

        // Time varying pixel color
        float3 color = 0.5f + (0.5f * Hlsl.Cos(this.time + texturePixel.XYZ + this.factors));

        // Combine the two input colors in some way (ignore alpha)
        float3 result = Hlsl.Saturate(color * heightmapPixel.XYZ);

        return new(result, 1.0f);
    }
}
