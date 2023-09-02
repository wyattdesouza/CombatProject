using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour, IShootable
{
    //damage float
    public float damage = 10f;
    //force float
    public float force = 100f;
    //fire rate float in shots per second
    public float fireRate = 1f;
    public float fireRateTimer = 0;

    private AudioSource audioSource;
    private Animator animator;
    private MuzzleFlash muzzleFlash;
    [SerializeField]
    private Transform muzzleTip;

    public int ammoInClip = 0;
    public int clipSize = 6;

    public event Action<Vector3, Vector3> OnShoot;
    //not used
    public event Action<Vector3, Vector3> OnShootAtTarget;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        muzzleFlash = GetComponentInChildren<MuzzleFlash>();
        muzzleFlash.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        fireRateTimer -= Time.deltaTime;
        AttackLoop();
    }
    
    void AttackLoop()
    {
        var mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            if (fireRateTimer <= 0)
            {
                fireRateTimer = fireRate;
                Shoot();
            }
        }
    }
    
    //function to fire using a raycast
    public void Shoot()
    {
        animator.SetTrigger("Shoot");
        audioSource.Play();
        StartCoroutine(ShowMuzzleFlash());
        
        //raycast
        RaycastHit hit;
        //if raycast hits something
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //get the target
            var target = hit.transform.GetComponent<HurtBox>();
            //if target is not null
            if (target != null)
            {
                //deal damage to target
                target.Hittable.ReceiveHit(damage, transform.forward * force, hit.point);
            }
            OnShootAtTarget?.Invoke(muzzleTip.position, hit.point);
        }
        else
        {
            OnShoot?.Invoke(muzzleTip.position, muzzleTip.forward);
        }
    }

    private IEnumerator ShowMuzzleFlash()
    {
        muzzleFlash.gameObject.SetActive(true);
        //wait for 0.1 seconds then deactivate game object
        yield return null;
        yield return null;
        muzzleFlash.gameObject.SetActive(false);
    }

    public void Reload(int newAmmo)
    {
        //play animation
        //after animation... add ammo
    }
}
