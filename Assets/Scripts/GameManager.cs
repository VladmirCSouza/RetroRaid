using UnityEngine;
public enum GameState
{
    INIT,
    PLAYING,
    PAUSE,
    GAME_OVER,
    RESTART
}

public class GameManager : MonoBehaviour {

    private static GameManager instance = null;

    public GameState currState;

    public bool canPause;
    
    public Transform player;
    
    public int howManyBaseElements = 3;
    private float zMaxDistance;

    public delegate void PlayerReachLimit(float zMaxDistance);
    public static event PlayerReachLimit OnPlayerReachLimit;

    public static GameManager Instance {
        get {
            return instance;
        }
    }

    private void Awake()
    {
        canPause = true;

        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zMaxDistance = (howManyBaseElements - 1) * 65;//65 é o tamanho dos elementos base
    }
	
	// Update is called once per frame
	void Update () {

        if (GameState.PAUSE == currState)
            return;

        if (player.position.z > zMaxDistance)
        {
            if (OnPlayerReachLimit != null)
                OnPlayerReachLimit(zMaxDistance);
        }            
	}
}
