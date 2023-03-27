using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 _velocity;
    Rigidbody2D _rigidbody2D;
    [SerializeField] private float _walkSpeed;

    public EmeraldState State { get; private set; } = EmeraldState.Movement;
    public Vector2 Velocity => _rigidbody2D.velocity;
    public Vector2 CurrentInput { get; private set; }
    public FacingDirections FacingDirection { get; private set; } = FacingDirections.South;

    void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (State) {
            case EmeraldState.Movement:
                UpdateMovementState();
                break;
        }
    }

    void UpdateMovementState() {
        // If the input vector has a magnitude greater than 1, normalize it
        if (CurrentInput.magnitude > 1f) {
            CurrentInput.Normalize();
        }

        //Apply velocity to character controller.
        var movement = CurrentInput;
        movement *= _walkSpeed;

        // Move the player using the rigidbody
        _rigidbody2D.velocity = movement;
    }

    //Called from PlayerInput
    void OnMove(InputValue value) {
        //Convert input values to usable velocity;
        CurrentInput = value.Get<Vector2>().normalized;
        FacingDirection = GetDirection(CurrentInput);
    }

    private FacingDirections GetDirection(Vector2 input) {
        // Calculate the absolute x and y components of the input vector
        float x = Mathf.Abs(input.x);
        float y = Mathf.Abs(input.y);

        // Determine the dominant direction based on the larger component
        if (x > y)
        {
            // East or West
            if (input.x > 0f)
            {
                return (FacingDirections)0; // East
            }
            else
            {
                return (FacingDirections)3; // West
            }
        }
        else
        {
            // North or South
            if (input.y > 0f)
            {
                return (FacingDirections)1; // North
            }
            else
            {
                return (FacingDirections)2; // South
            }
        }
    }
}

    public enum EmeraldState
    {
        Movement = 0,
        Fighting = 1,
    }

    public enum FacingDirections {
        East = 0,
        North = 1,
        South = 2,
        West = 3
    }