using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //zoom
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    private float maxZoom = 8f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    [SerializeField]
    private UnityEngine.Camera camcontroll;
    // Start is called before the first frame update
    void Start()
    {
        zoom = camcontroll.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        camcontroll.orthographicSize = Mathf.SmoothDamp(camcontroll.orthographicSize, zoom, ref velocity, smoothTime);
    }
}
