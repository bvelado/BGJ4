// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:5836,x:33055,y:32855,varname:node_5836,prsc:2|emission-9324-OUT,clip-7198-R;n:type:ShaderForge.SFN_Tex2d,id:1297,x:32360,y:32790,ptovrint:False,ptlb:Lava,ptin:_Lava,varname:node_1297,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6579-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:779,x:31969,y:32733,varname:node_779,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:6579,x:32140,y:32733,varname:node_6579,prsc:2,spu:0,spv:0.07|UVIN-779-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7198,x:32212,y:33258,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_7198,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8835-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6210,x:31677,y:33303,varname:node_6210,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:8835,x:31889,y:33303,varname:node_8835,prsc:2,spu:0,spv:0.09|UVIN-6210-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8674,x:32360,y:32548,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_8674,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8302-UVOUT;n:type:ShaderForge.SFN_Panner,id:8302,x:32005,y:32395,varname:node_8302,prsc:2,spu:0,spv:0.05|UVIN-6988-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6988,x:31793,y:32395,varname:node_6988,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:9324,x:32587,y:32684,varname:node_9324,prsc:2|A-8674-RGB,B-1297-RGB;n:type:ShaderForge.SFN_TexCoord,id:839,x:31954,y:32937,varname:node_839,prsc:2,uv:0;proporder:1297-7198-8674;pass:END;sub:END;*/

Shader "Custom/LavaCasShader" {
    Properties {
        _Lava ("Lava", 2D) = "white" {}
        _Opacity ("Opacity", 2D) = "white" {}
        _Noise ("Noise", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Lava; uniform float4 _Lava_ST;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_1501 = _Time + _TimeEditor;
                float2 node_8835 = (i.uv0+node_1501.g*float2(0,0.09));
                float4 _Opacity_var = tex2D(_Opacity,TRANSFORM_TEX(node_8835, _Opacity));
                clip(_Opacity_var.r - 0.5);
////// Lighting:
////// Emissive:
                float2 node_8302 = (i.uv0+node_1501.g*float2(0,0.05));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_8302, _Noise));
                float2 node_6579 = (i.uv0+node_1501.g*float2(0,0.07));
                float4 _Lava_var = tex2D(_Lava,TRANSFORM_TEX(node_6579, _Lava));
                float3 emissive = (_Noise_var.rgb+_Lava_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_8856 = _Time + _TimeEditor;
                float2 node_8835 = (i.uv0+node_8856.g*float2(0,0.09));
                float4 _Opacity_var = tex2D(_Opacity,TRANSFORM_TEX(node_8835, _Opacity));
                clip(_Opacity_var.r - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
