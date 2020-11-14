using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLoggerEditor : SuperLogger
{
    public override void SendLog(string msj)
    {
        Debug.Log("Send log to Super Logger: " + msj);
    }
    public override string GetAllLogs()
    {
        return "no estas en Android!";
    }
    public override void ShowAlertWindow(string msg)
    {
        
        Debug.Log("Funcion invalida");
    }

    public override void Save(string msg)
    {
        Debug.Log("You can't SAVE");
    }

    public override void Load()
    {
        Debug.Log("You can't LOAD");
    }
    public override void manejodearchivos(string msg, float dato)
    {
        Debug.Log("aun nada");
    }
}
