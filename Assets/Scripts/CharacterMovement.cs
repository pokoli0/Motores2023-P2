using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    #region paramaters
    /// <summary>
    /// Movement speed of the player. Needs to keep constant while the player moves
    /// </summary>
    [SerializeField]
    private float _movementSpeed = 3.0f;
    /// <summary>
    /// Vertical speed assigned to character when jump starts
    /// </summary>
    [SerializeField]
    private float _jumpSpeed = 20.0f;
    /// <summary>
    /// Minimum vertical speed to limitate falling speed
    /// </summary>
    [SerializeField]
    private float _minSpeed = -10.0f;
    #endregion
    #region references
    /// <summary>
    /// Reference to Player's character controller
    /// </summary>
    private CharacterController _myCharacterController;
    /// <summary>
    /// Reference to Player's Transform
    /// </summary>
    private Transform _myTransform;
    /// <summary>
    /// Reference to Camera's CameraController
    /// </summary>
    private CameraController _cameraController;
    #endregion
    #region properties
    /// <summary>
    /// Horizontal component of the movement direction
    /// </summary>
    private float _xAxis;
    /// <summary>
    /// Vertical component of the movement direction
    /// </summary>
    private float _zAxis;
    /// <summary>
    /// Movement direction vector
    /// </summary>
    private Vector3 _movementDirection;
    /// <summary>
    /// Movement vertical speed (needs to be updated every frame due to gravity)
    /// </summary>
    private float _verticalSpeed;
    #endregion
    #region methods
    /// <summary>
    /// Public method to set the horizontal component of the movement direction
    /// </summary>
    /// <param name="x">Desired horizontal component</param>
    public void SetHorizontalInput(float x)
    {
        _xAxis = x;
    }
    /// <summary>
    /// Public method to set the vertical component of the movement direction
    /// </summary>
    /// <param name="y">Desired vertical component</param>
    public void SetVerticalInput(float y)
    {
        _zAxis = y;
    }
    /// <summary>
    /// Public method called when the player tries to perform a new Jump. (Will be called from InputManager)
    /// If the Character is grounded, it overrides current value or _verticalSpeed with _jumpSpeed.
    /// Otherwise, the request to jump is ignored.
    /// </summary>
    public void Jump()
    {
       if (_myCharacterController.isGrounded) 
       {
            _verticalSpeed = _jumpSpeed;
       }
    }
    #endregion
    /// <summary>
    /// START
    /// Needs to assign _myCharacterController, _myTransform and _cameraController.
    /// If InputManager is already assigned, it will also register the player on it.
    /// </summary>
    void Start()
    {
        // Inicializamos las referencias al transform y el CharacterController del player.
        _myTransform = transform;
        _myCharacterController = GetComponent<CharacterController>();
        _cameraController = FindObjectOfType<CameraController>();

        _verticalSpeed = -1.0f;

        if (GetComponent<InputManager>() != null)
        {
            GameManager.Instance.Input.RegisterPlayer(this);
        }
    }
    /// <summary>
    /// UPDATE
    /// Needs to calculate and normalize horizontal movement direction
    /// Needs to update vertical speed according to gravity
    /// Finally move the character according to desired _movementSpeed in horizontal and updated _verticalSpeed
    /// Final details:
    /// -Ensure the character looks in the desired direction according to move direction.
    /// -Ensure to set the vertical following behaviour for camera depending on whether the character is grounded or not.
    /// </summary>

    void Update()
    {
        // Creamos el Vector3 que determina la dirección en función del input recogido.
        _movementDirection = new Vector3(_xAxis, 0, _zAxis).normalized;

        //Actualizamos las velocidad vertical en función de la gravedad
        _verticalSpeed += Physics.gravity.y * Time.deltaTime;

        _verticalSpeed = Mathf.Max(_verticalSpeed, _minSpeed);

        //Movemos al personaje con la velocidad _movementSpeed en el plano y actualizamos _verticalSpeed
        _myCharacterController.Move((_movementDirection  * _movementSpeed + _verticalSpeed * Vector3.up) * Time.deltaTime);

        if (_movementDirection != Vector3.zero)
        {
            // Para que mire en la dirección del movimiento: 
            _myTransform.forward = _movementDirection.normalized;
        }

        _cameraController.SetVerticalFollow(_myCharacterController.isGrounded);
    }
}