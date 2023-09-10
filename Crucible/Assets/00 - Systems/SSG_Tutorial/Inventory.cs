using UnityEngine;

public class Inventory : MonoBehaviour
{
    //0 = primary, 1 = secondary, 2 = melee
    [SerializeField] private Weapon[] weapons;
    
    [HideInInspector]
    public Weapon EquippedWeapon;

    private void Start()
    {
        InitVariables();
    }
    
    public void AddItem(Weapon newItem)
    {  
        var newItemIndex = (int)newItem.weaponStyle;
        
        //I'm pretty sure this block is redundant 
        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        
        weapons[newItemIndex] = newItem;
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void InitVariables()
    {
       // weapons = new Weapon[3];
       EquippedWeapon = weapons[0];
    }
}
