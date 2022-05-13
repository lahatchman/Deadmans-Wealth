using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private Image crosshair;

    void Update()
    {
        CrossHairColourChange();
        if (Input.GetMouseButtonDown(0)) { PlayerAttack(); }
    }

    void PlayerAttack()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Enemy>() != null)
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    enemy.DamageTaken(attackDamage);
                }
            }
        }
    }

    void CrossHairColourChange()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<Enemy>() != null) { crosshair.color = new Color32(255, 0, 0, 255); }
            }
        }
        else { crosshair.color = new Color32(255, 255, 255, 255); }
    }
}
