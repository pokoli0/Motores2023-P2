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

    [SerializeField]
    private Transform _spawnPoint;

    private Transform _myTransform;
  
    public void Shoot()
    {
        Vector3 _bulletDirection = _spawnPoint.position - _myTransform.position;

        _bulletDirection.y = 0; // Para que no suba/baje

        //Instantiate devuelve el prefab de la bala!
        Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity).
            GetComponent<BulletComponent>().SetDirection(_bulletDirection);
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


    }
}
