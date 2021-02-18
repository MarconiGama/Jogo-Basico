using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                       //para edição na forma extena JSON exemplo
public class RoundData                      //classe que não tem herança
{
    public string nomedoTema;               //variável string nomedotema

    public int limitedeTempo;               //variável inteira limitedoTempo

    public int pontosporAcerto;             //variável inteira pontosporAcerto

    public QuestionData[] perguntas;        //vetor do tipo QuestionData n perguntas
}
