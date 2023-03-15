using System.Collections;
using System.Collections.Generic;
using Aarthificial.Reanimation;
using UnityEngine;

public class EmeraldRenderer : MonoBehaviour
{
    //Reanimator drivers
    private static class Drivers 
    {
        public const string IsMoving = "isMoving";
        public const string IsRunning = "isRunning";
        public const string State = "state";
        public const string StepEvent = "stepEvent";
        public const string Direction = "direction";
    }
    [SerializeField] private List<AudioClip> stepSounds = new List<AudioClip>();
    private Reanimator _reanimator;
    private AudioSource _audioSource;
    private PlayerController _playerController;

    void Awake() 
    {
        _reanimator = GetComponent<Reanimator>();
        _playerController = GetComponent<PlayerController>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _reanimator.AddListener(Drivers.StepEvent, PlayStepSound);
    }

    private void OnDisable()
    {
        _reanimator.RemoveListener(Drivers.StepEvent, PlayStepSound);
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = _playerController.Velocity;
        bool isMoving = velocity != Vector3.zero;
        var facingDirection = _playerController.FacingDirection;

        _reanimator.Set(Drivers.IsMoving, isMoving);
        _reanimator.Set(Drivers.Direction, (int)facingDirection);
    }

    private void PlayStepSound()
    {
        if (stepSounds.Count > 0)
                _audioSource.PlayOneShot(stepSounds[Random.Range(0, stepSounds.Count)]);
    }
}
