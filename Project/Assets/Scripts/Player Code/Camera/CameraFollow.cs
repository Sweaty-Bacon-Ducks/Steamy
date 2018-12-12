using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Camera cam;

    public Transform Target;

    public Vector3 Offset;
    public float MovementSpeed = 8f;
    public float MouseRange = 5f;

    void Start()
    {
        cam = GetComponent<Camera>();
        //transform.eulerAngles = new Vector3(70, 0, 0); for rotation if needed
    }

    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = MouseRange;
        Vector3 CursorPosition = cam.ScreenToWorldPoint(mousePos);

        Vector3 Center = new Vector3((Target.position.x + CursorPosition.x) / 2 + Offset.x, (Target.position.y + CursorPosition.y) / 2 + Offset.y, Target.position.z + Offset.z);

        transform.position = Vector3.Lerp(transform.position, Center, Time.deltaTime * MovementSpeed);
    }
}
