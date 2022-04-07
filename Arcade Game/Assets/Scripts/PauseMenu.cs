using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    public GameObject wristUI = null;

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
        SceneManager.LoadScene("Vinson_Menu");
        Debug.Log("Load Menu Level");
    }
    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();
        Debug.Log("Menu Button pressed");

    }



    public void ToggleWristUI()
    {

        if (Input.GetButtonDown("Pause"))
        {
            DisplayWristUI();
            Debug.Log("Menu Button pressed");
        }

    }

    // Update is called once per frame
  public void DisplayWristUI()
    {

        if (wristUI == null)
            return;
        
        if(activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            Debug.Log("WRIST IS FALSE");
        }
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
            Debug.Log("WRIST IS TRUE");
        }

    }

    private void Update()
    {
        ToggleWristUI();
    }
}
