using System;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hittable : MonoBehaviour
{
    //requires hurtboxes which require trigger colldiers?

    public float MaxHealth = 100;
    public float Health;

    public bool Invincible;
    
    public delegate void Death();
    public event Death OnDeath;
    
    public bool alive = true;
    
    int lastPlayedHitSound = - 1;
    public AudioClip[] HitSounds;

    [SerializeField] private GameObject bloodParticles;

    [SerializeField]
    private float heightOfCentreOfMass = 1.0f;

    public Vector3 CentreOfMass => transform.position + Vector3.up * heightOfCentreOfMass;


    void OnValidate()
    {
        //when a value changes
    }
        

    private void Awake()
    {
        Health = MaxHealth;
        DoAwake();
    }
    protected virtual void DoAwake() { }

    void Update()
    {
        if (!alive)
            return;
        //basically just for debug editor here
        if (Health <= 0)
            Die();
    }
    
    public void ReceiveHit(float damage, Vector3 force)
    {
        TakeDamage(damage);
    }
    
    public void ReceiveHit(float damage, Vector3 force, Vector3 hitPoint)
    {
        if(!alive)
            return;
        TakeDamage(damage);
        SpawnHitParticles(hitPoint);
    }

    private void TakeDamage(float damage)
    {
        Health -= damage;
        PlayHitSound();
        if (Health <= 0)
            Die();
    }

    void SpawnHitParticles(Vector3 hitPoint)
    {
        //get the rotation going from the transform.position to the hit point but only around the y axis
        var hitRefPos = new Vector3(transform.position.x, hitPoint.y, transform.position.z);
        var rotation = Quaternion.LookRotation(hitPoint - hitRefPos);
        Instantiate(bloodParticles, hitPoint, rotation);
    }
    
    public virtual void Die()
    {
        alive = false;
        OnDeath?.Invoke();
    }
    
    private void PlayHitSound()
    {
        //check if there are any sounds in the array
        if (HitSounds.Length == 0)
        {
            Debug.Log("No hit sounds assigned");
            return;
        }
        //pick a random hitsound out of the hit sounds array that wasn't the last played and play it
        var randomIndex = Random.Range(0, HitSounds.Length);
        
        //If we have more than one track, make sure we don't loop the same one twice
        if (HitSounds.Length > 1)
        {
            while (randomIndex == lastPlayedHitSound)
            {
                randomIndex = Random.Range(0, HitSounds.Length);
            }
        }
        
        lastPlayedHitSound = randomIndex;
        SoundManager.instance.PlaySoundEffect(HitSounds[randomIndex], transform.position);
    }
}
