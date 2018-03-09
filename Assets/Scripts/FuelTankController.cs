using UnityEngine;

public class FuelTankController : MonoBehaviour {

    [SerializeField] private GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "BULLET":
                explosion.transform.parent = null;
                explosion.SetActive(true);
                Destroy(explosion, 2.5f);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
