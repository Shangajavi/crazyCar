using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject OpenMenu;
    [SerializeField] private bool isPaused = false;
    [SerializeField] private GameObject Controles;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OpenMenu == true)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Application.Quit();
    }



    public void Reanudar()
    {
        OpenMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;

    }

    public void Pausar()
    {
        OpenMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Inputs()
    {
        StartCoroutine(ControlesS());
    }
    public IEnumerator ControlesS()
    {
        Controles.SetActive(true);
        yield return new WaitForSeconds(5);
        Controles.SetActive(false);
        
    }
}
