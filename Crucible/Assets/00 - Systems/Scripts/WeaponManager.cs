using System;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int PistolAmmoMax;
    public int PistolAmmo;

    public Gun EquippedGun;

    private void Awake()
    {
        EquippedGun = GetComponentInChildren<Gun>();
    }

    public void Update()
    {
        //input for reload
        if (Input.GetKeyDown(KeyCode.R))
        {
       //     EquippedGun.Reload();
        }
        
    }
}
