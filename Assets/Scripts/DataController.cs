using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //carrega a cena
using System.IO; //inteface do usuário

public class DataController : MonoBehaviour //Classe herda Monobehviour
{
    private RoundData[] todasasRodadas;     //Variável tipo vetor todasasRodadas
    private int rodadaIndex;                //Variável tipo inteiro rodada
    private int playerHighScore;            //Variável tipo inteiro para salvar a pontuação máxima
        
    private string gameDataFileName = "data.json"; //Variável que declara o json

    void Start()
    {
        DontDestroyOnLoad(gameObject);      //função de persitencia DataController entre as cenas 
        LoadGameData();                     //chamando função de carregar os dados         
        SceneManager.LoadScene("Menu");     //função para carregar o menu ao iniciar
    }

    void Update()
    {

    }
    
    public void SetRoundData(int round)     //função de definição da rodada atual com parametro do tipo inteiro
    {
        rodadaIndex = round;
    }

    public RoundData GetCurrentRoundData()   //função para retornar a rodada atual 
    {
        return todasasRodadas[rodadaIndex];
    }
        
    private void LoadGameData()             //função de carr
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if(File.Exists(filePath))
        {
            string dataAsJSON = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJSON);
            todasasRodadas = loadedData.todasAsRodadas;            
        }

        else
        {
            Debug.LogError("Erro em carregar dados!");
        }
    }

    //função para enviar nova pontuação
    public void EnviarNovoHighScore(int newScore)
    {
        if(newScore > playerHighScore)
        {
            playerHighScore = newScore;
            SavePlayerProgress();
        }
    }

    //função para para pegar a pontuação
    public int GetHighScore()
    {
        return playerHighScore;
    }

    //função para carregar os dados salvos
    private void LoadPlayerProgress()
    {
        if(PlayerPrefs.HasKey("highScore"))
        {
            playerHighScore = PlayerPrefs.GetInt("highScore");
        }
    }

    //função para salvar o progresso no jogo
    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highScore", playerHighScore);
    }
}
