using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaMenu : MonoBehaviour {

	
	public void JogarJogo()
    {
        PlayerPrefs.SetInt("FaseAtual", 1);
        SceneManager.LoadScene("Fase1");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
