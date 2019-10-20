using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool deathScreenActive = false;

    void Start()
    {
         gameObject.SetActive(false);
    }
    // Update is called once per frame
    public void ToggleDeathMenu()
    {
        
        gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().ResetFOV();
        Debug.Log("Toggled Death menu");
        deathScreenActive = true;

    }
    public void Restart()
    {
        
        deathScreenActive = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public bool IsDeathMenuActive()
    {
        return deathScreenActive;
    }
}