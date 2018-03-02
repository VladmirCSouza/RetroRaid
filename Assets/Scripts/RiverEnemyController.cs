using UnityEngine;

public class RiverEnemyController : VehicleController {

    [SerializeField] private bool facingRight;
    [SerializeField] GameObject explosion;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        speed = Speeds.NORMAL;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        //vSpeed = speed * Time.deltaTime;
        //hSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //Vector3 movement = transform.right * hSpeed + Vector3.forward * vSpeed;

        //Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "WALL":
                //ChangeDirection
                break;
            case "BULLET":
                Explode();
                break;
            default:
                break;
        }
    }
}
