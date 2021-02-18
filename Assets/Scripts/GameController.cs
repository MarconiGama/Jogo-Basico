using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Declaração de variáveis do tipo texto
    public Text textoPergunta;
    public Text textoPontos;
    public Text textoTimer;
    public Text textoHighScore;

    //Variável dp Pool de Objetos 
    public SimpleObjectPool answerButtonObjectPool;

    //Variável que coloca o objeto como pai das respostas
    public Transform answerButtonParent;

    //Variável biblioteca UI
    public GameObject painelDePerguntas;
    public GameObject painelFimRodada;

    //Declaração da variável dataController e rodadaAtual
    private DataController dataController;
    private RoundData rodadaAtual;

    //Variável vetor do QuestionData
    private QuestionData[] questionPool;

    //Váriável tempo regressivo
    private bool rodadaAtiva;
    private float tempoRestante;
    
    //Variável de contagem das perguntas
    private int questionIndex;

    //Variável de pontuação do jogador
    private int playerScore;

    //Lista para verificação de perguntas utilizadas
    List<int> usedValues = new List<int>();

    //Lista dos botões das respostas
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    //
    void Start()
    {
        //atribuição do valor dataController
        dataController = FindObjectOfType<DataController>();

        //atrbuição do valor rodadaAtual
        rodadaAtual = dataController.GetCurrentRoundData();

        //atribuição do valor questionPool
        questionPool = rodadaAtual.perguntas;

        //atribuição do valor de tempoRestante
        tempoRestante = rodadaAtual.limitedeTempo;

        //função chamada
        UpdateTimer();

        //
        playerScore = 0;
        questionIndex = 0;
        ShowQuestion();
        rodadaAtiva = true;

    }

    // Verificação de rodada, encerramento de rodada
    void Update()
    {
        if (rodadaAtiva)
        {
            tempoRestante -= Time.deltaTime;

            //função chamada
            UpdateTimer();
            if (tempoRestante <= 0)
            {
                EndRound();
            }
        }
    }

    //função para relógio do layout
    private void UpdateTimer()
    {
        textoTimer.text = "Timer: " + Mathf.Round(tempoRestante).ToString();
    }

    //função para mostrar as perguntas
    private void ShowQuestion()
    {
        RemoveAnswerButtons();

        int random = Random.Range(0, questionPool.Length);
        while (usedValues.Contains(random))
        {
            random = Random.Range(0, questionPool.Length);
        }

        QuestionData questionData = questionPool[random];
        usedValues.Add(random);
        textoPergunta.text = questionData.textodaPergunta;

        for (int i = 0; i < questionData.respostas.Length; i++)
        {
            GameObject answerButtongameObject = answerButtonObjectPool.GetObject();

            answerButtongameObject.transform.SetParent(answerButtonParent);

            answerButtonGameObjects.Add(answerButtongameObject);

            AnswerButton answerButton = answerButtongameObject.GetComponent<AnswerButton>();
            
            answerButton.Setup(questionData.respostas[i]);
        }
    }

    //função para remover os botôes
    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    //Váriavel com parâmetro 
    public void AnswerButtonClicked(bool estaCorreto)
    {
        if (estaCorreto)
        {
            playerScore += rodadaAtual.pontosporAcerto;
            textoPontos.text = "Score: " + playerScore.ToString();
        }

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }

        else
        {
            EndRound();
        }   
    }

    //Função para encerrar a rodada
    public void EndRound()
    {
        rodadaAtiva = false;

        dataController.EnviarNovoHighScore(playerScore);
        textoHighScore.text = "High score: " + dataController.GetHighScore().ToString();

        painelDePerguntas.SetActive(false);

        painelFimRodada.SetActive(true);
    }

    //Função para retornar para o Menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
