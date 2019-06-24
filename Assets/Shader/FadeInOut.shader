Shader "MyShader/BlackScreen" {
	Properties
	{
		_Color("Main Color", Color) = (1,1,1,1)
		_ChangeFloat("改变颜色",Range(0,1)) = 1.0
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Radius("Radius",float) = 1.5
		_OutterRadius("Outter Radius",float)=0.2
		_Center_X("Center_X", float) = 0   //表示中心位置
		_Center_Y("Center_Y", float) = 0
	}
		SubShader
	{
		Pass
	{
		CGPROGRAM
			#pragma vertex vert_img        
			#pragma fragment frag             
			#include "UnityCG.cginc"  

			fixed4 _Color;
	sampler2D _MainTex;
	float1 _ChangeFloat;
	float _Radius;
	float _Center_X;
	float _Center_Y;
	float _OutterRadius;
	float4 frag(v2f_img i) : COLOR
	{
		float x = i.uv.x*(_ScreenParams.x / _ScreenParams.y);
		float y = i.uv.y;
		float dis = sqrt((x - _Center_X)*(x - _Center_X) + (y - _Center_Y)*(y - _Center_Y));
		//在半径区域 修改颜色 达到屏幕黑色效果
		if (dis > _Radius + _OutterRadius)
		{
			float4 col = (0, 0, 0, 0);
			return col;
		}
		else if (dis > _Radius)
		{
			float4 black = (0, 0, 0, 0);
			//float alpha = (_OutterRadius - (dis - _Radius)) * (1.0f / _OutterRadius);
			float offset = (_OutterRadius - (dis - _Radius)) / _OutterRadius;
			float alpha = offset * offset;
			return alpha * tex2D(_MainTex, i.uv) + (1 - alpha) * black;
		}
		return tex2D(_MainTex, i.uv);
		}
			ENDCG
		}
	}
		Fallback off
}
