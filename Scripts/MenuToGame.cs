using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
