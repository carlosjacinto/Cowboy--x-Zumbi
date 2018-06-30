using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public int vidaInicial = 100;
    [HideInInspector]
    public int Vida;
    public float Velocidade = 5;

    void Awake() {
        Vida = vidaInicial;
    }

}
