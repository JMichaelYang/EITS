using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    //aspect ratio (16:9) can be set at design time
    public float aspectWidth = 16f;
    public float aspectHeight = 9f;

    //size for zoom
    public float normalSize = 16f;
    float currentSize;
    public float minSize = 8f;
    public float maxSize = 32f;
    //zoom speed
    public float sensitivity = 10f;
    //zoom control key
    public string zoomKey = "Mouse ScrollWheel";

    void Start()
    {
        //set camera aspect ratio
        Camera.main.aspect = this.aspectWidth / this.aspectHeight;

        //set camera size
        Camera.main.orthographicSize = this.currentSize = this.normalSize;
    }

    void Update()
    {
        //get mouse wheel scroll data
        float scroll = Input.GetAxis(this.zoomKey);
        //if scrolled, zoom
        if (scroll != 0f)
        {
            this.currentSize -= scroll * this.sensitivity;
            this.currentSize = Mathf.Clamp(this.currentSize, this.minSize, this.maxSize);
        }

        //adjust camera size to match currentSize
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, this.currentSize, this.sensitivity * Time.deltaTime);
    }
}
