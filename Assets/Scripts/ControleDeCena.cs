using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleDeCena : MonoBehaviour
{
    // Método público que pode ser chamado por qualquer botão no Inspector
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
    