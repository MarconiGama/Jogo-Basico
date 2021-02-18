using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private DataController data;    //declaração de data como variável do tipo DataController

     void Start()
    {
        data = FindObjectOfType<DataController>(); //função que procurar o objeto do tipo DataController 
    }
        
    public void StartGame(int round)    //função para carregar a cena de jogo com parametro tipo inteiro
    {
        data.SetRoundData(round);       //definição da rodada através do parametro declarado acima
        SceneManager.LoadScene("Game"); //função para carregar a cena Game
    }
}
