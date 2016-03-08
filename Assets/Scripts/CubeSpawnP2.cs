////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class CubeSpawnP2 : MonoBehaviour
{
    public AudioSource BulletShoot;
    public AudioSource Shoot;
    public AudioSource ShootDenied;
    public UILabel ShowAmmo;
    public float CubeSpeed;
    public static int CubeAmmo;
    public static int CubeInUse;
    public GameObject CubePrefabP2;
    public GameObject WeaponP2;
    public UILabel AmmoP2;
	public GameObject EraserBulletPrefab;
    public GameObject ColorBulletPrefab;
    public GameObject BubbleBulletPrefab;
    public GameObject JumpBulletPrefab;
    public GameObject LightBulletPrefab;
	
	private enum ammunition { Normal, EraserBullet, LightBullet, BubbleBullet, JumpBullet, CCGreen, CCRed, CCBlue, CCYellow };
	private int LevelAmmoTypeNumber = 8;
    private int currentAmmu = 0;
    private bool fireTriggerInUse = false;
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

    void AmmoGUI()
    {
        if (GameObject.Find("GameManager"))
        {
            switch (myAmmu)
            {
                case ammunition.BubbleBullet:
                    ShowAmmo.text = "Bubble Cube";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().BubbleLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.CCBlue:
                    ShowAmmo.text = "Color: Blue";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.CCGreen:
                    ShowAmmo.text = "Color: Green";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.CCRed:
                    ShowAmmo.text = "Color: Red";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.CCYellow:
                    ShowAmmo.text = "Color: Yellow";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.EraserBullet:
                    ShowAmmo.text = "Eraser";
                    ShowAmmo.color = green;
                    break;
                case ammunition.JumpBullet:
                    ShowAmmo.text = "Jump Cube";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().JumpLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.LightBullet:
                    ShowAmmo.text = "Light Bullet";
                    if (!GameObject.Find("GameManager").GetComponent<GameManager>().LightLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.Normal:
                    ShowAmmo.text = "Cube";
                    ShowAmmo.color = green;
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
                    ShowAmmo.text = "Bubble Cube";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().BubbleLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.CCBlue:
                    ShowAmmo.text = "Color: Blue";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.CCGreen:
                    ShowAmmo.text = "Color: Green";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.CCRed:
                    ShowAmmo.text = "Color: Red";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.CCYellow:
                    ShowAmmo.text = "Color: Yellow";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.EraserBullet:
                    ShowAmmo.text = "Eraser";
                    ShowAmmo.color = green;
                    break;
                case ammunition.JumpBullet:
                    ShowAmmo.text = "Jump Cube";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().JumpLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.LightBullet:
                    ShowAmmo.text = "Light Bullet";
                    if (!GameObject.Find("KoopManager").GetComponent<KoopManager>().LightLevel)
                    {
                        ShowAmmo.color = red;
                    }
                    else
                    {
                        ShowAmmo.color = green;
                    }
                    break;
                case ammunition.Normal:
                    ShowAmmo.text = "Cube";
                    ShowAmmo.color = green;
                    break;
                default:
                    Debug.Log("Unexpected ammunition Type, not in enum");
                    break;
            }
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
            if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                if (!fireTriggerInUse)
                {
					GameObject newBullet = Instantiate(ColorBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                    newBullet.GetComponent<ColorBullet>().BC = ColorBullet.BulletColor.green;
                    newBullet.GetComponent<Renderer>().material.color = green;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                    BulletShoot.Play();
                    CubeAmmo--;
                    CubeInUse++;
                    fireTriggerInUse = true;
                }
            }
		}
        else if (myAmmu == ammunition.CCBlue)
        {
           if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                if (!fireTriggerInUse)
                {
                    GameObject newBullet = Instantiate(ColorBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                    newBullet.GetComponent<ColorBullet>().BC = ColorBullet.BulletColor.blue;
                    newBullet.GetComponent<Renderer>().material.color = blue;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                    BulletShoot.Play();
                    CubeAmmo--;
                    CubeInUse++;
                    fireTriggerInUse = true;
                }
            }
        }
        else if (myAmmu == ammunition.CCRed)
        {
           if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                if (!fireTriggerInUse)
                {
                    GameObject newBullet = Instantiate(ColorBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                    newBullet.GetComponent<ColorBullet>().BC = ColorBullet.BulletColor.red;
                    newBullet.GetComponent<Renderer>().material.color = red;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                    BulletShoot.Play();
                    CubeAmmo--;
                    CubeInUse++;
                    fireTriggerInUse = true;
                }
            }
		}
        else if (myAmmu == ammunition.CCYellow)
        {
           if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                if (!fireTriggerInUse)
                {
                    GameObject newBullet = Instantiate(ColorBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                    newBullet.GetComponent<ColorBullet>().BC = ColorBullet.BulletColor.yellow;
                    newBullet.GetComponent<Renderer>().material.color = yellow;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                    BulletShoot.Play();
                    CubeAmmo--;
                    CubeInUse++;
                    fireTriggerInUse = true;
                }
            }
        }
    }

    void HandleLightBullet()
    {
        if (myAmmu == ammunition.LightBullet)
        {
            if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                if (!fireTriggerInUse)
                {
                    GameObject newBullet = Instantiate(LightBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                    BulletShoot.Play();
                    CubeAmmo--;
                    CubeInUse++;
                    fireTriggerInUse = true;
                }
            }
        }
    }

    void HandleBubbleBullet()
    {
        if (myAmmu == ammunition.BubbleBullet)
        {
            if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                if (!fireTriggerInUse)
                {
                    GameObject newBullet = Instantiate(BubbleBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                    BulletShoot.Play();
                    CubeAmmo--;
                    CubeInUse++;
                    fireTriggerInUse = true;
                }
			}
        }
    }

    void HandleJumpBullet()
    {
        if (myAmmu == ammunition.JumpBullet)
        {
           if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                if (!fireTriggerInUse)
                {
                    GameObject newBullet = Instantiate(JumpBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                    BulletShoot.Play();
                    CubeAmmo--;
                    CubeInUse++;
                    fireTriggerInUse = true;
                }
            }
        }
    }
	
	void HandleBulletTypes()
	{
		if (GameObject.Find("GameManager"))
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().ColorLevel)
            {
				HandleColorBullet();
            }
            if (GameObject.Find("GameManager").GetComponent<GameManager>().LightLevel)
            {
				HandleLightBullet();
            }
            if (GameObject.Find("GameManager").GetComponent<GameManager>().BubbleLevel)
            {
                HandleBubbleBullet();
            }
            if (GameObject.Find("GameManager").GetComponent<GameManager>().JumpLevel)
            {
                HandleJumpBullet();
            }
        }
            else if (GameObject.Find("KoopManager").GetComponent<KoopManager>().ColorLevel)
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
		if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            currentAmmu++;
            if (currentAmmu > LevelAmmoTypeNumber)
            {
                currentAmmu = 0;
            }
            myAmmu = (ammunition)currentAmmu;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button4))
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
		if (Input.GetAxis("Fire2") == 0)
        {
            fireTriggerInUse = false;
        }
		if (myAmmu == ammunition.Normal)
        {
            if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                if (!fireTriggerInUse)
                {
					Camera cam = GameObject.FindGameObjectWithTag("Camera P2").GetComponent<Camera>();
                    bool cubeCanSpawn = false;
                    if (this.GetComponent<Laser>().Hit.collider.gameObject.tag == "Wall" || this.GetComponent<Laser>().Hit.collider.gameObject.tag == "Cube")
                    {
                        Vector3 cubePosition = this.GetComponent<Laser>().Hit.point + this.GetComponent<Laser>().Hit.normal * CubeSize / 2;
                        cubePosition = ComputeOverdue(cubePosition);
                        foreach (Vector3 pos in GridManager.Grid)
                        {
                            if (pos != cubePosition && Vector3.Distance(cubePosition, pos) >= CubeSize)
                            {
                                cubeCanSpawn = true;
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
                            GameObject newCube = (GameObject)Instantiate(CubePrefabP2, cubePosition, Quaternion.identity);
                            Shoot.Play();
                            CubeAmmo--;
                            CubeInUse++;
                            fireTriggerInUse = true;
                        }
                    }
                    else
                    {
                        ShootDenied.Play();
                    }
                }
            }      
        }
        else if (myAmmu == ammunition.EraserBullet)
        {
            Debug.Log("Eraser ausgewählt");
            if (Input.GetAxis("Fire2") != 0 && CubeAmmo > 0)
            {
                Debug.Log("Eraser ausgewählt, Trigger gedrückt");
                if (!fireTriggerInUse)
                {
                    GameObject newBullet = Instantiate(EraserBulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    newBullet.GetComponent<Rigidbody>().AddForce(direction * CubeSpeed, ForceMode.VelocityChange);
                    CubeAmmo--;
                    CubeInUse++;
                    fireTriggerInUse = true;
                }
            }
        }
	}
	
    void Update()
    {
        AmmoGUI();
		HandleBulletTypes();
		SwitchAmmo();
		AmmoP2.text = CubeAmmo.ToString();
		ShootAndErase();
	}
}