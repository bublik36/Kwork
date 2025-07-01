using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject Joystick;
    public bool canMenu = true;
    private void Awake()
    {
        canMenu = true;
        mainMenuCanvas.SetActive(false); 
    }

    public void MainMenuWindowOn()
    {
        if (canMenu == true)
        {
            if (YG2.envir.isMobile == true)
            {
                Joystick.SetActive(false);
                Fire.SetActive(false);
            }
            Time.timeScale = 0;
            FindObjectOfType<MusicScript>().GetComponent<AudioSource>().mute = true;
            FindObjectOfType<Fire>().CanFire = false;
            mainMenuCanvas.SetActive(true);
        }
    }

    public void MainMenuWindowOff()
    {
        if (canMenu == true)
        {
            if (YG2.envir.isMobile == true && canMenu == true)
            {
                Joystick.SetActive(true);
                Fire.SetActive(true);
            }
            Time.timeScale = 1;
            FindObjectOfType<MusicScript>().GetComponent<AudioSource>().mute = false;
            FindObjectOfType<Fire>().CanFire = true;
            mainMenuCanvas.SetActive(false);
        }
    }

    public void ExitGameOnMainMenu()
    {
        Time.timeScale = 1;
        FindObjectOfType<MusicScript>().GetComponent<AudioSource>().mute = false;
        SceneManager.LoadScene("MainMenu");
    }
}
