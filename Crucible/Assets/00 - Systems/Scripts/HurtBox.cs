using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [HideInInspector] public Enemy Self;
    
    public Hittable Hittable;
    private Rigidbody rigidbody;
    
    void Start()
    {
        Hittable = GetComponentInParent<Hittable>();
        //rigidbody = GetComponent<Rigidbody>();
    }
    
    //create a button in the inspector
    [ContextMenu("test force")]
    public void TestForce()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 50, ForceMode.Impulse);
    }

    public void ReceiveHit(float damage, Vector3 force)
    {
        Hittable.
            ReceiveHit(damage, force);

        if(force != Vector3.zero)
            ApplyKnockback(force);
    }    
    
    private void ApplyKnockback(Vector3 knockback)
    {
      //  rigidbody.AddForce(knockback, ForceMode.Impulse);
    }
}   
