using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    public Image energySlider;
    public TextMeshProUGUI textEnergy;
    private int energy;
    public int Energy
    {
        set
        {
            energy = value;
            UpdateText();
        }
        get
        {
            return energy;
        }
    }
    public int maxEnergy;
    public int initialEnergy;

    void Start()
    {
        Energy = initialEnergy;
    }

    void UpdateText()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, TweenEnergy, energySlider.fillAmount, (float)energy / maxEnergy, 0.2f).setEaseOutCirc();
        textEnergy.text = energy.ToString();
    }

    void TweenEnergy(float energy)
    {
        energySlider.fillAmount = energy;
    }
}
