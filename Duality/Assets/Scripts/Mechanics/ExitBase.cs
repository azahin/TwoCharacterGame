using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ExitBase : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] protected InputActionReference resetInput;

    private void OnEnable()
    {
        resetInput.action.started += ResetScene;
    }

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

    private void ResetScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }


}
