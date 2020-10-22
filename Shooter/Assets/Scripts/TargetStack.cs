using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStack : Target
{
    // Start is called before the first frame update
    public float impactForce;

    Rigidbody targetRigidbody;
    void Start()
    {
        targetRigidbody = target.GetComponent<Rigidbody>();
    }


    public override void Process(RaycastHit hit)
    {
        targetRigidbody.AddForce(-hit.normal * impactForce);

        effectScript.Play(hit, hitSound, hitEffect, effectDuration);
    }
}
