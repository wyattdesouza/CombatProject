using UnityEngine;

public class HitBox : MonoBehaviour
{
    private HitBoxManager hitBoxManager;
    
    void Start()
    {
        hitBoxManager = GetComponentInParent<HitBoxManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var hurtBox = other.GetComponent<HurtBox>();
        
        if (hurtBox)
            hitBoxManager.ProcessHit(hurtBox);
    }
}
