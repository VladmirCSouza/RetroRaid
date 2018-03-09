using UnityEngine;
using System.Collections.Generic;
public enum GameState
{
    PLAYING,
    PAUSE,
    GAME_OVER
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
        zMaxDistance = (howManyBaseElements - 1) * 150;//150 é o tamanho dos elementos base
    }
	
	// Update is called once per frame
	void Update () {

        if (GameState.PAUSE == currState)
            return;

        if (player.position.z > 300)
        {
            if (OnPlayerReachLimit != null)
                OnPlayerReachLimit(zMaxDistance);
        }            
	}

    private void LateUpdate()
    {
        //if (player.position.z - 150 > gamePieces[0].transform.position.z)
        //{
        //    gamePieces.Add(Instantiate(piece, gamePieces[gamePieces.Count -1].transform.position + Vector3.forward * 150, transform.rotation) as GameObject);
        //    Destroy(gamePieces[0]);
        //    gamePieces.RemoveAt(0);
        //}
    }
}
