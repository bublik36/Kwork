using System;
using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{ 
    public GameObject bulletPrefab;

    public float fireSpeed;
    [SerializeField]
    Transform SpawnPosition;
    public float reloadTime;
    public bool CanFire = true;



    public void SpawnBullet()
    {
        if (CanFire == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, SpawnPosition.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = -transform.up * fireSpeed * Time.deltaTime;
            StartCoroutine(Relaod());
        }
    }

    private void Update()
    {
        if (Application.isMobilePlatform == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
            {
                if (CanFire == true)
                {
                    SpawnBullet();
                }
            }
        }
    }

    private IEnumerator Relaod()
    {
        CanFire = false;
        yield return new WaitForSeconds(reloadTime);
        CanFire = true;
    }
}
