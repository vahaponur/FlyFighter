using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Serialization;


public class PlayerController : StandardInput
{
    #region Serialized Fields

    [Header("Position Change Variables")]
    [FormerlySerializedAs("xMoveRange")]
    [Range(1, 10)]
    [SerializeField]
    private float _xMoveRange = 8;

    [FormerlySerializedAs("yMoveRange")]
    [Range(1, 6)]
    [SerializeField]
    private float _yMoveRange = 5;

    [FormerlySerializedAs("_speed")]
    [Range(20, 100)]
    [SerializeField]
    private float _axisSpeed = 35f;

    [Header("Rotation Change Variables")]
    [SerializeField]
    [Range(1, 5)]
    private float _positionPitchFactor = 4f;

    [SerializeField][Range(1, 5)] private float _positionYawFactor = 2f;

    [SerializeField][Range(1, 15)] private float _controlPitchFactor = 15f;
    [SerializeField][Range(1, 30)] private float _controlRollFactor = 30f;


    #endregion

    #region Private Fields

    /// <summary>
    /// One over square root two
    /// </summary>
    private readonly float _hypotenusScaler = 0.707f;

    /// <summary>
    /// For returning the original value of axis speed if altering needed
    /// </summary>
    private float _originalAxisSpeed;

    /// <summary>
    /// Lasers attached to the ship
    /// </summary>
    private GameObject[] lasers;

    #endregion

    #region Public Properties

    #endregion

    #region MonoBehaveMethods

    new void Awake()
    {
    }


    new void Start()
    {
        lasers = GetLasers();
        _originalAxisSpeed = _axisSpeed;
    }


    new void Update()
    {
        base.Update();
        ProcessMovement();
        ProcessRotation();
        ProcessFiring();
    }

    #endregion

    #region PublicMethods

    #endregion

    #region PrivateMethods

    /// <summary>
    /// Processes player movement
    /// </summary>
    void ProcessMovement()
    {
        MoveHorizontal();
        MoveVertical();
    }

    /// <summary>
    /// Moves the player horizontaly based on horizontan axis and xMoveRange
    /// </summary>
    void MoveHorizontal()
    {
        float xOffset = _horizontalInput * _axisSpeed * Time.deltaTime;
        float newX = transform.localPosition.x + xOffset;
        newX = Mathf.Clamp(newX, -_xMoveRange, _xMoveRange);

        transform.localPosition = new Vector3(newX, transform.localPosition.y, transform.localPosition.z);
    }

    /// <summary>
    /// Moves the player vertically based on vertical axis and yMoveRange
    /// </summary>
    void MoveVertical()
    {
        float yOffset = _verticalInput * _axisSpeed * Time.deltaTime;
        float newY = transform.localPosition.y + yOffset;
        newY = Mathf.Clamp(newY, -_yMoveRange, _yMoveRange);

        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }

    /// <summary>
    /// When there is input on both axis, player moves on hypotenuse, function decreases the movement speed
    /// </summary>
    void HandleHypotenuse()
    {
        bool movementOnBoth = (_horizontalInput != 0 && _horizontalInput != Mathf.Epsilon) &&
                              (_verticalInput != 0 && _verticalInput != Mathf.Epsilon);
        _axisSpeed = movementOnBoth ? _originalAxisSpeed * _hypotenusScaler : _originalAxisSpeed;
    }

    /// <summary>
    /// Calculates pitch,yaw,roll based on player position and rotation
    /// </summary>
    private void ProcessRotation()
    {
        var _location = transform.localPosition;

        float pitch = CalculatePitch(); //x Axis
        float yaw = CalculateYaw(); //y Axis
        float roll = CalculateRoll(); //z Axis;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

        float CalculatePitch()
        {
            float pitchPosChange = _location.y * -_positionPitchFactor;
            float pitchInputChange = -_verticalInput * _controlPitchFactor;
            return pitchPosChange + pitchInputChange;
        }

        float CalculateYaw()
        {
            float yawPosChange = _location.x * -_positionYawFactor;
            float yawInputChange = 0f;
            return yawPosChange + yawInputChange;
        }

        float CalculateRoll()
        {
            float rollInputChange = -_horizontalInput * _controlRollFactor;
            float rollPosChange = 0.0f;
            return rollInputChange + rollPosChange;
        }
    }

    /// <summary>
    /// Process firing event
    /// </summary>
    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ControlEmission(true);

            return;
        }

        ControlEmission(false);
    }

    /// <summary>
    /// Gets the lasers attached the player spaceship
    /// </summary>
    /// <returns>Laser gameobjects attached to player spaceship</returns>
    GameObject[] GetLasers()
    {
        var lasers = new List<GameObject>();
        var lasIndex = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Laser"))
            {
                lasers.Add(child.gameObject);
                lasIndex++;
            }
        }

        return lasers.ToArray();
    }

    /// <summary>
    /// Controls emission of the lasers
    /// </summary>
    /// <param name="isActive">For each laser, true mean enable, false otherwise</param>
    void ControlEmission(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var em = laser.GetComponent<ParticleSystem>().emission;
            em.enabled = isActive;
        }
    }


    #endregion
}