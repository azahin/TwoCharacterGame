using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBase : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }


}
