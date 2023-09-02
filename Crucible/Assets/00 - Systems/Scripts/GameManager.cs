using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Hittable Base;

    public GameObject DefeatScreen;

    public void Awake()
    {
        Base.OnDeath += OnBaseDeath;
    }
    
    private void OnBaseDeath()
    {
        Debug.Log("Base is dead");
        DefeatScreen.SetActive(true);
    }
}