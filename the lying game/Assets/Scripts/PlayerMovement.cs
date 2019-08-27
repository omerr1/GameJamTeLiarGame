using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private AnimationCurve jumpCurve;
    [SerializeField] private float jumpMultiplayer;
    [SerializeField] private KeyCode jumpKey;

    private bool isJumping;

    private CharacterController characterController;



    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float vertInput = Input.GetAxis("Vertical");
        float horizInput = Input.GetAxis("Horizontal");

        Vector3 vertMove = transform.forward * vertInput;
        Vector3 horizMove = transform.right * horizInput;

        characterController.SimpleMove(Vector3.ClampMagnitude(vertMove + horizMove, 1f) * moveSpeed);

        JumpInput();
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        float timeInAir = 0f;
        characterController.slopeLimit = 90f;

        do
        {
            float jumpForce = jumpCurve.Evaluate(timeInAir);
            characterController.Move(Vector3.up * jumpForce * jumpMultiplayer * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!characterController.isGrounded && characterController.collisionFlags != CollisionFlags.CollidedAbove);

        isJumping = false;
        characterController.slopeLimit = 45f;
    }
}
