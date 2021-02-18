using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

//declaração de classe herdeira de EditorWindow
public class GameDataEditor : EditorWindow
{
    //declaração de variável do tipo GameData
    public GameData gameData;

    //declaração do caminho Json
    private string gameDataFilePath = "/StreamingAssets/data.json";

    [MenuItem ("Window/Game Data Editor")]

    //função Init
    static void Init()
    {
        //declaração de variável GameDataEditor
        GameDataEditor windows = (GameDataEditor)EditorWindow.GetWindow(typeof(GameDataEditor));
        //função para mostrar a janela
        windows.Show();
    }

    //função que cria o botão na Engine
    private void OnGUI()
    {
        //verificação de null gameData 
        if(gameData != null)
        {
            //declaração de variável tipo SerializeObject
            SerializedObject serializedObject = new SerializedObject(this);
            //declara a propriedade de serializeObject chama a função FindProperty
            SerializedProperty serializedProperty = serializedObject.FindProperty("gameData");
            //função 
            EditorGUILayout.PropertyField(serializedProperty, true);
            //função para aplicação das mudanças feitas
            serializedObject.ApplyModifiedProperties();
            //função que cria o botão Save Data
            if (GUILayout.Button("Save Data"))
            {
                SaveGameData();
            }
        }
        //cria o botão Load Data
        if(GUILayout.Button("Load Data"))
        {
            LoadGameData();
        }
    }

        //função para carregar os dados
    private void LoadGameData()
    {
        string filePath = Application.dataPath + gameDataFilePath;

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(dataAsJson);
        }

        else
        {
            gameData = new GameData();
        }
    }

    //função para salvar os dados
    private void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(gameData);
        string filePath = Application.dataPath + gameDataFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }
}
