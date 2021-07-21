using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float CAMERA_Z_COORD = -10f;
    private const float CAMERA_SIZE_DEFAULT = 500f;
    private const float CAMERA_MOVE_SPEED_DEFAULT = 5f;
    private const float CAMERA_MOVE_FACTOR_DEFAULT = 1f;
    private const float CAMERA_SIZE_MIN = 200f;
    private const float CAMERA_SIZE_MAX = 1100f;
    private const float CAMERA_SIZE_STEP = 150f;
    private Vector3 cameraDragOrigin;
    private Vector3 mouseDragOrigin;


    private int cameraSpeedFactor = 1;

    public int CameraSpeedFactor { get => cameraSpeedFactor; set => cameraSpeedFactor = value; }
    public Vector3 CameraDragOrigin { get => cameraDragOrigin; set => cameraDragOrigin = value; }
    public Vector3 MouseDragOrigin { get => mouseDragOrigin; set => mouseDragOrigin = value; }


    // Start is called before the first frame update
    void Start()
    {
        SetCameraPositionDefault();
        SetCameraSizeDefault();
        Debug.Log("Camera Position and Size defaulted: " + transform.position + ", Camera speed factor: " + CameraSpeedFactor + ", Camera Orth size: " + Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraFactor();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (CAMERA_MOVE_SPEED_DEFAULT * CameraSpeedFactor), CAMERA_Z_COORD);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - CAMERA_MOVE_SPEED_DEFAULT, CAMERA_Z_COORD);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - CAMERA_MOVE_SPEED_DEFAULT, transform.position.y, CAMERA_Z_COORD);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + CAMERA_MOVE_SPEED_DEFAULT, transform.position.y, CAMERA_Z_COORD);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SetCameraPositionDefault();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.orthographicSize < CAMERA_SIZE_MAX)
            {
                Camera.main.orthographicSize = Camera.main.orthographicSize + 30;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.orthographicSize > CAMERA_SIZE_MIN)
            {
                Camera.main.orthographicSize = Camera.main.orthographicSize - 30;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            SetCameraSizeDefault();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CameraDragOrigin = transform.position;
            MouseDragOrigin = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 moveDelta = MouseDragOrigin - Input.mousePosition;
            transform.position = CameraDragOrigin + moveDelta;
        }
    }

    //private void MouseMovement()
    //{
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            dragOrigin = Input.mousePosition;
    //            return;
    //        }

    //        if (!Input.GetMouseButton(0)) return;

    //        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
    //        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

    //        transform.Translate(move, Space.World);
    // }

    private void SetCameraSizeDefault()
    {
        Camera.main.orthographicSize = CAMERA_SIZE_DEFAULT;
        UpdateCameraFactor();
    }

    private void SetCameraPositionDefault()
    {
        transform.position = new Vector3(0, 0, CAMERA_Z_COORD);
    }

    private void UpdateCameraFactor()
    {
        float sizeValue = Camera.main.orthographicSize - CAMERA_SIZE_DEFAULT;
        if (sizeValue > 0)
        {
            CameraSpeedFactor = 1 + (int) Mathf.Floor(sizeValue / CAMERA_SIZE_STEP);
        }
    }
}
