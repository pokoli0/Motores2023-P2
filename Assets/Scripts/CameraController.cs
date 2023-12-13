using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Horizonal distance from Camera to CameraTarget.
    /// </summary>
    [SerializeField]
    private float _horizontalOffset = 1.0f;
    /// <summary>
    /// Vertical distance from Camera to CameraTarget.
    /// </summary>
    [SerializeField]
    private float _verticalOffset = 1.0f;
    /// <summary>
    /// Multiplier factor to regulate camera responsiveness to target's movement.
    /// </summary>
    [SerializeField]
    private float _followFactor = 1.0f;
    #endregion
    #region references
    /// <summary>
    /// Camera target transform. Actually, the one the camera needs to follow.
    /// </summary>
    [SerializeField]
    private Transform _targetTransform;
    /// <summary>
    /// Reference to own transform.
    /// </summary>
    private Transform _myTransform;
    #endregion
    #region properties
    /// <summary>
    /// If disabled, the camera does not follow target in vertical axis and keeps its own Y coordinate.
    /// </summary>
    private bool _yFollowEnabled = true;
    /// <summary>
    /// Stores own previous position's Y coordinate, to be able to keep it in case vertical following is disabled.
    /// </summary>
    private float _yPreviousFrameValue;
    #endregion
    #region methods
    /// <summary>
    /// Public methods to allow others to set vertical following behaviour
    /// </summary>
    /// <param name="verticalFollowEnabled"></param>
    public void SetVerticalFollow(bool verticalFollowEnabled)
    {
        // Si el personaje está en el suelo, _yFollowEnabled será true,
        // y se guarda el frame anterior en el eje Y de la cámara.
        _yFollowEnabled = verticalFollowEnabled;
        if (_yFollowEnabled)
        {
            _yPreviousFrameValue = _targetTransform.position.y;
        }
    }
    #endregion
    /// <summary>
    /// START
    /// Needs to assign _myTransform and initialize _yPreviousFrameValue
    /// </summary>
    void Start()
    {
        _myTransform = transform;
        _yPreviousFrameValue = _targetTransform.position.y;

        // Rotación de la cámara (no va a cambiar)
        _myTransform.LookAt(_targetTransform); 

        // Posición inicial de la cámara, fijada donde esta el target.
        _myTransform.position = 
            new(_targetTransform.position.x, _targetTransform.position.y + _verticalOffset,
            _targetTransform.position.z - _horizontalOffset);
    }
    /// <summary>
    /// LATE UPDATE
    /// Needs to calculate the desired position for the camera.
    /// This calculation will differ depending on _yFollowEnabled.
    /// Once calculated, the new camera position can be assigned according to it, in a smoothed way.
    /// </summary>
    void LateUpdate()
    {
        // Creamos vector destino
        Vector3 destinationVector;
           
        if (_yFollowEnabled)
        {
            destinationVector = 
                new(_targetTransform.position.x,
                _targetTransform.position.y + _verticalOffset, 
                _targetTransform.position.z - _horizontalOffset);
        }
        else
        {
            // Si no hacemos seguimiento en Y, tendremos en cuenta el frame anterior de Y, guardado
            // inicialmente en el Start.
            destinationVector =
                new(_targetTransform.position.x,
                _yPreviousFrameValue + _verticalOffset,
                _targetTransform.position.z - _horizontalOffset);
        }

        // Interpola entre la posición actual y el destinationVector,
        // haciendo que la cámara se mueva de forma suave, en base al tiempo y al followFactor.
        _myTransform.position =
                Vector3.Lerp(_myTransform.position, destinationVector, _followFactor * Time.deltaTime);

    }
}