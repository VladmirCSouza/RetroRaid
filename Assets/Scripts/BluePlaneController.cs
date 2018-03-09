using UnityEngine;

public class BluePlaneController : VehicleController {
    [SerializeField] private float maxHeight = 4.5f;
    [SerializeField] private float minHeight = 1f;
    [SerializeField] private float distanceToGo = 40f;

    private bool canGo = false;

    private Transform playerPosition;
    
    // Use this for initialization
    public override void Start () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        if (Mathf.Sign(transform.position.x) > 0)
            Flip();

        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        if (!canGo && Mathf.Abs(playerPosition.position.z - transform.position.z) < distanceToGo)
            canGo = true;
	}

    private void FixedUpdate()
    {
        if (!canGo)
            return;

        Vector3 movement = transform.right * speed * Time.deltaTime;
        Move(movement);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WALL"))
            transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "WALL":
                transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
                break;
            case "BULLET":
                Destroy(other.gameObject);
                Explode();
                break;
            default:
                break;
        }
    }
}
