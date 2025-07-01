using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private Fire fire;
    [SerializeField] private Collect collect;
    [SerializeField] private GameObject bulletPrefabNew;
    [SerializeField] private MoveShip shipSpeed;
    [SerializeField] private Sprite LvlFirstNewSprite;
    private void Awake()
    {
        
        trailRenderer = GetComponent<TrailRenderer>();
        fire = GetComponent<Fire>();
        collect = GetComponent<Collect>();
        shipSpeed = GetComponent<MoveShip>();
        trailRenderer.enabled = false;
        if (PlayerPrefs.HasKey("LvlFirstBullet"))
        {
            GetComponent<SpriteRenderer>().sprite = LvlFirstNewSprite;
            fire.fireSpeed *= 2;
            fire.reloadTime = 0.7f;
        }

        if (PlayerPrefs.HasKey("LvlSecondBullet") || PlayerPrefs.HasKey("LvlSecondBulletPhone"))
        {
            shipSpeed.speed += 30;
            shipSpeed.speedOnPhone += 30;
            trailRenderer.enabled = true;
        }

        if (PlayerPrefs.HasKey("LvlThirdBullet"))
        {
            fire.bulletPrefab = bulletPrefabNew;
            fire.reloadTime = 0.4f;
        }
    }

    public void LvlFirst()
    {
        GetComponent<SpriteRenderer>().sprite = LvlFirstNewSprite;
        fire.fireSpeed *= 2;
        fire.reloadTime = 0.7f;
        PlayerPrefs.SetFloat("LvlFirstBullet", fire.fireSpeed);
    }

    public void LvlSecond()
    {
        shipSpeed.speed += 30;
        shipSpeed.speedOnPhone += 30;
        trailRenderer.enabled = true;
        PlayerPrefs.SetFloat("LvlSecondBullet", shipSpeed.speed);
        PlayerPrefs.SetFloat("LvlSecondBulletPhone", shipSpeed.speedOnPhone);
    }

    public void LvlThird()
    {
        fire.reloadTime = 0.4f;
        fire.bulletPrefab = bulletPrefabNew;
        PlayerPrefs.SetString("LvlThirdBullet", "Open");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
