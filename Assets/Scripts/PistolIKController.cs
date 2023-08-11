using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolIKController : MonoBehaviour
{
    public Transform aimingTarget; // The target to aim at
    public Transform rightHand;    // The character's right hand bone
    public float ikWeight = 1f;    // IK weight (0 to 1)

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            // Set IK weights
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, ikWeight);

            // Calculate IK target position and rotation
            Vector3 targetPosition = aimingTarget.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - rightHand.position);

            // Apply IK target position and rotation
            animator.SetIKPosition(AvatarIKGoal.RightHand, targetPosition);
            animator.SetIKRotation(AvatarIKGoal.RightHand, targetRotation);
        }
    }
}
