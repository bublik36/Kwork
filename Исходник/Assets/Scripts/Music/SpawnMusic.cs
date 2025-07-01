using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMusic : MonoBehaviour
{
    [SerializeField] private GameObject musicObj;
    [SerializeField] private MusicScript spawnedMusObj;
    private void Awake()
    {
        spawnedMusObj = FindObjectOfType<MusicScript>();
        if (spawnedMusObj == null)
        {
            Instantiate(musicObj,Vector3.zero,Quaternion.identity);
            spawnedMusObj = FindObjectOfType<MusicScript>();
            DontDestroyOnLoad(spawnedMusObj.gameObject);
        }
        else
        {
            return;
        }
    }
}
