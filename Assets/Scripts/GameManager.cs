using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Unique allowed instance of GameManager class, self-assigned on Awake (singleton)
    /// </summary>
    static private GameManager _instance;
    /// <summary>
    /// Public accessor so everyone can access the unique instance of the class without being able to modify it.
    /// </summary>
    static public GameManager Instance
    {
        get { return _instance; }
    }
    /// <summary>
    /// Reference to input manager
    /// </summary>
    private InputManager _input;
    /// <summary>
    /// Public accessor for InputManager so everyone can access it via GameManager without being able to modify it.
    /// </summary>
    public InputManager Input
    {
        get { return _input; }
    }
    /// <summary>
    /// Current number of registered flowers.
    /// </summary>
    private float _nFlowers;
    #endregion
    #region methods
    /// <summary>
    /// Public method to allow flowers registration.
    /// </summary>
    public void RegisterFlower()
    {
        _nFlowers++;
        Debug.Log(_nFlowers);
    }
    /// <summary>
    /// Public method to allow flowers release.
    /// It also needs to check whether all flowers have been released and act consequentlt if it is the case.
    /// </summary>
    public void ReleaseFlower()
    {
        _nFlowers--;
        if (_nFlowers == 0)
        {
            RestartLevel();
        }
        Debug.Log(_nFlowers);
    }
    /// <summary>
    /// In this case, restarting the level means reloading the Game scene.
    /// </summary>
    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// AWAKE
    /// Needs to check if there already is an assigned _instance of GameManager.
    /// If this is the case, it will destroy its own-object, as this proofs it is not the first time 
    /// the scene gets loaded,
    /// and we cannot have two instances of GameManager neither want to have duplicated InputManagers.
    /// Otherwise, _instance is self-assigned and the object set to not be destroyed on load.
    /// </summary>
    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }

        //hay que hacer algo igual con el input
    }
    /// <summary>
    /// START
    /// Needs to assign _input
    /// </summary>
    private void Start()
    {
        _input = GetComponent<InputManager>();
    }
    #endregion
}