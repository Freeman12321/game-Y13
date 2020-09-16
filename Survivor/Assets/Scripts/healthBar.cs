using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
    public static healthBar referenceInstance;
    private void Awake() {
        referenceInstance = this;
    }
    public Slider slider; // access the slider component in our health bar 
    public Gradient gradient; // to change the colour of the bar as it goes down
    public Image fill; // store the colour

    public void SetMaxHealth(int health) { 
        slider.maxValue = health; // set our health back to max health
        slider.value = health; // set our slider to then go to the max health
        gradient.Evaluate(1); // set the colour to the max health
    }  

    public void SetCurrentHealth(int health) {
        slider.value = health; // set slider to the health value
        fill.color = gradient.Evaluate(slider.normalizedValue); // set the colour to the correct corresponding health value.
    } // set our health graphic to the players health.
}
