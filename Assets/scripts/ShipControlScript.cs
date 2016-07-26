using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Transform))]
public class ShipControlScript : MonoBehaviour
{
    //thrust
    public float thrust;
    public float rotationalThrust;
    //max speed
    public float maxSpeed;

    //current movement vector
    private Vector2 currentThrust;
    private float targetRotation;

    //boolean for player control
    public bool playerControlled = true;

    //rigidbody and transform component of ship
    private Rigidbody2D rigidBody;

    //input thrusts
    float inputThrust;
    float inputRotation;

    //voids for ai
    void Thrust(float thrust)
    {
        this.inputThrust = thrust;
    }
    void Rotation(float rotation)
    {
        this.inputRotation = rotation;
    }

    //setting the type of control
    void SetControlType(bool player)
    {
        this.playerControlled = player;
    }

	// Use this for initialization
	void Start ()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update ()
    {

        if (playerControlled)
        {
            //get input information
            inputThrust = Input.GetAxis("Vertical");
            inputRotation = Input.GetAxis("Horizontal");
        }

        //set current thrust information
        this.currentThrust.x = Mathf.Cos(Mathf.Deg2Rad * this.rigidBody.rotation + (Mathf.PI / 2)) * inputThrust * this.thrust * Time.deltaTime;
        this.currentThrust.y = Mathf.Sin(Mathf.Deg2Rad * this.rigidBody.rotation + (Mathf.PI / 2)) * inputThrust * this.thrust * Time.deltaTime;
        this.targetRotation -= inputRotation;
	}

    //FixedUpdate for physics
    void FixedUpdate()
    {
        this.rigidBody.AddForce(this.currentThrust, ForceMode2D.Impulse);
        Vector2.ClampMagnitude(this.rigidBody.velocity, this.maxSpeed);
        this.rigidBody.MoveRotation(targetRotation);
    }
}
