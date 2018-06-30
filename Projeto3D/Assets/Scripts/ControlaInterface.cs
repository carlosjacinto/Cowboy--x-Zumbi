using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour {

    private ControlaJogador scriptControlaJogador;
    public Slider SliderVidaJogador;
    public GameObject PainelDeGameOver;
    public Text TextoTempoDeSobrevivencia;
    public Text TextoPontuacaoMaxima;
    private float tempoPontuacaoSalva;
    private int quantidadeDeZumbisMortos;
    public Text TextoQuantidadeZumbisMortos;
    public int QuantidadePassarFase;
    public int fase;

    void Start () {
        fase =  PlayerPrefs.GetInt("FaseAtual");
        QuantidadePassarFase = 20;
        scriptControlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptControlaJogador.statusJogador.Vida;
        AtualizaSliderVidaJogador();
        Time.timeScale = 1;
        tempoPontuacaoSalva = PlayerPrefs.GetFloat("PontuacaoMaxima");
        quantidadeDeZumbisMortos = 0;
    }

    public void AtualizaSliderVidaJogador() {
        SliderVidaJogador.value = scriptControlaJogador.statusJogador.Vida;
    }

    public void AtualizarQuantidadeDeZumbisMortos() {
        quantidadeDeZumbisMortos++;
        TextoQuantidadeZumbisMortos.text = string.Format("x {0}",quantidadeDeZumbisMortos);
        if (quantidadeDeZumbisMortos == QuantidadePassarFase && fase!=5) {
            passarDeFase();
        }
       
    }

    public void Gameover() {
        PainelDeGameOver.SetActive(true);
        Time.timeScale = 0;
        int minutos = (int) (Time.timeSinceLevelLoad / 60);
        int segundos = (int)(Time.timeSinceLevelLoad % 60);
        TextoTempoDeSobrevivencia.text = "Você sobreviveu por "+minutos+"min e "+segundos+"s";
        AjustarPontuacaoMaxima(minutos, segundos);
    }

    void passarDeFase() {
        fase = fase + 1;
        PlayerPrefs.SetInt("FaseAtual", fase);
        SceneManager.LoadScene("Fase"+(fase));
    }

    public void Reiniciar() {
        SceneManager.LoadScene("menu");
    }

    void AjustarPontuacaoMaxima(int minutos, int segundos) {

        if(tempoPontuacaoSalva < Time.timeSinceLevelLoad)  {
            tempoPontuacaoSalva = Time.timeSinceLevelLoad;
            PlayerPrefs.SetFloat("PontuacaoMaxima",tempoPontuacaoSalva);
        }else{
            minutos = (int)(tempoPontuacaoSalva / 60);
            segundos = (int)(tempoPontuacaoSalva % 60);
        }

        TextoPontuacaoMaxima.text = string.Format("Seu melhor tempo é  {0}min e {1}s", minutos, segundos);
    }
}
