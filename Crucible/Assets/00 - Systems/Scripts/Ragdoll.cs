using UnityEngine;
using UnityEngine.AI;

public class Ragdoll : MonoBehaviour
{
    private Collider[] colliders;
    private Collider rootCollider;
    private Enemy enemy;
    
    void Start()
    {
        rootCollider = GetComponent<Collider>();
        colliders = GetComponentsInChildren<Collider>();
        //DisableAllColliders();

        enemy = GetComponent<Enemy>();
        enemy.OnDeath += OnDeath;
    }

    private void DisableAllColliders()
    {
        foreach (var collider in colliders)
        {
            if (collider == rootCollider)
                continue;
            collider.enabled = false;
        }
    }

    private void OnDeath()
    {
        EnableRagdoll();
        GetComponent<Animator>().enabled = false;
    }

    public void EnableRagdoll()
    {
        foreach (var collider in colliders)
            collider.isTrigger = false;
    }
    
    //create a button in editor to call EnableRagdoll
    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdollButton()
    {
        GetComponent<NavMeshAgent>();
        EnableRagdoll();
    }
}
