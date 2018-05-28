using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Parallax : MonoBehaviour
{

    public GameObject[] backgrounds;
    float[] scales;
    float smoothing = 10f;
    Transform cam;
    Vector3 previousCamPosition;
    float reduceChangeOfPositionX = 7f;
    float reduceChangeOfPositionY = 10f;

    private const string BACKROUND_TAG = "Background";

    void Awake()
    {
        Player player = GetComponent<Player>();
        cam = player.info.PlayerCam.transform;

        backgrounds = GameObject.FindGameObjectsWithTag(BACKROUND_TAG);
    }
    void Start()
    {
        previousCamPosition = cam.position;
        scales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            scales[i] = backgrounds[i].transform.position.z;
        }
    }


    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float changeOfPositionX = (previousCamPosition.x - cam.position.x) * scales[i];
            float changeOfPositiony = (previousCamPosition.y - cam.position.y) * scales[i];
            float backgroundPositionX = backgrounds[i].transform.position.x + changeOfPositionX / reduceChangeOfPositionX;
            float backgroundPositionY = backgrounds[i].transform.position.y + changeOfPositiony / reduceChangeOfPositionY;
            Vector3 targetPosition = new Vector3(backgroundPositionX, backgroundPositionY, backgrounds[i].transform.position.z);
            backgrounds[i].transform.position = Vector3.Lerp(backgrounds[i].transform.position, targetPosition, smoothing * Time.deltaTime);
        }
            previousCamPosition = cam.position;
    }
}
