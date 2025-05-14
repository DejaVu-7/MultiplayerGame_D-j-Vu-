using UnityEngine;
using System.Collections.Generic;

public class DamageVolume : MonoBehaviour
{
    public float initialDamage = 20f;
    public float damagePerStep = 10f;
    public float damageRate = 5f;
    private float damageTimer = 0f;

    public List<PlayerController> player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageTimer += Time.deltaTime;   
    }


    public void OnTriggerEnter(Collider other)
    {
        
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            Debug.Log(other + "Ha entrado");
            player.Add(pc);
            pc.TakeDamage((int) initialDamage);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log(other + " salio");
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null) 
        { 
          player.Remove(pc);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(damageTimer == damageRate)
        {
            foreach (PlayerController pc in player)
            {
                pc.TakeDamage((int)damagePerStep);

            }
            damageRate = 0;
        }
    }
}
