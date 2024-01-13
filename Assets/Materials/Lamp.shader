Shader "Custom/SphereGradientEmissionShader"
{
    Properties
    {
        _TopColor ("Top Color", Color) = (1, 1, 1, 1)
        _BottomColor ("Bottom Color", Color) = (0, 0, 0, 1)
        _RangeValue ("Range Value", Range(0, 1)) = 0.5
        _EmissionColor ("Emission Color", Color) = (0, 0, 0, 1)
        _EmissionStrength ("Emission Strength", Range(0, 1)) = 0.1
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float3 world_pos; // World position of the pixel
        };

        fixed4 _TopColor;
        fixed4 _BottomColor;
        float _RangeValue;
        fixed4 _EmissionColor;
        float _EmissionStrength;

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Calculate the gradient based on the vertical position of the sphere
            float gradient = saturate(IN.world_pos.y * 0.5 + 0.5); // Map range from [-1, 1] to [0, 1]

            // Interpolate between top and bottom colors using the gradient
            fixed4 finalColor = lerp(_BottomColor, _TopColor, gradient * _RangeValue);

            // Add emission to the final color
            o.Emission = _EmissionColor.rgb * _EmissionStrength;

            // Set the pixel color
            o.Albedo = finalColor.rgb;
            o.Alpha = finalColor.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
