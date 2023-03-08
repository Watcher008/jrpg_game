using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    CharacterController _characterController;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Apply velocity to character controller.
        _characterController.Move(velocity * moveSpeed * Time.deltaTime);
    }

    //Called from PlayerInput
    void OnMove(InputValue value) {
        //Convert input values to usable velocity;
        velocity = value.Get<Vector2>().normalized;
        velocity.x *= -1;
        velocity.z = -velocity.y;
        velocity.y = 0;
    }
}
