using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    public GameObject wristUI;

    public bool activeWristUI = true;
    // Start is called before the first frame update
    void Start()
    {
        
        DisplayWristUI();
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Vinson_Test");
        Debug.Log("Load Menu Level");
    }
    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();

    }
    // Update is called once per frame
  public void DisplayWristUI()
    {
        if(activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
        }
        {
            wristUI.SetActive(true);
            activeWristUI = true;
        }

    }
}
