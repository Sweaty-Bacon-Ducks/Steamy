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
            float parallaxX = (previousCamPosition.x - cam.position.x) * scales[i];
            float parallaxY = (previousCamPosition.y - cam.position.y) * scales[i];
            float backX = backgrounds[i].transform.position.x + parallaxX;
            float backY = backgrounds[i].transform.position.y + parallaxY;
            Vector3 targetPosition = new Vector3(backX, backY, backgrounds[i].transform.position.z);
            backgrounds[i].transform.position = Vector3.Lerp(backgrounds[i].transform.position, targetPosition, smoothing * Time.deltaTime);
        }
            previousCamPosition = cam.position;
    }
}
