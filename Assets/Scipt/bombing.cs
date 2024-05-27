using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombing : MonoBehaviour
{
    public float exposionRadius = 10;
    public int expsionTime = 3;
    public int expsionHurtNum = 20;


    SphereCollider BombColider;

    public GameObject ExposionFx;

    void Start()
    {
        Invoke("BombExposion", expsionTime);
        BombColider = GetComponent<SphereCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BombExposion()
    {

        Instantiate(ExposionFx);
        for(float r=0.001f; r<=exposionRadius; r += 0.2f)
        {
            BombColider.radius=r;

        }
    }
}
