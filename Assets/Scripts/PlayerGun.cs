using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerStateManager player;
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
            if (player.currentState == player.playerAttackState)
            {
                var bullet = Instantiate(bulletPrefab, bulletspawnPoint.position, bulletspawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletspawnPoint.forward * bulletSpeed;
            }
        }

    }
}
