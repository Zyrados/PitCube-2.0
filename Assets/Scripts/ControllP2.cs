////////////////////////////////////////////
////                                    ////
////   Autor: Christian Langpaap        ////
////                                    ////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class ControllP2 : MonoBehaviour {

    public AudioSource StepAfterJump;
    public AudioSource Steps;
    public float Gravity = -9.81f;
    public float MovementSpeed = 5.0f;
    public float MouseSensitivityX = 5.0f;
    public float MouseSensitivityY = 5.0f;
    public float jumpSpeed = 20.0f;
	public float upDownRange = 60.0f;
	public static bool reachEnd = false;
    public static bool dead = false;
	public static int Lifepoints;
    public UILabel Lifes;
	public float MaxVolume;
    public float verticalVelocity = 0;
	public GameObject KoopGameOverScreen;
	 
    private CharacterController cc;
	private GameObject Spawn;
    private Transform cameraTrans;
	private float verticalRotation = 0;
    private Vector3 currenPosition;
    private bool hasJumped = false;
    private bool hasImpacted = false;
	
	void Start()
    {
        Screen.lockCursor = true;
        cc = GetComponent<CharacterController>();
        Spawn = GameObject.FindGameObjectWithTag("Spawn2");
        this.transform.position = Spawn.transform.position;
        cameraTrans = GameObject.FindGameObjectWithTag("Camera P2").transform;
    }

    void HandleInput()
    {
        //Rotation
		float rotLeftRight = Input.GetAxis("Stick X") * MouseSensitivityX;
        transform.Rotate(0, rotLeftRight, 0);
		verticalRotation -= Input.GetAxis("Stick Y") * MouseSensitivityY;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        cameraTrans.localRotation = Quaternion.Euler(verticalRotation,0, 0);

        //Bewegung
		float forwardSpeed = Input.GetAxis("Vertical P2") * MovementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal P2") * MovementSpeed;
        if (!cc.isGrounded)
        {
            verticalVelocity += Gravity * Time.deltaTime;
        }
        if (cc.isGrounded && Input.GetButton("Jump P2"))
        {
            verticalVelocity = jumpSpeed;
            hasJumped = true;
            hasImpacted = false;
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;
		cc.Move(speed * Time.deltaTime);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
        if (other.gameObject.name == "Startzone")
        {
            Acid.leaveExitZone = true;
            Debug.Log("Start Zone verlassen");
        }
        if (other.gameObject.tag == "Exit")
        {
            reachEnd = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {	
	if (GameObject.Find("GameManager"))
        {	
		if (other.gameObject.tag == "Acid")
            {
                this.transform.position = Spawn.transform.position;
                Lifepoints--;
                Application.LoadLevel(Application.loadedLevel);
                GridManager.Grid.Clear();
            }
            if (other.gameObject.tag == "Exit")
            {
                reachEnd = true;
                Application.LoadLevel(1);
                CubeSpawnP1.CubeAmmo = 0;
            }
        }
        else if (GameObject.Find("KoopManager"))
        {
		if (other.gameObject.tag == "Acid")
            {
                this.gameObject.SetActive(false);
                KoopGameOverScreen.SetActive(true);
                dead = true;
            }
            if (other.gameObject.tag == "Exit")
            {
                reachEnd = true;
            }
		}
		if (other.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = GameObject.FindGameObjectWithTag("MovingPlatform").transform;
        }
    }
    
	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "KillSphere")
        {
            this.transform.position = Spawn.transform.position;
            GridManager.Grid.Clear();
            Lifepoints--;
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void GameOver()
    {
        if(Lifepoints < 0 && GameObject.Find("GameManager"))
        {
            Application.LoadLevel("GameOver");
        }
    }
	
	void StepSounds()
	{
		if (hasJumped && cc.isGrounded && !hasImpacted)
        {
            StepAfterJump.Play();
            hasImpacted = true;
        }
		if (currenPosition != this.transform.position && cc.isGrounded && this.transform.parent == null)
        {
            Steps.volume = MaxVolume;
            currenPosition = this.transform.position;
        }
        else
        {
            Steps.volume = 0;
        }
	}
	
	void Update()
    {
        StepSounds();
        Lifes.text = Lifepoints.ToString();
        HandleInput();
        GameOver();
	}
}
