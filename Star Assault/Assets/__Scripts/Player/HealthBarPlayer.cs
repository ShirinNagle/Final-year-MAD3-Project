using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer: MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);//when evaluate is set to 1, colour is all the way to max on health bar
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
//https://www.youtube.com/watch?v=BLfNP4Sc_iA