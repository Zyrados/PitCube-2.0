////////////////////////////////////////////////////////
////                                                ////
////   Autor: Christian Langpaap & Jonas Fischer    ////
////                                                ////
////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CubeSpawnP1: MonoBehaviour 
{
    public AudioSource BulletShoot;
    public AudioSource Shoot;
    public AudioSource ShootDenied;
    //public UILabel ShowAmmo;
    public Text ShowAmmoType;
    public float CubeSpeed;
    public static int CubeAmmo;
    public static int CubeInUse;
    public GameObject CubePrefabP1;
    public GameObject WeaponP1;
    public GameObject AmmoCube;

    public GameObject WeaponpartColorchange;
    public Material[] CubeMaterials;
    public Mesh[] AmmoForm;
    //public UILabel Ammo;
    public Text Ammo;
    public GameObject EraserBulletPrefab;
    public GameObject ColorBulletPrefab;
    public GameObject BubbleBulletPrefab;
    public GameObject JumpBulletPrefab;
	public GameObject LightBulletPrefab;
	
    private int LevelAmmoTypeNumber = 8;
    private enum ammunition { Normal, EraserBullet, LightBullet, BubbleBullet, JumpBullet, CCGreen, CCRed, CCBlue, CCYellow };
    private int currentAmmu = 0;
    private ammunition myAmmu;
    private Color green;
    private Color blue;
    private Color red;
    private Color yellow;
    private GameObject ColorManager;
    private GameObject SolarPanal;
    private int CubeSize = 1;
	
	void Start()
    { 
        GridManager.Grid.Clear();
        ColorManager = GameObject.FindGameObjectWithTag("ColorManager");
        SolarPanal = GameObject.FindGameObjectWithTag("SolarPanel");
        CubeInUse = 0;        
        myAmmu = ammunition.Normal;
        green = new Color(0f, 255f / 255, 23f / 255);
        red = new Color(255f / 255, 0f, 0f);
        blue = new Color(9f / 255, 0f, 255f / 255);
        yellow = new Color(251f / 255, 255f / 255, 0f);
        if (ColorManager != null)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel = true;
        }

        if (SolarPanal != null)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().LightLevel = true;
        }
    }

	//Begradigt die Position des Cubes auf 0,5
    Vector3 ComputeOverdue(Vector3 cubePosition)
    {
        for (int i = 0; i < 3; i++)
        {
            double overdue = cubePosition[i] % 0.5;
            cubePosition[i] = cubePosition[i] - (float)overdue;
            if (overdue > 0.25f)
            {
                cubePosition[i] += 0.5f;
            }
        }
        return cubePosition;
    }

    void HandleColorBullet()
    {
        if (myAmmu == ammunition.CCGreen)
        {
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                GameObject newBullet = Instantiate(ColorBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                newBullet.GetComponent<ColorBullet>().BC = ColorBullet.BulletColor.green;
                newBullet.GetComponent<Renderer>().material.color = green;
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                BulletShoot.Play();
                CubeAmmo--;
                CubeInUse++;
            }
        }
        else if (myAmmu == ammunition.CCBlue)
        {
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                GameObject newBullet = Instantiate(ColorBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                newBullet.GetComponent<ColorBullet>().BC = ColorBullet.BulletColor.blue;
                newBullet.GetComponent<Renderer>().material.color = blue;
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                BulletShoot.Play();
                CubeAmmo--;
                CubeInUse++;
            }
        }
        else if (myAmmu == ammunition.CCRed)
        {
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                GameObject newBullet = Instantiate(ColorBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                newBullet.GetComponent<ColorBullet>().BC = ColorBullet.BulletColor.red;
                newBullet.GetComponent<Renderer>().material.color = red;
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                BulletShoot.Play();
                CubeAmmo--;
                CubeInUse++;
            }
        }
        else if (myAmmu == ammunition.CCYellow)
        {
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                GameObject newBullet = Instantiate(ColorBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                newBullet.GetComponent<ColorBullet>().BC = ColorBullet.BulletColor.yellow;
                newBullet.GetComponent<Renderer>().material.color = yellow;
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                BulletShoot.Play();
                CubeAmmo--;
                CubeInUse++;                
            }
        }
    }

    void HandleLightBullet()
    {
        if (myAmmu == ammunition.LightBullet)
        {   
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                GameObject newBullet = Instantiate(LightBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                BulletShoot.Play();
                CubeAmmo--;
                CubeInUse++;
            }
        }
    }
    
    void HandleBubbleBullet()
    {
        if (myAmmu == ammunition.BubbleBullet)
        {
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                GameObject newBullet = Instantiate(BubbleBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                BulletShoot.Play();
                CubeAmmo--;
                CubeInUse++;
            }
        }
    }

    void HandleJumpBullet()
    {
        if (myAmmu == ammunition.JumpBullet)
        {
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                GameObject newBullet = Instantiate(JumpBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                BulletShoot.Play();
                CubeAmmo--;
                CubeInUse++;
            }
        }
    }

    void AmmoGUI()
    {
        if (GameObject.Find("GameManager"))
        {
            switch (myAmmu)
            {
                case ammunition.BubbleBullet:
                    ShowAmmoType.text = "Bubble Cube";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().BubbleLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[3];
                        AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[1];
                        WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[3];
                       
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.CCBlue:
                    ShowAmmoType.text = "Color: Blue";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                        AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[7];
                        AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[1];
                        WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[7];
                    }
                    break;
                case ammunition.CCGreen:
                    ShowAmmoType.text = "Color: Green";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                        AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[5];
                        AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[1];
                        WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[5];
                    }
                    break;
                case ammunition.CCRed:
                    ShowAmmoType.text = "Color: Red";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                        AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[6];
                        AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[1];
                        WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[6];
                    }
                    break;
                case ammunition.CCYellow:
                    ShowAmmoType.text = "Color: Yellow";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                        AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[8];
                        AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[1];
                        WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[8];
                    }
                    break;
                case ammunition.EraserBullet:
                    ShowAmmoType.text = "Eraser";
                    ShowAmmoType.color = green;
                    AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[1];
                    AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[1];
                    WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[1];
                    break;
                case ammunition.JumpBullet:
                    ShowAmmoType.text = "Jump Cube";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().JumpLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[4];
                        AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[1];
                        WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[4];
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.LightBullet:
                    ShowAmmoType.text = "Light Bullet";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().LightLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[2];
                        ShowAmmoType.color = green;
                        AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[1];
                        WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[2];
                    }
                    break;
                case ammunition.Normal:
                    ShowAmmoType.text = "Cube";
                    ShowAmmoType.color = green;
                    AmmoCube.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[0];
                    AmmoCube.GetComponent<MeshFilter>().GetComponent<MeshFilter>().mesh = AmmoForm[0];
                    WeaponpartColorchange.GetComponent<Renderer>().GetComponent<Renderer>().material = CubeMaterials[0];
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (myAmmu)
            {
                case ammunition.BubbleBullet:
                    ShowAmmoType.text = "Bubble Cube";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().BubbleLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.CCBlue:
                    ShowAmmoType.text = "Color: Blue";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.CCGreen:
                    ShowAmmoType.text = "Color: Green";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.CCRed:
                    ShowAmmoType.text = "Color: Red";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.CCYellow:
                    ShowAmmoType.text = "Color: Yellow";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.EraserBullet:
                    ShowAmmoType.text = "Eraser";
                    ShowAmmoType.color = green;
                    break;
                case ammunition.JumpBullet:
                    ShowAmmoType.text = "Jump Cube";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().JumpLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.LightBullet:
                    ShowAmmoType.text = "Light Bullet";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().LightLevel)
                    {
                        ShowAmmoType.color = red;
                    }
                    else
                    {
                        ShowAmmoType.color = green;
                    }
                    break;
                case ammunition.Normal:
                    ShowAmmoType.text = "Cube";
                    ShowAmmoType.color = green;
                    
                    break;
                default:
                    break;
            }
        }
    }
	
	void HandleBulletTypes()
	{
		 if(GameObject.Find("GameManager"))
        {
            if(GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
            {
                 HandleColorBullet();
            }
            if(GameObject.Find("GameManager").GetComponent<GameManager>().LightLevel)
            {
                HandleLightBullet();
            }
            if(GameObject.Find("GameManager").GetComponent<GameManager>().BubbleLevel)
            {
                HandleBubbleBullet();
            }
            if (GameObject.Find("GameManager").GetComponent<GameManager>().JumpLevel)
            {
                HandleJumpBullet();
            }
        }
        else if(GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
        {
            HandleColorBullet();
        }
        else if (GameObject.Find("KoopManager").GetComponent<KoopManager>().LightLevel)
        {
            HandleLightBullet();
        }
        else if (GameObject.Find("KoopManager").GetComponent<KoopManager>().BubbleLevel)
        {
            HandleBubbleBullet();
        }
        else if (GameObject.Find("KoopManager").GetComponent<KoopManager>().JumpLevel)
        {
            HandleJumpBullet();
        }
	}
	
	void SwitchAmmo()
	{
		if (Input.GetKeyDown(KeyCode.E))
        {
            currentAmmu++;
            if (currentAmmu > LevelAmmoTypeNumber)
            {
                currentAmmu = 0;
            }
            myAmmu = (ammunition)currentAmmu;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            currentAmmu--;
            if (currentAmmu < 0)
            {
                currentAmmu = LevelAmmoTypeNumber;
            }
            myAmmu = (ammunition)currentAmmu;
        }
	}
	
	void ShootAndErase()
	{
		if (myAmmu == ammunition.Normal)
        {
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                Camera cam = GameObject.FindGameObjectWithTag("Camera P1").GetComponent<Camera>();
                bool cubeCanSpawn = false;
                if (this.GetComponent<Laser>().Hit.collider.gameObject.tag == "Wall" || this.GetComponent<Laser>().Hit.collider.gameObject.tag == "Cube")
                {
                    Vector3 cubePosition = this.GetComponent<Laser>().Hit.point + this.GetComponent<Laser>().Hit.normal * CubeSize / 2;
                    cubePosition = ComputeOverdue(cubePosition);
                    foreach(Vector3 pos in GridManager.Grid)
                    {
                        if (pos != cubePosition && Vector3.Distance(cubePosition, pos)>= CubeSize)
                        {
                            if (CheckCollision(cubePosition))
                            {
                                cubeCanSpawn = true;
                            }
                        }
                        else
                        {
                            cubeCanSpawn = false;
                            ShootDenied.Play();
                            break;
                        }
                    }
                    if (cubeCanSpawn || GridManager.Grid.Count <= 0)
                    {
                        GridManager.Grid.Add(cubePosition);

                        GameObject newCube = (GameObject)Instantiate(CubePrefabP1, cubePosition, Quaternion.identity);
                        Shoot.Play();
                        CubeAmmo--;
                        CubeInUse++;
                    }                    
                }
                else
                {
                    ShootDenied.Play();
                }
            }
        }
        else if (myAmmu == ammunition.EraserBullet)
        {
            if (Input.GetButtonDown("Fire1") && CubeAmmo > 0)
            {
                GameObject newBullet = Instantiate(EraserBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                Vector3 direction = transform.TransformDirection(Vector3.forward);
                newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                BulletShoot.Play();
                CubeAmmo--;
                CubeInUse++;
            }
        }
	}

    void Update()
    {
        AmmoGUI();
		HandleBulletTypes();
		SwitchAmmo();
        Ammo.text = CubeAmmo.ToString();
		ShootAndErase();
    }

    public bool CheckCollision(Vector3 CubePosition)
    {
        if(Physics.CheckSphere(CubePosition,0.25f))
        {
            Debug.Log(CubePosition);
            return false;
        }
        return true;
    }
}
