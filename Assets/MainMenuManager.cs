#if Unity_Editor
using UnityEngine;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene("Opening Cutscene");

    public void QuitGame()
    {
        Application.Quit();
    }
}
