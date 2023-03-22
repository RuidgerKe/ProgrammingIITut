using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHp = 100;
    private int currentHp;
    public int CurrentHp
    {
        get { return currentHp; }
        set { currentHp = value; }

    }

    public int damage;
    public int armor;
    public event System.Action<int, int> OnHealthChange;

    private void Awake()
    {
        currentHp = maxHp;
        StartCoroutine(HealthIncrease());
        //StopCoroutine(HealthIncrease());
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
    public virtual void RestoreHealth(int restore)
    {
        //currentHp += restore;
        //doesnt go above the max health
        currentHp = Mathf.Clamp(currentHp + restore, 0, maxHp);
        Debug.Log(currentHp);
        if (OnHealthChange != null)
        {
            OnHealthChange(maxHp, currentHp);

        }
    }

    IEnumerator HealthIncrease()
    {
        //Debug.Log("Coroutine Started");
        for (int x = 1; x <= maxHp; x++)
        {
            currentHp = x;
            if (OnHealthChange != null)
            {
                OnHealthChange(maxHp, currentHp);

            }
            yield return new WaitForSeconds(0.01f);
            //Debug.Log("HP: " + currentHp + "/" + maxHp);
        
        }
        //Debug.Log("The current health is " + currentHp);
        //Debug.Log("Coroutine Ended");
    }


    public virtual void Die()
    {
        //Debug.Log(transform.name + " died!");
    }

}
