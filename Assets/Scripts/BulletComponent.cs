using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    //esto lo tendra el prefab de la bala!!
    //se encargara del movimiento de la bala, de las colisiones,
    //y de autodestruirse cuando llegue a x punto

    [SerializeField]
    private float _bulletSpeed = 2.0f;

    private Transform _bulletTransform;

    private Vector3 _direction;

    [SerializeField]
    //private Transform _playerT;

    // Start is called before the first frame update
    void Start()
    {
        _bulletTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = FindObjectOfType<CharacterMovement>().getDirection();
        //_direction = _playerT.GetComponent<CharacterMovement>().getDirection();
        //movimientou
        _bulletTransform.Translate(_direction * _bulletSpeed * Time.deltaTime);
    }
}
