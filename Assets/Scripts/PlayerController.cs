using UnityEngine;
using System;

[RequireComponent (typeof(VehicleController))]
public class PlayerController : VehicleController {
    
    [SerializeField] Animator anim;
    private float hSpeed;
    private float vSpeed;

    private Vector3 startPosition;

    public GameObject bullet;
    public Transform gunPoint;
    public GameObject playerModel;

    //Death reset timer
    private float timer;
    private float delay = 1f;
    private int count = 4;

    // Use this for initialization
    public override void Start ()
    {
        timer = Time.time;

        base.Start();
        speed = Speeds.NORMAL;
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(count > 0 && delay < (Time.time - timer))
        {
            timer = Time.time;
            count--;
            //Debug.Log(count);
        }

        
        SetAnimation(Input.GetAxisRaw("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        if (Input.GetAxisRaw("Vertical") > 0)
            speed = Speeds.FAST;
        else if (Input.GetAxisRaw("Vertical") < 0)
            speed = Speeds.SLOW;
        else
            speed = Speeds.NORMAL;
    }

    private void FixedUpdate()
    {
        if (!playerModel.activeSelf)
            return;

        vSpeed = speed * Time.deltaTime;
        hSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 movement = transform.right * hSpeed + Vector3.forward * vSpeed;

        Move(movement);
    }

    private void SetAnimation(float speed)
    {
        if(playerModel.activeSelf)
            anim.SetFloat("Speed", speed);
    }

    private void Shoot()
    {
        Instantiate(bullet, gunPoint.position, gunPoint.rotation);
    }

    public Vector3 GetStartPosition()
    {
        return startPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "WALL":
                //Explode(playerModel);
                break;
            case "ENEMY":
                Explode(playerModel);
                other.GetComponent<VehicleController>().Explode();
                break;
            case "BRIDGE":
                Explode(playerModel);
                break;
            default:
                break;
        }
    }
}
