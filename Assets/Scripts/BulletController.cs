using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField] private float speed = 25f;
    [SerializeField] private float gravity = 0.1f;
    private new Rigidbody rigidbody;

    private GameObject explosion;

    private void OnEnable()
    {
        GameManager.OnPlayerReachLimit += ResetPosition;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerReachLimit -= ResetPosition;
    }

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        explosion = gameObject.transform.GetChild(0).gameObject;
	}

    void Update()
    {
        if (rigidbody.position.y < 0)
        {
            explosion.transform.parent = null;
            explosion.transform.localScale = Vector3.one;
            explosion.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = (transform.forward * speed + transform.up * gravity) * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + movement);
    }

    private void ResetPosition(float zMaxDistance)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - zMaxDistance);
    }
}
