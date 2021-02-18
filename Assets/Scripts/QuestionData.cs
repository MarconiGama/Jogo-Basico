using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                   //para edição na forma extena JSON exemplo
public class QuestionData               //classe que não tem herança
{
    public string textodaPergunta;      //variável do tipo string textodaPergunta
    public AnswerData[] respostas;      //utilizando AnswerData como vetor n respostas
}
