using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Dev_Prototype"); // Replace with the actual name of your gameplay scene
    }

    public void ExitGame() 
    {
      Debug.Log("Quitting Game...");
      Application.Quit();
    }
}
