using System;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    //On Hittable enter
    //pass to Agro system
    private Agro agroSystem;

    private void Awake()
    {
        agroSystem = GetComponentInParent<Agro>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<Hittable>();
        agroSystem.NewTargetInSight(target);
    }
}