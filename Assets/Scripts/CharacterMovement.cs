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
    #endregion
    /// <summary>
    /// Used to initialize references
    /// </summary>
    void Start()
    {
        // Inicializamos las referencias al transform y el CharacterController del player.
        _myTransform = transform;
        _myCharacterController = GetComponent<CharacterController>();
    }
    /// <summary>
    /// Used to set movement direction, apply speed to character controller
    /// and set forward direction of the player
    /// </summary>
    void Update()
    {
        // Creamos el Vector3 que determina la dirección en función del input recogido.
        _movementDirection = new Vector3(_xAxis, 0, _zAxis);
        // Usamos el método Move, que mueve el gameObject en la dirección determinada por
        //_movementDirection, y con la velocidad _movementSpeed. 
        _myCharacterController.Move(_movementDirection * Time.deltaTime * _movementSpeed);
    }
}