using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDeInicio : MonoBehaviour
{
    //Iniciar el juego
    public void Play()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Exit()
    {
        Application.Quit();

    }
}
