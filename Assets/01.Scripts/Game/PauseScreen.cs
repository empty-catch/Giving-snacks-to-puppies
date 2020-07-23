using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0F;
        gameObject.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1F;
        gameObject.SetActive(false);
    }

    public void LoadMain()
    {
        Time.timeScale = 1F;
        SceneManager.LoadScene("00.StartScene");
    }
}
