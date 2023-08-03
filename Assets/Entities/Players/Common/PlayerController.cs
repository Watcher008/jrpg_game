using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [SerializeField] private float _walkSpeed;
    private PlayerInput _input;

    public EmeraldState State { get; private set; } = EmeraldState.Movement;
    public Vector2 Velocity => _rigidbody2D.velocity;
    private Vector2 _movementInput;
    public FacingDirections FacingDirection { get; private set; } = FacingDirections.South;

    private void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();

        _input.actions["Move"].performed += OnMove;
    }

    private void Update()
    {
        if (State == EmeraldState.Movement) UpdateMovementState();
    }

    private void OnDestroy()
    {
        _input.actions["Move"].performed -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext obj)
    {
        _movementInput = obj.ReadValue<Vector2>();
    }

    private void UpdateMovementState() 
    {
        _movementInput = _input.actions["Move"].ReadValue<Vector2>();
        FacingDirection = GetDirection(_movementInput);;

        // Move the player using the rigidbody
        _rigidbody2D.velocity = _movementInput * _walkSpeed;
    }

    private FacingDirections GetDirection(Vector2 input) 
    {
        // Calculate the absolute x and y components of the input vector
        float x = Mathf.Abs(input.x);
        float y = Mathf.Abs(input.y);

        // Determine the dominant direction based on the larger component
        if (x > y)
        {
            // East or West
            if (input.x > 0f)
            {
                return FacingDirections.East;
            }
            else
            {
                return FacingDirections.West;
            }
        }
        else
        {
            // North or South
            if (input.y > 0f)
            {
                return FacingDirections.North;
            }
            else
            {
                return FacingDirections.South;
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