using Assets.Scripts;
using UnityEngine;

public class RiverEnemyController : VehicleController {

    [SerializeField] private bool facingLeft;

    // Use this for initialization
    public override void Start()
    {
        if (facingLeft)
            Flip();

        base.Start();
    }

    // Update is called once per frame
    void Update () {
	}

    private void FixedUpdate()
    {
        Vector3 movement = transform.right * speed * Time.deltaTime;

        Move(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case GameTags.WALL:
                Flip();
                break;
            case GameTags.BULLET:
                Destroy(other.gameObject);
                Explode();
                break;
        }
    }
}
