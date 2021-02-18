using Assets.Scripts;
using UnityEngine;

public class BridgeExplosionController : MonoBehaviour {

    [SerializeField] private GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.BULLET))
        {
            explosion.transform.parent = null;
            explosion.SetActive(true);
            Destroy(explosion, 2.5f);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
