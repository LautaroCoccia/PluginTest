using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PluginTest : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI outputText; 
	SuperLogger logger = null;

    private void Start()
    {
        logger = SuperLogger.GetNewInstance();
    }

    public void TestPluginBtn()
    {
        logger.SendLog(Time.time.ToString());
        outputText.text = logger.GetAllLogs();
    }

    public void AlertWindow()
    {
        string msj = "¿Permitir que TITULO DEL JUEGO acceda archivos de tu dispositivo?";
        logger.ShowAlertWindow( msj);
    }
    public void Save()
    {
        logger.manejodearchivos("Taro", 8);

        Debug.Log("Save");
    }
    public void Cagar()
    {
        logger.manejodearchivos("Taro", 8);
        Debug.Log("Save");
    }
    public void Load()
    {
        outputText.text = logger.GetAllLogs();
        LogsData data = SaveLoadLogs.LoadLogs(); ;
         //outputText = data.allLogs;
    }
    public void Exit()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            Application.Quit();
        }
    }
    
}
