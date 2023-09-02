using System;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField] private Hittable shittyBase;
    public static Hittable ShittyBase;
    public static Hittable EnemyTarget;
    public static event Action<Hittable> OnGlobalEnemyTargetAssigned;
    
    public static List<Enemy> Enemies = new List<Enemy>();

    [SerializeField] private Hittable defaultTarget;

    public void Awake()
    {
        ShittyBase = shittyBase;
        if (defaultTarget)
        {
            NewEnemyTarget(defaultTarget);
        }
    }

    void Start()
    {
        
        Player.Instance.OnDeath += OnPlayerDeath;
    }

    private void NewEnemyTarget(Hittable target)
    {
        EnemyTarget = target;
        OnGlobalEnemyTargetAssigned?.Invoke(EnemyTarget);
    }
    
    private void OnPlayerDeath()
    {
        NewEnemyTarget(null);
    }
    
    
}
