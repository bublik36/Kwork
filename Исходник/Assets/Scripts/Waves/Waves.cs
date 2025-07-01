using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using YG;
public class Waves : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnersScrap;
    [SerializeField] private GameObject[] SpawnersMeteor;
    [SerializeField] private float nextScrapTime;
    private GameObject currentScrap;
    private GameObject currentMeteor;
    private bool CanSpawnWaves = true;
    private bool CanSpawnMeteors = true;
    [SerializeField] private Transform[] randomSpawnPoints;
    [SerializeField] private GameObject newWavesText;
    [SerializeField] private GameObject newWavesTextNext;
    private int randomScrap;
    private int randomMeteor;
    public float timePassed;
    private int EasyWaves = 0;
    private int MediumWaves = 0;
    private int HardWaves = 0;
    [SerializeField] private int AddShower;
    [SerializeField] private GameObject Add;
    private bool AdShow = false;
    private void Awake()
    {   
        Add.SetActive(false);
        timePassed = nextScrapTime;
        newWavesText.SetActive(false);
    }
    private void Update()
    {
        if (AddShower >= 1 && timePassed <= 0 && AdShow == false)
        {
            Debug.Log(AddShower.ToString());
            Debug.Log("ShowAdd");
            StartCoroutine(AddShow());
        }
        if (timePassed > 0 && AddShower <= 1 && AdShow == false)
        {
            timePassed -= Time.deltaTime;
            SpawnEzWaves();
            newWavesTextNext.gameObject.SetActive(true);
            TextLoc("след.волна:","next wave:",newWavesTextNext);
            newWavesTextNext.gameObject.GetComponent<Text>().text = newWavesTextNext.gameObject.GetComponent<Text>().text + timePassed.ToString("0.00");
        }
        else
        {
            timePassed = nextScrapTime;
        }
        
    }

    public void SpawnEzWaves()
    {
        if (CanSpawnWaves)
        {
            if (EasyWaves < 2)
            {
                randomScrap = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                Debug.Log(randomScrap);
                randomMeteor = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                Debug.Log(randomMeteor);
                if (randomScrap == randomMeteor)
                {
                    randomScrap = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                }
                else if (randomScrap != randomMeteor)
                {
                    EasyWaves++;
                    CanSpawnWaves = false;
                    currentMeteor = Instantiate(SpawnersMeteor[randomMeteor], randomSpawnPoints[randomMeteor].position,
                        Quaternion.identity);
                    currentScrap = Instantiate(SpawnersScrap[randomScrap], randomSpawnPoints[randomScrap].position,
                        Quaternion.identity);
                    StartCoroutine(NextWave());
                }
            }
            else if (EasyWaves >= 2 && MediumWaves < 4)
            {
                Debug.Log("MediumWaves");
                randomScrap = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                Debug.Log(randomScrap);
                randomMeteor = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                Debug.Log(randomMeteor);
                if (randomScrap == randomMeteor)
                {
                    randomScrap = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                }
                else if (randomScrap != randomMeteor)
                {
                    CanSpawnWaves = false;
                    MediumWaves++;
                    currentMeteor = Instantiate(SpawnersMeteor[randomMeteor], randomSpawnPoints[randomMeteor].position,
                        Quaternion.identity);
                    currentMeteor.GetComponent<SpawnMeteor>().speedStart += 20;
                    currentMeteor.GetComponent<SpawnMeteor>().speedEnd += 20;
                    currentMeteor.GetComponent<SpawnMeteor>().reloadTime = 3;
                    currentScrap = Instantiate(SpawnersScrap[randomScrap], randomSpawnPoints[randomScrap].position,
                        Quaternion.identity);
                    currentScrap.GetComponent<SpawnCollectObj>().StartSpeed += 20;
                    currentScrap.GetComponent<SpawnCollectObj>().EndSpeed += 20;
                    StartCoroutine(NextWave());
                }
            }
            else if (MediumWaves >= 4)
            {
                Debug.Log("MediumWaves");
                randomScrap = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                Debug.Log(randomScrap);
                randomMeteor = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                Debug.Log(randomMeteor);
                if (randomScrap == randomMeteor)
                {
                    randomScrap = UnityEngine.Random.Range(0, randomSpawnPoints.Length);
                }
                else if (randomScrap != randomMeteor)
                {
                    CanSpawnWaves = false;
                    currentMeteor = Instantiate(SpawnersMeteor[randomMeteor], randomSpawnPoints[randomMeteor].position,
                        Quaternion.identity);
                    currentMeteor.GetComponent<SpawnMeteor>().speedStart += 40;
                    currentMeteor.GetComponent<SpawnMeteor>().speedEnd += 40;
                    currentMeteor.GetComponent<SpawnMeteor>().reloadTime = 2;
                    currentScrap = Instantiate(SpawnersScrap[randomScrap], randomSpawnPoints[randomScrap].position,
                        Quaternion.identity);
                    currentScrap.GetComponent<SpawnCollectObj>().StartSpeed += 40;
                    currentScrap.GetComponent<SpawnCollectObj>().EndSpeed += 40;
                    StartCoroutine(NextWave());
                }
            }
        }
    }

    private void CleanMeth()
    {
        AddShower++;
        newWavesText.SetActive(true);
        GameObject[] Clean = GameObject.FindGameObjectsWithTag("Clean");
        foreach (GameObject DestroyObj in Clean)
        {
            Destroy(DestroyObj);
        }
        Destroy(currentScrap);
        Destroy(currentMeteor);
        CanSpawnWaves = true;
    }
    private void TextLoc(string textRussian,string English,GameObject TextObj)
    {
        if (FindObjectOfType<LanguageObject>().Russia == true)
        {
            TextObj.GetComponent<Text>().text = textRussian;

        }
        else if (FindObjectOfType<LanguageObject>().English == true)
        {
            TextObj.GetComponent<Text>().text = English;
        }
    }
    private void beforeAd()
    {
        AddShower = 0;
        AdShow = true;
        FindObjectOfType<MainMenu>().canMenu = false;
        TextLoc("след.волна:","next wave:",newWavesTextNext);
        newWavesTextNext.GetComponent<Text>().text = newWavesTextNext.gameObject.GetComponent<Text>().text + nextScrapTime.ToString("0.00");

        FindObjectOfType<MoveShip>().CanMove = false;
        FindObjectOfType<Fire>().CanFire = false;
        Add.SetActive(true);
        TextLoc("Показ рекламы через: 2 секунды","The ad will be displayed after: 2 seconds",Add);
    }
    private void AfterAd()
    {
        FindObjectOfType<MoveShip>().CanMove = true;
        FindObjectOfType<MainMenu>().canMenu = true;
        StartCoroutine(CanFire());
        AddShower = 0;
        Add.SetActive(false);
        AdShow = false;
        timePassed = nextScrapTime;
    }
    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(nextScrapTime);
        CleanMeth();
    }
    private IEnumerator AddShow()
    {
        beforeAd();
        yield return new WaitForSeconds(2f);
        YG2.InterstitialAdvShow();
        AfterAd();
    }
    private IEnumerator CanFire()
    {
        yield return new WaitForSeconds(FindObjectOfType<Fire>().reloadTime);
        FindObjectOfType<Fire>().CanFire = true;
    }




}
