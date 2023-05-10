using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuttey : MonoBehaviour
{

    public Transform target;

    public Vector3 EAsports;

    public string enemyTag;

    public float Pokemon;

    public Transform partToRotate;

    public float turnSpeed;

    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        Pokemon = EAsports.x;
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Pokemon) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }

    }

    void Update() {
        if (target == null) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);
        
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, EAsports);
    }
}
