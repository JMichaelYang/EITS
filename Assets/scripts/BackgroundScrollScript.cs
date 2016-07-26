using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
public class BackgroundScrollScript : MonoBehaviour
{
    //variable for parallax
    public float parallax;

    //mesh renderer and material
    private MeshRenderer meshRenderer;
    private Material material;

    //offset for scrolling
    private Vector2 offset;

	// Use this for initialization
	void Start ()
    {
        this.meshRenderer = this.GetComponent<MeshRenderer>();
        this.material = this.meshRenderer.material;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //get new offset based on position
        this.offset.x = this.transform.position.x / this.transform.localScale.x / parallax;
        this.offset.y = this.transform.position.y / this.transform.localScale.y / parallax;

        //set material offset based on offset we found
        this.material.mainTextureOffset = this.offset;
    }
}
