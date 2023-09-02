using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    //record the position and rotation of this object
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    
    //local transform variables, rotation and position
    private Vector3 localPosition;
    private Quaternion localRotation;

    private void Awake()
    {
        //record the original position and rotation of this object
        localPosition = transform.localPosition;
        localRotation = transform.localRotation;
    }

    private void OnEnable()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        StartCoroutine(DeactivateAfterTime(0.1f));
    }

    private IEnumerator DeactivateAfterTime(float f)
    {
        yield return new WaitForSeconds(f);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //set position to always be the original position and rotation
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    private void OnDisable()
    {
        //reset the position and rotation of this object
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
    }
}
