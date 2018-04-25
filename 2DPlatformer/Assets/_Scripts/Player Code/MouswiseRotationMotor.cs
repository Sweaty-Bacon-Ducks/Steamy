using UnityEngine;

//This script only works when the camera attached is ortographic
public class MouswiseRotationMotor : MonoBehaviour
{
    bool isFlipped = true;

    public void RotateMousewise(Camera targetCam, GameObject @object, float RotationOffset = 0f)
    {   
        Transform @objectTr = @object.transform;

        SpriteRenderer sprite = @object.GetComponent<SpriteRenderer>();

        var input = targetCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = ( input - @objectTr.position).normalized;   //pozycja myszy - pozycja ręki 
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + RotationOffset;
        @objectTr.rotation = Quaternion.Euler(0f, 0f, rotationZ);   //ustawianie rotacji
        
        //Flipping the sprites of the player and the weapon
        if (Mathf.Abs(rotationZ) >= 90 && !isFlipped)
        {
            isFlipped = true;
            FlipChilds(@object);
        }
        if (Mathf.Abs(rotationZ) < 90 && isFlipped)
        {
            isFlipped = false;
            FlipChilds(@object);
        }
    }
    void FlipChilds(GameObject @object)
    {
        foreach (Transform tr in @object.transform)
        {
            foreach (Transform item in tr)
            {
                //Debug.Log(item.name);
                SpriteRenderer sr = tr.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.flipY = !sr.flipY;
                }
            }
            
        }
    }
}