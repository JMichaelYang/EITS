using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollowScript : MonoBehaviour
{
    //the speed at which the camera will catch up
    public float smooth;
    
    //camera z coordinate
    public float cameraZ;

    //reference to the player's transform
    private Transform target;
    private Vector3 targetVector;   


    void Awake()
    {
        //getting player transform
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        this.targetVector.z = this.cameraZ;
    }


    void Update()
    {
        //set target vector x and y to target's x and y
        this.targetVector.x = this.target.position.x;
        this.targetVector.y = this.target.position.y;

        //lerp to target position
        //this.transform.position = Vector3.Lerp(this.transform.position, this.targetVector, this.smooth * Time.deltaTime);
        this.transform.position = this.targetVector;
    }
}
