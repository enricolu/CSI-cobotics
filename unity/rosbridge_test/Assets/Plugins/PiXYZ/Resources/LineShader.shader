Shader "PiXYZ/LineShader"
{
	Properties
	{
		[Header(Main Properties)]
		_Color ("Color", Color) = (1,1,1,1)

		[Toggle]
		_Offset ("See-Through", Float) = 0

		[Header(Dashes)]
		[Toggle]
		_Dashes ("Enabled", Float) = 0
        _DashesScale ("Scale", Range(1, 10)) = 1.0
        _DashesRatio ("Ratio", Range(1, 5)) = 1.0
	}
	SubShader
	{
		Tags { "Queue" = "Overlay" }
		LOD 200

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 position : POSITION;
			};

			struct v2f
			{
				float4 position : POSITION;
                float3 coords : TEXCOORD1;
			};

			float _Offset;

			v2f vert (appdata IN)
			{
				v2f OUT;
				OUT.position = UnityObjectToClipPos(IN.position);
				OUT.position.z += 0.000005 * (1 + _Offset * 100);
				OUT.coords = IN.position.xyz;
				return OUT;
			}

			fixed4 _Color;
			float _Dashes;
			float _DashesScale;
			float _DashesRatio;

			bool checkerboard(int x, int y, int z)
			{
				return (fmod(x, _DashesRatio) == 0) ^ (fmod(y, _DashesRatio) == 0) ^ (fmod(z, _DashesRatio) == 0);
			}

			fixed4 frag (v2f IN) : SV_Target
			{
				if (_Dashes) {
					_DashesRatio = int(_DashesRatio + 1);
					IN.coords *= int(1000 / (_DashesScale + 0.001));
					if (checkerboard(IN.coords.x, IN.coords.y, IN.coords.z)) {
						discard;
					}
				}
                return _Color;
			}
			ENDCG
		}
	}
}
