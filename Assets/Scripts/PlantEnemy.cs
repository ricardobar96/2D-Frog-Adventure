using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float idleTime;

    private float attackTime = 2;

    public Animator animator;

    public GameObject bullet;

    public Transform shootingPoint;

    private void Start()
    {
        idleTime = attackTime;
    }

    private void Update()
    {
        if(idleTime <= 0) 
        {
            idleTime = attackTime;
            animator.Play("Plant_Attack");
            Invoke("ShootBullet", 0.5f);
        }
        else 
        { 
            idleTime -= Time.deltaTime;
        }
    }

    public void ShootBullet() 
    {
        GameObject newBullet;

        newBullet = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }
}
