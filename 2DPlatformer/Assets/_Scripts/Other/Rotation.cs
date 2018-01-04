using UnityEngine;

//This script only works when the camera attached is ortographic
[RequireComponent(typeof(SpriteRenderer))]
public class Rotation : MonoBehaviour
{
    public float RotationOffset;
    public GameObject Crosshair;

    private Camera mainCamera;
    private Transform ArmTransform;
    private SpriteRenderer spriteRend;
    private bool isFlipped = false;

    private void Awake()
    {
        //Instantiate(Crosshair);   //Trzeba ustawić jeszcze gdzie ma się ten obiekt pojawiać, co zrobię następnym razem
        mainCamera = Camera.main;
        spriteRend = GetComponent<SpriteRenderer>();
        ArmTransform = transform;
    }
    void Update()
    {
        Vector3 difference = (mainCamera.ScreenToWorldPoint(Input.mousePosition) - ArmTransform.position).normalized;   //pozycja myszy - pozycja ręki 
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + RotationOffset;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);   //ustawianie rotacji

        //Flipping the sprites of the player and the weapon
        if (Mathf.Abs(rotationZ) >= 90 && !isFlipped)
        {
            isFlipped = true;
            spriteRend.flipY = true;
        }
        if (Mathf.Abs(rotationZ) < 90 && isFlipped)
        {
            isFlipped = false;
            spriteRend.flipY = false;
        }
    }
}