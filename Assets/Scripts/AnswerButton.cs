using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    //declaração de variável do tipo Text
    public Text textoDaResposta;

    //declaração de variável do tipo AnswerData
    private AnswerData answerData;

    //referência  classe GameControle
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //função com parametro de AnswerData
    public void Setup(AnswerData data)
    {
        answerData = data;
        textoDaResposta.text = answerData.textoResposta; 
    }

    //função para o botão de resposta quando for clicado, faz análise das alternativas
    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.certo);
    }
   
}
