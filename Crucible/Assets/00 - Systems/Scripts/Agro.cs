using UnityEngine;

public class Agro : MonoBehaviour
{
    //our enemy class
    //should probably be part of a wider "npc" system
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void NewTargetInSight(Hittable target)
    {
        enemy.AssignNewTarget(target);
    }
}