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

    [SerializeField]
    private ShootComponent _shootComponent;
    
    #region methods
    /// <summary>
    /// Public method to allow CharacterMovement to register on InputManager so it can receive input.
    /// </summary>
    /// <param name="playerCharacterMovement">Player's CharacterMovement (Component to be reigstered)</param>
    public void RegisterPlayer(CharacterMovement playerCharacterMovement)
    {
        _playerCharacterMovement = playerCharacterMovement;
    }

    public void RegisterPlayer(ShootComponent shootComponent)
    {
        _shootComponent = shootComponent;
    }

    public Vector3 GetDir()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }


    #endregion

    /// <summary>
    /// UPDATE
    /// Receive Horizontal input from player, if any, and set it on Player's CharacterMovement
    /// Receive Vertical input from player, if any, and set it on Player's CharacterMovement
    /// Receive Jump input from player, if any, and call corresponding method on Player's CharacterMovement
    /// </summary>
    void Update()
    {
        // Llamamos a los m�todos del CharacterMovement que asignan un valor positivo (hasta +1) 
        //o negativo (hasta -1) para el eje X o Z en funci�n del input. Ser� 0 si no hay input.
        _playerCharacterMovement.SetHorizontalInput(Input.GetAxis("Horizontal"));
        _playerCharacterMovement.SetVerticalInput(Input.GetAxis("Vertical"));


        if (Input.GetKeyDown("space"))
        {
            _playerCharacterMovement.Jump();
        }

        // Llamamos a los metodos de ShootComponent cuando se reciba el input
        if (Input.GetKeyDown("e"))
        {
            _shootComponent.Shoot();
        }
    }
}