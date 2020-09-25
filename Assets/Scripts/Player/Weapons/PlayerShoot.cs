using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;

    [SerializeField] float timeBetweenShots = 0.2f;
    float timer = 0;

    [SerializeField] float bulletSpeed = 5f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenShots && Input.GetMouseButtonDown(0) && !Interaction.isCarrying)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);

            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

            Destroy(bullet, 2f);
            timer = 0;
        }
    }
}
