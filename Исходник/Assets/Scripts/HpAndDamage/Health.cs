using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth = 100f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float speedSlider;
    [SerializeField] private GameObject deathWindow;
    [SerializeField] private GameObject Joystic;
    [SerializeField] private GameObject FireButton;
    [SerializeField] private GameObject Scrap;
    private void MaxSlider()
    {
        if (this.gameObject.tag == "Player")
        {
            deathWindow.SetActive(false);
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        else
        {
            return;
        }
    }

    private void UpdateSlider()
    {
        if (this.gameObject.tag == "Player")
        {
            healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, speedSlider * Time.deltaTime);
        }
        else
        {
            return;
        }
    }

    private void Update()
    {
        UpdateSlider();
    }

    private void Awake()
    {
        MaxSlider();
        if (currentHealth > maxHealth || maxHealth > currentHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && this.gameObject.tag == "Player")
        {
            GetComponent<Fire>().CanFire = false;
            GetComponent<MoveShip>().CanMove = false;
            FindObjectOfType<MainMenu>().canMenu = false;
            FireButton.SetActive(false);
            Joystic.SetActive(false);
            UpdateSlider();
            deathWindow.SetActive(true);
            FindObjectOfType<MusicScript>().GetComponent<AudioSource>().mute = true;
            StartCoroutine(StopGame());
        }

        if (currentHealth <= 0 && this.gameObject.GetComponent<MoveMeteor>() != null)
        {
        RandomSpawnScrap(); 
        }
        else if (currentHealth <= 0 && this.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator StopGame()
    {
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0f;
    }

    private void RandomSpawnScrap()
    {
        int RandomDrop = Random.Range(0, 4);
            if (this.gameObject.GetComponent<MoveMeteor>().GoUp)
            {
                if (RandomDrop == 0)
                {
                    GameObject scrap = Instantiate(Scrap, transform.position, Quaternion.identity);
                    scrap.GetComponent<ScrapGo>().GoUp = true;
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
            if (this.gameObject.GetComponent<MoveMeteor>().GoDown)
            {
                if (RandomDrop == 0)
                {
                    GameObject scrap = Instantiate(Scrap, transform.position, Quaternion.identity);
                    scrap.GetComponent<ScrapGo>().GoDown = true;
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
            if (this.gameObject.GetComponent<MoveMeteor>().GoLeft)
            {
                if (RandomDrop == 0)
                {
                    GameObject scrap = Instantiate(Scrap, transform.position, Quaternion.identity);
                    scrap.GetComponent<ScrapGo>().GoLeft = true;
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
            if (this.gameObject.GetComponent<MoveMeteor>().GoRight)
            {
                if (RandomDrop == 0)
                {
                    GameObject scrap = Instantiate(Scrap, transform.position, Quaternion.identity);
                    scrap.GetComponent<ScrapGo>().GoRight = true;
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }        
        
    }
}
