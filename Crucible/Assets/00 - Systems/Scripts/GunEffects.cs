using UnityEngine;

public class GunEffects : MonoBehaviour
{
    public TracerRound tracerPrefab;

    private void Awake()
    {
        var shootables = GetComponents<IShootable>();
        foreach (var shootable in shootables)
        {
            shootable.OnShoot += ShootTracerRound;
            shootable.OnShootAtTarget += ShootTracerRoundAtTarget;
        }
    }

    //currently just setup to a target, so not a skill shot
    public void ShootTracerRoundAtTarget(Vector3 origin, Vector3 target)
    {
        var tracer = Instantiate(tracerPrefab, origin, Quaternion.identity);
        //set the direction of the tracer to be the direction between the origin and the target
        tracer.transform.forward = (target - origin).normalized;
        tracer.LoadTarget(target);
    }

    public void ShootTracerRound(Vector3 origin, Vector3 direction)
    {
        var tracer = Instantiate(tracerPrefab, origin, Quaternion.identity);
        tracer.transform.forward = direction;
    }
}