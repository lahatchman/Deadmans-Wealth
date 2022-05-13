using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Public Variables
    public int health; 
    //Serialized variables
    [SerializeField] protected int damage;
    [SerializeField] protected float speed, attackSpeed, attackRange;
    //Protected variables
    protected GameManager gameManager;
    protected GameObject player;
    protected NavMeshAgent navAgent;
    //Private variables
    private float attackTimer, originalSpeed;
    private bool canAttack;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        originalSpeed = speed;
    }

    protected virtual void Update()
    {
        Attack(attackSpeed, damage);
        if (health <= 0) { Destroy(this.gameObject); }
    }

    protected virtual void Attack(float attackSpeed, int damage)
    {
        if (canAttack)
        {
            speed = 0.0f;
            attackTimer += Time.deltaTime;

            if(attackTimer > attackSpeed)
            {
                gameManager.health -= damage;
                gameManager.SliderUpdate(gameManager.txtHealth, gameManager.sHealth, "Health: ", gameManager.health, "/100");
                attackTimer = 0;
            }
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if(distanceToPlayer > attackRange)
        {
            canAttack = false;
            speed = originalSpeed;
        }
        else { canAttack = true; }
    }

    public void DamageTaken(int playerDamage) { health -= playerDamage; }
}
