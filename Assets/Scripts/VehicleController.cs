using UnityEngine;

public struct Speeds
{
    public const float NORMAL = 20f;
    public const float FAST = 30f;
    public const float SLOW = 10f;
}

public class VehicleController : MonoBehaviour {

    [SerializeField] public float speed;
    [SerializeField] private GameObject explosion;
    private new Rigidbody rigidbody;

    private void OnEnable()
    {
        GameManager.OnPlayerReachLimit += ResetPosition;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerReachLimit -= ResetPosition;
    }

    // Use this for initialization
    public virtual void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 movement)
    {
        rigidbody.MovePosition(rigidbody.position + movement);
    }

    public void Flip()
    {
        speed *= -1;
        transform.localScale = new Vector3(Mathf.Sign(speed), 1, 1);
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void Explode(GameObject obj)
    {
        obj.SetActive(false);
        explosion.SetActive(true);
    }

    private void ResetPosition(float zMaxDistance)
    {        
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - zMaxDistance);
    }
}
