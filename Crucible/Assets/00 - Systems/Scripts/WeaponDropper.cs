using System;
using UnityEngine;

public class WeaponDropper : MonoBehaviour
{
    private Enemy enemy;
    public float weaponDropForce;
    [SerializeField] private DropPairing[] dropPairings;
    
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy.OnDeath += DropWeapon;
    }
    
    private void DropWeapon()
    {
        foreach (var item in dropPairings)
        {
            item.DropItem.transform.position = item.CharacterItem.transform.position;
            item.DropItem.transform.rotation = item.DropItem.transform.rotation;
            
            item.CharacterItem.SetActive(false);
            item.DropItem.SetActive(true);
            
            item.DropItem.transform.SetParent(null);
            item.DropItem.GetComponent<Rigidbody>().AddForce(Vector3.up * weaponDropForce, ForceMode.Impulse);
        }
    }
}

[Serializable]
public struct DropPairing
{
    public GameObject CharacterItem;
    public GameObject DropItem;
}