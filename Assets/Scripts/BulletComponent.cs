using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    //esto lo tendra el prefab de la bala!!
    //se encargara del movimiento de la bala, de las colisiones

    [SerializeField]
    private float _bulletSpeed = 2.0f;

    private Transform _myTransform; //transform de la bala 

    private Vector3 _myDirection;

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); //Se rompe la bala.
    }

    public void SetDirection(Vector3 direction)
    {
        _myDirection = direction.normalized;
    }

    public void Movement()
    {
        _myTransform.position += _myDirection * Time.deltaTime * _bulletSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
