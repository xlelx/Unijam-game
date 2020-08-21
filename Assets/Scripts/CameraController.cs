using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Vector2 offset;
    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;

    public float zoomLimiter = 50f;


    [SerializeField]
    private Transform player1;
    [SerializeField]
    private Transform player2;
    private Vector3 velocity;
    private Vector2 cameraCenter;
    private float cameraHeight;

    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void CalculateBounds()
    {
        var bounds = new Bounds(player1.position, Vector2.zero);
        bounds.Encapsulate(player1.position);
        bounds.Encapsulate(player2.position);
        cameraCenter = bounds.center;
        cameraHeight = bounds.size.y;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Move();
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, cameraHeight / zoomLimiter);
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, newZoom, Time.deltaTime);

    }

    void Move()
    {

        CalculateBounds();
        Vector2 newPosition = cameraCenter + offset;

        //change transform.position.x to newPosition.x if we want the camera to center around the x axis as well
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, newPosition.y, -10), ref velocity, smoothTime);

    }
}
