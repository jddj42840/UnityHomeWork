using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlying : MonoBehaviour
{
    public Rigidbody _bullet;
    void Start()
    {
        _bullet = GetComponent<Rigidbody>();
        _bullet.AddForce(transform.forward * 1500);
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
