using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    //mas bien shoot component, lo tendra el player, de donde cogeremos
    //su transform para saber donde spawnear las balas
    //y las spawneara!!

    //las balas se instanciaran cuando reciba el input correspondiente

    [SerializeField]
    private GameObject _bulletPrefab;

    private Transform _myTransform; //el transform del player

    
    public void Shoot()
    {
        Instantiate(_bulletPrefab, _myTransform.position, Quaternion.identity);
        Debug.Log("pium");

    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;

        if (GetComponent<InputManager>() != null)
        {
            GameManager.Instance.Input.RegisterPlayer(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Cuando reciba una posicion, podra spawnear bala


    }
}
