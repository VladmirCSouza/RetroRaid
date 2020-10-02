using Assets.Scripts;
using UnityEngine;
public enum GameState
{
    INIT,
    PLAYING,
    DYING,
    PAUSE,
    GAME_OVER,
    RESTART
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public GameState currState;

    public bool canPause;

    [SerializeField] public Transform player;
   
    public int howManyBaseElements = 3;
    private float zMaxDistance;

    public delegate void GameFlowEvent();
    public static event GameFlowEvent OnDie;
    public static event GameFlowEvent OnGameOver;
    public static event GameFlowEvent OnFuelUpdated;

    public delegate void PlayerReachLimit(float zMaxDistance);
    public static event PlayerReachLimit OnPlayerReachLimit;

    public static GameManager Instance => instance;

    private void Awake()
    {
        canPause = true;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
        
        zMaxDistance = (howManyBaseElements - 1) * 65;//65 é o tamanho dos elementos base
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning("UPDATE : " +  currState);
        if (GameState.PAUSE == currState || GameState.GAME_OVER == currState || GameState.DYING == currState)
            return;

//        if (player?.position.z > zMaxDistance)
//        {
//            OnPlayerReachLimit?.Invoke(zMaxDistance);
//        }

        if (player == null)
        {
            //game conditions 
            if (GameFlow.LifeCount > 0)
            {
                currState = GameState.DYING;
                GameFlow.LifeCount--;
                OnPlayerReachLimit?.Invoke(zMaxDistance);
                OnDie?.Invoke();
                Debug.LogWarning("DYING : " + GameFlow.LifeCount);
            }
            else
            {
                currState = GameState.GAME_OVER;
                OnGameOver?.Invoke();
            }
        }
    }
}