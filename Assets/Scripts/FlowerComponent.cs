using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlowerComponent : MonoBehaviour
{
    /// <summary>
    /// Evaluates if colliding object corresponds to player.
    /// If it does, the Flower is released on GameManager and own object is deactivated.
    /// </summary>
    /// <param name="other">Collider of colliding object</param>
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos que el objeto que colisiona con el gameObject que contiene este script
        // tenga un componente CharacterMovement.
        if (other.GetComponent<CharacterMovement>() != null)
        {
            // Llamamos a ReleaseFlower() de la instancia del gameManager,
            // para restar una flor de las que hay en la escena.
            GameManager.Instance.ReleaseFlower();
            // Hacemos que desaparezca la flor.
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// START
    /// Register Flower on GameManager
    /// </summary>
    void Start()
    {
        // Llamamos a RegisterFlower() de la instancia del gameManager,
        // para sumar la flor que contiene este componente al número total
        // de flores de la escena.
        GameManager.Instance.RegisterFlower();
    }
}