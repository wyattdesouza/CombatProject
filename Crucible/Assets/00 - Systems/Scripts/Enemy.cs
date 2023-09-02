using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : Hittable, IHittable
{
    public float AttackRange = 1;
    public float MoveSpeed = 1;
    public float RotationSpeed = 10;
    
    private AstarAgent astarAgent;

    public Hittable target;
    private Coroutine RotationCoroutine;
    private bool rotatingTowardsTarget;
    private float rotationInterpolator;

    private void Awake()
    {
       // AIManager.OnGlobalEnemyTargetAssigned += OnGlobalEnemyTargetAssigned;
        astarAgent = GetComponent<AstarAgent>();
        astarAgent.StoppingDistance = AttackRange - 0.1f;
    }
    
    private void Start()
    {
        AIManager.Enemies.Add(this);
        target = AIManager.ShittyBase;
    }
    
    private void OnGlobalEnemyTargetAssigned(Hittable obj)
    {
        AssignNewTarget(obj);
    }

    public void AssignNewTarget(Hittable obj)
    {
        target = obj;
    }

    void Update()
    {
        astarAgent.speed = MoveSpeed;
        if (!alive)
            return;

        if (!target)
            LookForTarget();
        
        if (!target.alive && target)
            target = null;
    }

    private void LookForTarget()
    {
        if (AIManager.EnemyTarget)
            OnGlobalEnemyTargetAssigned(AIManager.EnemyTarget);
    }
}