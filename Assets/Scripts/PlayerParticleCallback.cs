using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerParticleCallback : MonoBehaviour {

    public void OnParticleSystemStopped()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
