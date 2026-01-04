using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private string scene;

    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Debug.Log("Quit Gracefully");
        Application.Quit();
    }
    
}
