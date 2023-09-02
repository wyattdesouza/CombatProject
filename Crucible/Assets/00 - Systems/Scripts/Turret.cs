using System;
using UnityEngine;

[RequireComponent(typeof(GunEffects))]
public class Turret : MonoBehaviour, IShootable
{
    [SerializeField] private float damage = 10;
    [SerializeField] private float fireRate = 1;
//    [SerializeField] private AudioClip FireSound;
    //we can probably create a separate muzzle flash system tbh...
    [SerializeField] private GameObject MuzzleFlash;

    [SerializeField] private Animation[] barrelAnimations;
    [SerializeField] private Transform[] muzzleSpawns;
    
    public Hittable target;
    public Transform TurretHead;

    private Animator animator;
    private AudioSource audioSource;
    
    private Coroutine fireLoop;

    private GunEffects gunEffects;
    
    private float shootTimer;

    //not used
    public event Action<Vector3, Vector3> OnShoot;
    public event Action<Vector3, Vector3> OnShootAtTarget;
    
    private void Start()
    {
        gunEffects = GetComponent<GunEffects>();
        audioSource = GetComponent<AudioSource>();
    }

    //TODO: this basically has a max firerate of once per frame? not good
    void Update()
    {
        if (!target || !target.alive)
        {
            if(fireLoop != null)
                StopCoroutine(fireLoop);
            target = FindTarget();
        }
        
        if (target)
            TrackTarget();

        ShootLoop();
    }

    private void ShootLoop()
    {
        shootTimer -= Time.deltaTime;
        if(target && shootTimer <= 0)
        {
            shootTimer = fireRate;
            Shoot();
        }
    }
    
    private void Shoot()
    {
        SoundManager.instance.PlaySoundEffect(audioSource.clip, transform.position);
        target.ReceiveHit(damage, Vector3.zero);
        var barrelOrigin = AnimateDoubleBarrelTurretShot();
        OnShootAtTarget?.Invoke(barrelOrigin, target.CentreOfMass);
    }

    private void TrackTarget()
    {
        TurretHead.LookAt(target.CentreOfMass);
    }

    private Hittable FindTarget()
    {
        Enemy newTarget = null;
        float distance = Mathf.Infinity;
        
        foreach (var enemy in AIManager.Enemies)
        {
            var enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(enemyDistance < distance)
            {
                newTarget = enemy;
                distance = enemyDistance;
            }
        }
        return newTarget;
    }


    private int lastBarrelShot;
    /// <returns>barrel origin</returns>
    private Vector3 AnimateDoubleBarrelTurretShot()
    {
        if(lastBarrelShot >= barrelAnimations.Length)
            lastBarrelShot = 0;
        
        barrelAnimations[lastBarrelShot].Play();
        var muzzlePoint = muzzleSpawns[lastBarrelShot];
        Instantiate(MuzzleFlash, muzzlePoint.position, muzzlePoint.rotation);
        lastBarrelShot++;
        return muzzlePoint.position;
        //muzzle flash
        //spawn muzzle flash
    }
    
    //register enemy to AIManager

    //find closes enemy
    //fire at enemy until dead
    //repeat
    
    //muzzle flash and audiosource should have some kind of pooling system....
}