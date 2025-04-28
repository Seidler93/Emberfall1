using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    public PlayerMovement playerMovement;
    public ActionCameraController actionCameraController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        playerMovement.canMove = true;
        actionCameraController.canMove = true;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
        playerMovement.canMove = false;
        actionCameraController.canMove = false;
    }

    public void ExitGame() 
    {
        SceneManager.LoadScene("MainMenu"); // Replace with the actual name of your gameplay scene
    }
}
