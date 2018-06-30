using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseAtual : MonoBehaviour {

    private static int atual = 1;

    public int getAtual(){
        atual++;
        return atual;
    }
}
