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
    public string HeadTiltAnimatiorParameter;

    public override void ApplyMotion(CharacterViewModel characterViewModel)
    {
        var characterTransform = characterViewModel.transform;
        var animator = characterViewModel.GetComponent<Animator>();
        Camera mainCamera = GameObject.Find(MainCameraName).GetComponentInChildren<Camera>();

        bool facingRight = animator.GetBool(FacingRightAnimatorParameter);

        var headTransform = animator.GetBoneTransform(HumanBodyBones.Head);
        var headPosition = mainCamera.WorldToScreenPoint(headTransform.position);
        var headDirection = mainCamera.WorldToScreenPoint(headPosition - Input.mousePosition);
        var headAngle = Vector3.Angle(headDirection, (-1) * characterTransform.up);

        if (Input.mousePosition.x - 20.0f >= headPosition.x)
        {
            animator.SetFloat(HeadTiltAnimatiorParameter, (headAngle - 20.0f) / 180.0f);
        }

        if (Input.mousePosition.x + 20.0f <= headPosition.x)
        {
            animator.SetFloat(HeadTiltAnimatiorParameter, (200.0f - headAngle) / 180.0f);
        }

        if (Input.mousePosition.x - 50.0f >= headPosition.x && facingRight == false)
        {
            animator.SetBool(FacingRightAnimatorParameter, true);
        }

        if (Input.mousePosition.x + 50.0f <= headPosition.x && facingRight == true)
        {
            animator.SetBool(FacingRightAnimatorParameter, false);
        }

		float y, targetY, remainingY;
		y = targetY = remainingY = 0f;
		if (!facingRight)
		{
			targetY = 180.0f;
		}
		if (y != targetY && remainingY == 0)
		{
			remainingY += 180.0f;
		}

		if (remainingY > 0)
		{
			if (remainingY <= Time.deltaTime * RotationSpeed)
			{
				if (y < 180.0f) y = 180.0f;
				else y = 0.0f;
				remainingY = 0.0f;

				if (y >= 360.0f)
				{
					y -= 360.0f;
				}
			}
			else if (y != targetY)
			{
				y += Time.deltaTime * RotationSpeed;
				remainingY -= Time.deltaTime * RotationSpeed;

				if (y >= 360.0f)
				{
					y -= 360.0f;
				}
			}
		}
		characterTransform.localRotation = Quaternion.Euler(0, y + RotationOffset, 0);
	}
}
