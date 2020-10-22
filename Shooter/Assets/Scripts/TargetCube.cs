using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCube : Target
{
    private bool rotationOn = false;
    private float rotationAmount = 360f;
    private float currentRotationAmount = 0f;
    private Vector3 rotation;
    private float time;

    // Update is called once per frame
    void Update()
    {
        if (rotationOn) {
            if (currentRotationAmount < rotationAmount) {
                time = Time.deltaTime;
                target.transform.Rotate(rotation * time);
                currentRotationAmount += rotationAmount * time;
            } else {
                rotationOn = false;
                target.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    void Rotate (float degrees) {
        if (!rotationOn) {
            rotationOn = true;
            rotationAmount = degrees;
            currentRotationAmount = 0;
            rotation = new Vector3(0, degrees, 0);
        }
    }

    public override void Process(RaycastHit hit) {
        if (gameObject.tag == "Target") {
            Rotate(rotationAmount);
        }

        effectScript.Play(hit, hitSound, hitEffect, effectDuration);
    }
}
