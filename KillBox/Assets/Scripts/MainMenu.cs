using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Animator playButton;
    public Animator creditsButton;
    public Animator quitButton;

    public Animator creditsText;
    public Animator backButton;

    public Animator title;

	void Start()
    {
        StartCoroutine("TitleScreen");
    }

    public IEnumerator TitleScreen()
    {
        title.SetBool("IsOpen", true);
        title.SetBool("IsMoving", false);
        creditsText.SetBool("IsOpen", false);
        backButton.SetBool("IsOpen", false);
        yield return new WaitForSeconds(1f);
        title.SetBool("IsOpen", false);
        yield return new WaitForSeconds(1f);
        playButton.SetBool("IsOpen", true);
        creditsButton.SetBool("IsOpen", true);
        quitButton.SetBool("IsOpen", true);
    }

    public void Play()
    {
        //SceneManager.LoadScene();
    }

    public void Credits()
    {
        playButton.SetBool("IsOpen", false);
        creditsButton.SetBool("IsOpen", false);
        quitButton.SetBool("IsOpen", false);
        creditsText.SetBool("IsOpen", true);
        backButton.SetBool("IsOpen", true);
        title.SetBool("IsMoving", true);
    }

    public void Back()
    {
        StartCoroutine("TitleScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
