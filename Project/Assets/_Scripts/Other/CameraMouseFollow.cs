using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseFollow : MonoBehaviour {

    private Vector3 cameraTarget;
    private Transform target;
    private Camera cam;

    public Vector3 offset;
    public float mouseRangeX = 35f;
    public float mouseRangeY = 35f;

    void Start()
    {
        target = gameObject.transform.parent;
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 newOffset = offset;
        Vector3 mousePos = Input.mousePosition;

        newOffset += cam.ScreenToWorldPoint(mousePos);

        newOffset.x = Mathf.Clamp(newOffset.x, target.transform.position.x - mouseRangeX, target.transform.position.x + mouseRangeX);
        newOffset.y = Mathf.Clamp(newOffset.y, target.transform.position.y - mouseRangeY, target.transform.position.y + mouseRangeY);

        cameraTarget = new Vector3((target.position.x + newOffset.x) / 2, (target.position.y + newOffset.y) / 2, (transform.position.z));

        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
    }
}
