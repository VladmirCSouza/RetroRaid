using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private bool classicView = false;
    [SerializeField] private float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private float yVelocity = 0.0f;

    [Header("3D View Settings")]
    [SerializeField] private float height3D = 10f;
    [SerializeField] private float distance3D = 10f;
    [SerializeField] private float rotation3D = 35f;
    [SerializeField] private float bounds3D = 25f;

    [Header("Classic Settings Settings")]
    [SerializeField] private float heightClassic = 45f;
    [SerializeField] private float distanceClassic = 15f;
    [SerializeField] private float rotationClassic = 90f;


    private GameObject player;

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
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
            classicView = !classicView;
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;
        ChangeView();
    }

    private void ChangeView()
    {
        Vector3 camPos;
        float camAngle;

        if (classicView)
        {
            //Time.timeScale = 0.8f; //Fix the game speed when the game is on the classic mode
            camAngle = rotationClassic;
            camPos = new Vector3(0, heightClassic, distanceClassic + player.transform.position.z);
        }
        else
        {
            //Time.timeScale = 1.0f;//Reset game speed for 3D view

            float newPositionX;

            if (Mathf.Abs(player.transform.position.x) < bounds3D)
            {
                newPositionX = player.transform.position.x;
            }
            else
            {
                if (Mathf.Abs(player.transform.position.x) > bounds3D)
                    newPositionX = Mathf.Sign(player.transform.position.x) * bounds3D;
                else
                    newPositionX = transform.position.x;
            }
            
            camPos = new Vector3(newPositionX, height3D, distance3D * -1 + player.transform.position.z);
            camAngle = rotation3D;
        }

        UpdateView(camAngle, camPos);
    }
    
    private void UpdateView(float angle, Vector3 position)
    {
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothTime);
        float xAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x, angle, ref yVelocity, smoothTime);
        //transform.position = position;
        //float xAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x, angle, ref yVelocity, smoothTime);
        transform.eulerAngles = new Vector3(xAngle, 0, 0);
    }

    private void ResetPosition(float zMaxDistance)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - zMaxDistance);
    }
}
