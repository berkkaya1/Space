using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public EnemyStateManager enemy;
    public Transform bulletspawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private void Start()
    {

        StartCoroutine(Attack());
    }


    IEnumerator Attack()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (enemy.currentState == enemy.enemyAttackState)
            {
                var bullet = Instantiate(bulletPrefab, bulletspawnPoint.position, bulletspawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletspawnPoint.forward * bulletSpeed;
            }
        }

    }

}
