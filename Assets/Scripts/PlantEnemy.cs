using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float idleTime;

    private float attackTime = 3;

    private Animator animator;

    public GameObject bullet;

    public Transform shootingPoint;
}
