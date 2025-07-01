using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCollectObj : MonoBehaviour
{
    [SerializeField] private GameObject Spawn;
    [SerializeField] private float SpawnInterval;
    [SerializeField] private Vector2 SpawnIntervalRange;
    [SerializeField] private bool SpawnXdirection;
    [SerializeField] private bool SpawnYdirection;
    [SerializeField] private bool DirectionMoveUp;
    [SerializeField] private bool DirectionMoveDown;
    [SerializeField] private bool DirectionMoveRight;
    [SerializeField] private bool DirectionMoveLeft;
    public float StartSpeed;
    public float EndSpeed;

    private void OnEnable()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void SpawnCollect()
    {       
        SpawnInterval = Random.Range(7, 12);
        if (SpawnXdirection)
        {
            SpawnIntervalRange.y = Random.Range(-4,4);
            SpawnIntervalRange = new Vector2(this.transform.position.x, SpawnIntervalRange.y);
            GameObject SpawnedObj = Instantiate(Spawn, SpawnIntervalRange, Quaternion.identity);
            SpawnedObj.GetComponent<ScrapGo>().speed = Random.Range(StartSpeed, EndSpeed);
            switch (DirectionMoveUp)
            {
                case true: SpawnedObj.GetComponent<ScrapGo>().GoUp = true; break;
            }

            switch (DirectionMoveDown)
            {
                case true: SpawnedObj.GetComponent<ScrapGo>().GoDown = true; break;
            }

            switch (DirectionMoveLeft)
            {
                case true: SpawnedObj.GetComponent<ScrapGo>().GoLeft = true; break;
            }

            switch (DirectionMoveRight)
            {
                case true: SpawnedObj.GetComponent<ScrapGo>().GoRight = true; break;
            }  
        }
        else if (SpawnYdirection)
        {
            SpawnIntervalRange.x = Random.Range(-8,8);
            SpawnIntervalRange = new Vector2(SpawnIntervalRange.x, this.transform.position.y);
            GameObject SpawnedObj = Instantiate(Spawn, SpawnIntervalRange, Quaternion.identity);
            switch (DirectionMoveUp)
            {
                case true: SpawnedObj.GetComponent<ScrapGo>().GoUp = true; break;
            }

            switch (DirectionMoveDown)
            {
                case true: SpawnedObj.GetComponent<ScrapGo>().GoDown = true; break;
            }

            switch (DirectionMoveLeft)
            {
                case true: SpawnedObj.GetComponent<ScrapGo>().GoLeft = true; break;
            }

            switch (DirectionMoveRight)
            {
                case true: SpawnedObj.GetComponent<ScrapGo>().GoRight = true; break;
            }  
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnInterval);
            SpawnCollect();
        }
    }
}
