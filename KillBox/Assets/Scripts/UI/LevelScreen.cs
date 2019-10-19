using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : MonoBehaviour {

    public Slider healthSlider;
    public Slider damageSlider;
    public float damageDecrement;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDamageBar();
        if (Input.anyKey)
        {
            DamageHealthBar(.25f);

        }
    }


    void DamageHealthBar(float damageVal)
    {
        healthSlider.value -= damageVal;
    }

    void UpdateDamageBar()
    {
        float targetHealthBar = healthSlider.value;
        if (damageSlider.value >= targetHealthBar)
        {
            damageSlider.value -= damageDecrement;
        }
        else if (damageSlider.value < targetHealthBar)
        {
            damageSlider.value = targetHealthBar;
        }
    }
}
