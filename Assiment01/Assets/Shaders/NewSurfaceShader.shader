Shader"Custom/DissolveShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _DissolveAmount ("Dissolve Amount", Range (0, 1)) = 0.5
    }
 
    SubShader
    {
        Tags { "Queue" = "Transparent" }
LOD 100

        CGPROGRAM
        #pragma surface surf Lambert
 
sampler2D _MainTex;
half _DissolveAmount;
 
struct Input
{
    float2 uv_MainTex;
};
 
void surf(Input IN, inout SurfaceOutput o)
{
    half dissolve = smoothstep(_DissolveAmount - 0.1, _DissolveAmount + 0.1, _DissolveAmount - IN.uv_MainTex.x);
    o.Albedo = dissolve * tex2D(_MainTex, IN.uv_MainTex).rgb;
}
        ENDCG
    }
FallBack"Diffuse"
}
