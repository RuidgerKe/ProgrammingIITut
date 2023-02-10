using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;

    public int damage;
    public int armor;
    public event System.Action<int, int> OnHealthChange;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHp -= damage;
        if (OnHealthChange != null)
        {
            OnHealthChange(maxHp, currentHp);

        }
        if (currentHp <= 0)
        {
            Die();
        }

    }
    public virtual void Die()
    {
        Debug.Log(transform.name + " died!");
    }

}
