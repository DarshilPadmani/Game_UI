using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float TotalHealth = 100f;
    public float CurrentHealth ;
    public Slider PlayerHealth;

    public bool IsTakingDamage=false;
    public bool IsHealing=false;
    public float healingTime = 5f;
    public float remainingHealingTime ;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth=TotalHealth;
        remainingHealingTime = healingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I)) {
            DamagePlayer(25f);
        }
        if (IsTakingDamage)
        {
            TakingDamage();
        }
        if(IsHealing)
        {
            StartHealing();
        }
    }

    public void DamagePlayer(float Damage)
    {
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            return;
        }
        else if (CurrentHealth>TotalHealth)
        {
            CurrentHealth =TotalHealth;
        }
        else
        {
            CurrentHealth -= Damage;
            remainingHealingTime = healingTime;
            IsTakingDamage = true;
            IsHealing = false;
        }
        PlayerHealth.value = CurrentHealth/100;
    }
    public void TakingDamage()
    {
         remainingHealingTime -= Time.deltaTime;
        if(remainingHealingTime <= 0)
        {
            IsTakingDamage=false;
            IsHealing = true;
        }
    }
    public void StartHealing()
    {
        CurrentHealth += Time.deltaTime*2;
        PlayerHealth.value = CurrentHealth / 100;
        if (CurrentHealth >100 ) {
            CurrentHealth = 100; 
            IsHealing=false;
        }
    }
}
