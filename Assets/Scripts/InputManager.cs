using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    /// <summary>
    /// Reference to Player's CharacterMovement component, to be set from editor
    /// </summary>
    [SerializeField]
    private CharacterMovement _playerCharacterMovement;
    /// <summary>
    /// Called every frame.
    /// Needs to assign horizontal and vertical axis for Player's Character Movement.
    /// </summary>
    void Update()
    {
        // Llamamos a los métodos del CharacterMovement que asignan un valor positivo (hasta +1) 
        //o negativo (hasta -1) para el eje X o Z en función del input. Será 0 si no hay input.
        _playerCharacterMovement.SetHorizontalInput(Input.GetAxis("Horizontal"));
        _playerCharacterMovement.SetVerticalInput(Input.GetAxis("Vertical"));
    }
}