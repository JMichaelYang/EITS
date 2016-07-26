using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    //bullet speed
    public float speed = 25f;
    //bullet lifetime in seconds
    public float lifeTime = 3f;

    //bullet rigid body component
    private Rigidbody2D rigidBody;

	//when bullet wakes up, set it to inactive after lifetime
	void Awake ()
    {
        //get rigid body component
        this.rigidBody = this.GetComponent<Rigidbody2D>();
	}

    private void Remove()
    {
        //deactivate bullet for pooling
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        this.rigidBody = null;
        //reset bullet angular velocity
        this.rigidBody.angularVelocity = 0f;
        //set velocity of rigid body
        this.rigidBody.velocity = this.speed * this.transform.forward;
        //set bullet to be removed after certain amount of time
        this.Invoke("Remove", this.lifeTime);
    }

    private void OnDisable()
    {
        //cancel the automatic destruction if it is disabled beforehand
        this.CancelInvoke();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        this.Remove();
    }
}
