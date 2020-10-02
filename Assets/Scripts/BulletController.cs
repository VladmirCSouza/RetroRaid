using Assets.Scripts;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField] private float speed = 25f;
    //[SerializeField] private float gravity = 0.1f;
    [SerializeField] private float maxDistance = 40f;
    private float zInitalPosition = 0;

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
        zInitalPosition = transform.position.z;
	}

    void Update()
    {
        if(zInitalPosition + maxDistance < transform.position.z)
        {
            DestroyBullet();
        }

        //if (rigidbody.position.y < 0)
        //{
        //    explosion.transform.parent = null;
        //    explosion.transform.localScale = Vector3.one;
        //    explosion.SetActive(true);
        //    Destroy(gameObject);
        //}
    }

    private void FixedUpdate()
    {
        //Código comentado usado com lógica de gravidade
        //Qdo a bala atingir o rio ela explode
        //Substituido por código onde o que mandá é a distância percorrida pelo tiro
        //Vector3 movement = (transform.forward * speed + transform.up * gravity) * Time.deltaTime;
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.WALL))
            DestroyBullet();
    }

    private void DestroyBullet()
    {
        explosion.transform.parent = null;
        explosion.transform.localScale = Vector3.one;
        explosion.SetActive(true);
        Destroy(gameObject);
    }

    private void ResetPosition(float zMaxDistance)
    {
        zInitalPosition -= zMaxDistance;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - zMaxDistance);
    }
}
