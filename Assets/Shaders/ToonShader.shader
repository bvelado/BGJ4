// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8850,x:33456,y:32806,varname:node_8850,prsc:2|emission-5962-OUT;n:type:ShaderForge.SFN_NormalVector,id:1695,x:31898,y:33121,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:7435,x:31898,y:32966,varname:node_7435,prsc:2;n:type:ShaderForge.SFN_Lerp,id:5962,x:32869,y:32703,varname:node_5962,prsc:2|A-7532-RGB,B-5443-RGB,T-721-OUT;n:type:ShaderForge.SFN_Dot,id:1706,x:32074,y:33037,varname:node_1706,prsc:2,dt:0|A-7435-OUT,B-1695-OUT;n:type:ShaderForge.SFN_Tex2d,id:9176,x:32428,y:33037,ptovrint:False,ptlb:Toon,ptin:_Toon,varname:node_9176,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:7c0c6f6ba667d944f902238eae79e36c,ntxv:0,isnm:False|UVIN-28-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:9131,x:31898,y:32784,varname:node_9131,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7034,x:32661,y:32939,varname:node_7034,prsc:2|A-5696-RGB,B-9176-RGB;n:type:ShaderForge.SFN_LightColor,id:9637,x:31898,y:32645,varname:node_9637,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2801,x:32131,y:32707,varname:node_2801,prsc:2|A-9637-RGB,B-9131-OUT;n:type:ShaderForge.SFN_VertexColor,id:5696,x:32237,y:32883,varname:node_5696,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5288,x:32452,y:32752,varname:node_5288,prsc:2|A-2801-OUT,B-7034-OUT;n:type:ShaderForge.SFN_Append,id:28,x:32256,y:33105,varname:node_28,prsc:2|A-1706-OUT,B-1391-OUT;n:type:ShaderForge.SFN_Vector1,id:1391,x:32156,y:33275,varname:node_1391,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:5443,x:32355,y:32561,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_5443,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7532,x:32355,y:32373,ptovrint:False,ptlb:Shadows,ptin:_Shadows,varname:node_7532,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:721,x:32661,y:32720,varname:node_721,prsc:2,blmd:13,clmp:True|SRC-5288-OUT,DST-5288-OUT;proporder:5443-7532-9176;pass:END;sub:END;*/

Shader "Custom/ToonShader" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Shadows ("Shadows", 2D) = "white" {}
        [PerRendererData]_Toon ("Toon", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Toon; uniform float4 _Toon_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Shadows; uniform float4 _Shadows_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _Shadows_var = tex2D(_Shadows,TRANSFORM_TEX(i.uv0, _Shadows));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float2 node_28 = float2(dot(lightDirection,i.normalDir),0.0);
                float4 _Toon_var = tex2D(_Toon,TRANSFORM_TEX(node_28, _Toon));
                float3 node_5288 = ((_LightColor0.rgb*attenuation)*(i.vertexColor.rgb*_Toon_var.rgb));
                float3 emissive = lerp(_Shadows_var.rgb,_Diffuse_var.rgb,saturate(( node_5288 > 0.5 ? (node_5288/((1.0-node_5288)*2.0)) : (1.0-(((1.0-node_5288)*0.5)/node_5288)))));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Toon; uniform float4 _Toon_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Shadows; uniform float4 _Shadows_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
