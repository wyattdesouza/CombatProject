using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MeleeWeapon : MonoBehaviour
{
    private AudioSource audioSource;
    
    public float Force = 100f;
    public float Damage = 50f;
    [SerializeField] private Collider Hitbox;
    public Transform Wielder;
    
    private void Awake()
    {
        //check if wielder is null
        if (Wielder == null)
        {
            Debug.LogError("Wielder is null");
        }
        audioSource = GetComponent<AudioSource>();
        Hitbox.enabled = false;
    }
    
    public void EnableHitBox()
    {
        Hitbox.enabled = true;
    }
    
    public void DisableHitBox()
    {
        Hitbox.enabled = false;
    }

    public void PlayHitSound()
    {
        audioSource.Play();
    }

    public void ProcessHit(HurtBox hurtBox)
    {
        PlayHitSound();
        
        var forceDirection = Calculations.UpAngleForce(Wielder.forward);
        hurtBox.ReceiveHit(Damage, forceDirection * Force);
    }
}