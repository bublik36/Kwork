using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Collect : MonoBehaviour
{
    [SerializeField] private GameObject Collected;
    public int CollectedNext;
    public int CollectedCount;
    public Text CollectedText;
    [SerializeField] private BuffSystem BuffSystem;
    private int NextLevel = 0;
    public BuffSystem Buff;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        Buff = GetComponent<BuffSystem>();
        CollectedCount = PlayerPrefs.GetInt("CollectedItem");
        if (PlayerPrefs.HasKey("SaveCollectedNext"))
        {
            CollectedNext = PlayerPrefs.GetInt("SaveCollectedNext");
        }
    }

    private void Start()
    {
        CollectedText.text = CollectedCount.ToString() + "/" + CollectedNext.ToString();
        Debug.Log(NextLevel);
        if (PlayerPrefs.HasKey("SaveCollectedNext") && PlayerPrefs.GetInt("SaveCollectedNext") >= 25)
        {
            if (FindObjectOfType<LanguageObject>().Russia == true)
            {
                CollectedText.text = "Макс.";
            }
            else if (FindObjectOfType<LanguageObject>().English == true)
            {
                CollectedText.text = "Max.";
            }
        }
    }

    private void CollectItemMax()
    {
        if (CollectedCount >= CollectedNext && PlayerPrefs.HasKey("LvlFirstBullet") == false)
        {
            Buff.LvlFirst();
            CollectedCount = 0;
            CollectedNext = 15;
            PlayerPrefs.SetInt("SaveCollectedNext", CollectedNext);
            PlayerPrefs.SetInt("CollectedItem", CollectedCount);
            CollectedText.text = CollectedCount.ToString() + "/" + CollectedNext;
        }
        else if (CollectedCount >= CollectedNext && PlayerPrefs.HasKey("LvlFirstBullet") == true &&
                 PlayerPrefs.HasKey("LvlSecondBullet") == false && PlayerPrefs.HasKey("LvlSecondBulletPhone") == false)
        {
            Buff.LvlSecond();
            CollectedCount = 0;
            CollectedNext = 20;
            PlayerPrefs.SetInt("SaveCollectedNext", CollectedNext);
            PlayerPrefs.SetInt("CollectedItem", CollectedCount);
            CollectedText.text = CollectedCount.ToString() + "/" + CollectedNext;
        }
        else if(CollectedCount >= CollectedNext && PlayerPrefs.HasKey("LvlThirdBullet") == false &&
        PlayerPrefs.HasKey("LvlSecondBullet") == true && PlayerPrefs.HasKey("LvlSecondBulletPhone") == true)
        {
            Buff.LvlThird();
            CollectedCount = 0;
            CollectedNext = 25;
            PlayerPrefs.SetInt("SaveCollectedNext", CollectedNext);
            PlayerPrefs.SetInt("CollectedItem", CollectedCount);
            if (FindObjectOfType<LanguageObject>().Russia == true)
            {
                CollectedText.text = "Макс.";
            }
            else if (FindObjectOfType<LanguageObject>().English == true)
            {
                CollectedText.text = "Max.";
            }
        }
        else if (CollectedCount >= CollectedNext && PlayerPrefs.HasKey("LvlThirdBullet") == true &&
                 PlayerPrefs.HasKey("LvlSecondBullet") == true && PlayerPrefs.HasKey("LvlSecondBulletPhone") == true)
        {

        }
        
    }

    private void CollectItem()
    {
        CollectedCount++;
        PlayerPrefs.SetInt("CollectedItem", CollectedCount);
        Debug.Log("Save");
        CollectedText.text = CollectedCount.ToString() + "/" + CollectedNext;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ScrapGo>() != null && CollectedCount < CollectedNext && PlayerPrefs.GetInt("SaveCollectedNext") < 25)
        {
            CollectItem();
            CollectItemMax();
            Destroy(other.gameObject);
        }
        else if (PlayerPrefs.HasKey("SaveCollectedNext") && PlayerPrefs.GetInt("SaveCollectedNext") >= 25)
        {
            if (other.gameObject.GetComponent<ScrapGo>() != null && CollectedCount < CollectedNext)
            {
                Destroy(other.gameObject);
            }
        }
        else
        {
            return;
        }
    }
}
