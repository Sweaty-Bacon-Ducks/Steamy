using Steamy.Player;
using Steamy.Player.MotionModes;
using UnityEngine;

[CreateAssetMenu(menuName ="MotionModes/BodyRotationMode")]
public class BodyRotationMode : MotionMode
{
    public float RotationSpeed;
	public float RotationOffset;

	public string MainCameraName;
    public string FacingRightAnimatorParameter;
    public string HeadTiltAnimatorParameter;
    public string AimingAnimatorParameter;
    public string RotatingAnimatorParameter;
    public string GoingRightAnimatorParameter;
    public string AxisName;

    public float Rotation, TargetRotation, RemainingRotation;
	

    public override void ApplyMotion(CharacterViewModel characterViewModel)
    {
        float axisValue = Input.GetAxis(AxisName);
        var characterTransform = characterViewModel.transform;
        var animator = characterViewModel.GetComponent<Animator>();
        Camera mainCamera = GameObject.Find(MainCameraName).GetComponentInChildren<Camera>();
        bool facingRight = animator.GetBool(FacingRightAnimatorParameter);
        var characterPosition = characterTransform.position;
        var headTransform = new Vector3(characterPosition.x, characterPosition.y, characterPosition.z);
        headTransform.y += 1.5f;
        var headPosition = mainCamera.WorldToScreenPoint(headTransform);
        var headDirection = headPosition - Input.mousePosition;
        var headAngle = Quaternion.FromToRotation(Vector3.up, headDirection).eulerAngles.z;

        if (axisValue >= 0) animator.SetBool(GoingRightAnimatorParameter, true);
        else animator.SetBool(GoingRightAnimatorParameter, false);

        if ((Input.mousePosition - headPosition).magnitude >= 120)
        {
            animator.SetBool(AimingAnimatorParameter, true);
        }
        else 
        {
            animator.SetBool(AimingAnimatorParameter, false);
        }

        if (Input.mousePosition.x >= headPosition.x)
        {
            animator.SetFloat(HeadTiltAnimatorParameter, (180 - headAngle) / 180.0f);
        }

        if (Input.mousePosition.x < headPosition.x)
        {
            animator.SetFloat(HeadTiltAnimatorParameter, (headAngle - 180) / 180.0f);
        }

        if (Input.mousePosition.x - 1.0f >= headPosition.x && facingRight == false)
        {
            animator.SetBool(FacingRightAnimatorParameter, true);
        }

        if (Input.mousePosition.x + 1.0f <= headPosition.x && facingRight == true)
        {
            animator.SetBool(FacingRightAnimatorParameter, false);
        }


        if (facingRight) TargetRotation = 0.0f;
        else TargetRotation = 180.0f;

        if(RemainingRotation == 0)
        {
            if (Rotation != TargetRotation)
            {
                RemainingRotation += 180.0f;
                animator.SetBool(RotatingAnimatorParameter, true);
            }
            else 
            {
                animator.SetBool(RotatingAnimatorParameter, false);
            }
        }

		if (RemainingRotation > 0)
		{
			if (RemainingRotation <= Time.deltaTime * RotationSpeed)
			{
				if (Rotation < 180.0f) Rotation = 180.0f;
				else Rotation = 0.0f;
				RemainingRotation = 0.0f;

				if (Rotation >= 360.0f)
				{
					Rotation -= 360.0f;
				}
			}
			else if (Rotation != TargetRotation)
			{
				Rotation += Time.deltaTime * RotationSpeed;
				RemainingRotation -= Time.deltaTime * RotationSpeed;

				if (Rotation >= 360.0f)
				{
					Rotation -= 360.0f;
				}
			}
		}
		characterTransform.localRotation = Quaternion.Euler(0, Rotation + RotationOffset, 0);
	}
}
