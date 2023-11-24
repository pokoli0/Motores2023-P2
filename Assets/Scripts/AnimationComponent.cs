using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to player's Character Controller.
    /// Needs to be assigned on Start
    /// </summary>
    private CharacterController _myCharacterController;
    /// <summary>
    /// Reference to player's Animator.
    /// Needs to be assigned on Start.
    /// </summary>
    private Animator _myAnimator;
    #endregion
    /// <summary>
    /// START
    /// Assign _myCharacterController and _myAnimator
    /// Check if both are correct or disable component
    /// </summary>
    void Start()
    {
        _myCharacterController = GetComponent<CharacterController>();
        _myAnimator = GetComponent<Animator>();
    }
    /// <summary>
    /// UPDATE
    /// Evaluate _myCharacterController velocity
    /// Assign the right animation according to this using integer parameter "AnimState"
    /// </summary>
    void Update()
    {
        if (_myCharacterController.isGrounded && _myCharacterController.velocity != Vector3.zero)
        {
            _myAnimator.SetInteger("AnimState", 1);
        }
        else if (!_myCharacterController.isGrounded && _myCharacterController.velocity != Vector3.zero)
        {
            _myAnimator.SetInteger("AnimState", 2);
        }
        else 
        {
            _myAnimator.SetInteger("AnimState", 0);
        }
        
    }
}