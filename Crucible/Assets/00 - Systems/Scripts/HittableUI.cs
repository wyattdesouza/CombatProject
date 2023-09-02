using UnityEngine;

public class HittableUI : MonoBehaviour
{
     private Hittable hittable;

     private void Awake()
     {
          hittable = GetComponentInParent<Hittable>();
          hittable.OnDeath += OnDeath;
     }

     private void OnDeath()
     {
          gameObject.SetActive(false);
     }
}
