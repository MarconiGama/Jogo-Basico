using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//criação de classse herdeira
public class moveOffSet : MonoBehaviour
{
    //parâmetro do tipo material
    private Material materialAtual;

    //parâmetros do tipo float
    public float rapidez;
    private float offSet;

    //declaração de função Start 
    void Start()
    {
        //atribuição de variável
        materialAtual = GetComponent<Renderer>().material;

    }

    //função FixedUpdate 
    void FixedUpdate()
    {
        //atribuição valor da variável rapidez
        offSet += 0.01f;

        //aplicação de função a materialAtual 
        materialAtual.SetTextureOffset("_MainTex", new Vector2(offSet * rapidez, 0));

    }
}
