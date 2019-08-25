using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        StartCoroutine(PlayGameRoutine());
    }
    IEnumerator PlayGameRoutine() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Home");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
