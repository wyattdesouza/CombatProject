using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//rename this to something more appropriate
public class HitBoxManager : MonoBehaviour
{
    //TODO: clean up how this and hitboxes are organised 
    [FormerlySerializedAs("weapon")] public MeleeWeapon MeleeWeapon;
    //create a list of enemies
    public List<Hittable> hittablesHit = new List<Hittable>();

    private void Start()
    {
        MeleeWeapon = GetComponentInChildren<MeleeWeapon>();
        if (MeleeWeapon == null)
            Debug.LogError("No weapon found on " + gameObject.name);
    }

    public void OnAttackStart()
    {
        hittablesHit.Clear();
        MeleeWeapon.EnableHitBox();
    }
    
    public void OnAttackEnd()
    {
        MeleeWeapon.DisableHitBox();
    }
    
    public void ProcessHit(HurtBox hurtBox)
    {
        var hittable = hurtBox.Hittable;
        if (hittablesHit.Contains(hittable))
            return;
        
        MeleeWeapon.ProcessHit(hurtBox);
        
        hittablesHit.Add(hittable);
    }
}