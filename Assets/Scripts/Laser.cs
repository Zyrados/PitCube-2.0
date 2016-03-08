////////////////////////////////////////////
////                                    ////
////   Autor: Jonas Fischer             ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour 
{
    private Color LaserColorSpawnable = new Color(0, 255, 0);
    private Color LaserColorNoSpawn = new Color(255, 0, 0);
	public RaycastHit Hit;
    public Material LaserMaterial;
    public GameObject CubeMarker;
    
	
	private LineRenderer lineRenderer;

	void Start () 
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>() as LineRenderer;
        lineRenderer.material = LaserMaterial;
        lineRenderer.SetWidth(0.02f, 0.02f);
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lineRenderer.SetVertexCount(2);
	}

    void LateUpdate()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        Vector3 hitPoint = origin + direction * 1000;

        lineRenderer.SetPosition(0, origin);
        if (Physics.Raycast(origin, direction, out Hit))
        {
            hitPoint = Hit.point;
        }
		lineRenderer.SetPosition(1, hitPoint);
       
        if (this.GetComponent<Laser>().Hit.collider.gameObject.tag == "Wall" || this.GetComponent<Laser>().Hit.collider.gameObject.tag == "Cube")
        {
               LaserMaterial.color = LaserColorSpawnable;
                      
        }
        else
        {
           
            LaserMaterial.color = Color.red;
            
        }
    }
}
