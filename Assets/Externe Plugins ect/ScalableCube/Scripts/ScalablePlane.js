/**
 ScalablePlane � Sascha Graeff

 This script adds the ScalableCube functionality to planes.
 It's not updating the mesh but the material.
 
 You want to ignore any errors and warnings caused by this script
 concerning mesh leaking. They can't be avoided.
**/

#pragma strict

private var me : Transform;
@script RequireComponent(Renderer)
private var r : Renderer;
@script ExecuteInEditMode

private var lastTransformScale : Vector3;
private var lastScale : Vector2;

var scale : Vector2 = Vector2(0.2,0.2);

var additionalTextureNames : String[] = new String[0];


function Awake()
{
	me = transform;
	r = GetComponent.<Renderer>();

	Update();
}

function Update()
{
	#if UNITY_EDITOR
		me = transform;
		r = GetComponent.<Renderer>();
	#endif

	if(lastTransformScale != me.localScale || lastScale != scale)
	{
		for(var mat : Material in r.materials)
		{
			var s : Vector2 = Vector2(scale.x == 0 ? 0 : me.localScale.x / scale.x, scale.y == 0 ? 0 : me.localScale.z / scale.y);
			r.material.mainTextureScale = s;

			if(mat.HasProperty("_BumpMap"))
			{
				mat.SetTextureScale("_BumpMap", scale);
			}
			for(var textureName : String in additionalTextureNames)
			{
				if(mat.HasProperty(textureName))
				{
					mat.SetTextureScale(textureName, scale);
				}
			}
		}

		lastScale = scale;
		lastTransformScale = me.localScale;
	}
}