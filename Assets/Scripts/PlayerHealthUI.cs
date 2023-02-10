using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class PlayerHealthUI : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;

    Transform UI;
    Image healthSlider;

    public void Start()
    {
        UI = Instantiate(uiPrefab, target).transform;
        UI.SetParent(target);
        healthSlider = UI.GetChild(0).GetComponent<Image>();
        GetComponent<CharacterStats>().OnHealthChange += OnHealthChanged;


    }

    void OnHealthChanged(int maxHp, int currentHp)
    {
        if (UI != null)
        {
            float healthPercent = (float)currentHp / maxHp;
            healthSlider.fillAmount = healthPercent;
            if (currentHp <= 0 )
            {
                Destroy(UI.gameObject);
            }
        }
    }


}
