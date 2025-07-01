using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnMeteor : MonoBehaviour
{
    private Vector2 spawnPoint;
    [SerializeField] private GameObject[] meteorsPrefab;
    public float reloadTime;
    [SerializeField] private bool DirectionMoveUp;
    [SerializeField] private bool DirectionMoveDown;
    [SerializeField] private bool DirectionMoveRight;
    [SerializeField] private bool DirectionMoveLeft;
    [SerializeField] private bool SpawnYDirection;
    [SerializeField] private bool SpawnXDirection;
    public float speedStart;
    public float speedEnd;
    private void Start()
    {
        InvokeRepeating("SpawnMeteorMeth", reloadTime, reloadTime);
    }

    private void SpawnMeteorMeth()
    {   
        if (SpawnXDirection)
        {
            spawnPoint.y = Random.Range(-4f, 4f);
            Debug.Log(spawnPoint.y);
            spawnPoint = new Vector2(this.transform.position.x, spawnPoint.y);
            GameObject spawnedMeteor = Instantiate(meteorsPrefab[Random.Range(0,meteorsPrefab.Length)], spawnPoint, Quaternion.identity);
            spawnedMeteor.GetComponent<MoveMeteor>().speed = Random.Range(speedStart, speedEnd);
            switch (DirectionMoveUp)
            {
                case true: spawnedMeteor.GetComponent<MoveMeteor>().GoUp = true; break;
            }

            switch (DirectionMoveDown)
            {
                case true: spawnedMeteor.GetComponent<MoveMeteor>().GoDown = true; break;
            }

            switch (DirectionMoveLeft)
            {
                case true: spawnedMeteor.GetComponent<MoveMeteor>().GoLeft = true; break;
            }

            switch (DirectionMoveRight)
            {
                case true: spawnedMeteor.GetComponent<MoveMeteor>().GoRight = true; break;
            }  
        }
        else if (SpawnYDirection)
        {
            spawnPoint.x = Random.Range(-8f, 8f);
            Debug.Log(spawnPoint.y);
            spawnPoint = new Vector2(spawnPoint.x, this.transform.position.y);
            GameObject spawnedMeteor = Instantiate(meteorsPrefab[Random.Range(0,meteorsPrefab.Length)], spawnPoint, Quaternion.identity);
            switch (DirectionMoveUp)
            {
                case true: spawnedMeteor.GetComponent<MoveMeteor>().GoUp = true; break;
            }

            switch (DirectionMoveDown)
            {
                case true: spawnedMeteor.GetComponent<MoveMeteor>().GoDown = true; break;
            }

            switch (DirectionMoveLeft)
            {
                case true: spawnedMeteor.GetComponent<MoveMeteor>().GoLeft = true; break;
            }

            switch (DirectionMoveRight)
            {
                case true: spawnedMeteor.GetComponent<MoveMeteor>().GoRight = true; break;
            }  
        }
    }
}
