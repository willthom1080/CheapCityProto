#if Unity_Editor
using UnityEngine;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene("Level 1");

    public void QuitGame()
    {
        Application.Quit();
    }
}
