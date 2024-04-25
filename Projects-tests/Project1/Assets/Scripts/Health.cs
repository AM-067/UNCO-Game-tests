using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] private Slider Slider;

    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }
    
    public void SetHealth(int health)
    {
        Slider.value = health;
    }
}
