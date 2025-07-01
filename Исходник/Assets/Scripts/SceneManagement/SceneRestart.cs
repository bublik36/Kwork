using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneRestart : MonoBehaviour
{
    public void RestartScene()
    {
        Time.timeScale = 1;
        FindObjectOfType<MusicScript>().GetComponent<AudioSource>().mute = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void InMenu()
    {
        Time.timeScale = 1;
        FindObjectOfType<MusicScript>().GetComponent<AudioSource>().mute = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void LvlChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
