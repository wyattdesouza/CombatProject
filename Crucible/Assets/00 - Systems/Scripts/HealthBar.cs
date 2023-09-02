using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private Hittable hittable;    
    
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = hittable.Health / hittable.MaxHealth;
    }
}
