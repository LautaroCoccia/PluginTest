using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SuperLoggerAndroid : SuperLogger
{
    const string pluginName = "com.coccialautaro.lclogger.SuperLogger";
    public string logs = "";
    static AndroidJavaClass _pluginClass = null;
    static AndroidJavaObject _pluginInstance = null;

    

    public static AndroidJavaClass PluginClass
    {        get
        {
            if (_pluginClass == null)
            {
                _pluginClass = new AndroidJavaClass(pluginName);
            }
            return _pluginClass;
        }
    }
    public AndroidJavaObject PluginInstance
    {
        get
        {
            if (_pluginInstance == null)
            {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }
    }

   
    public override void SendLog(string msj )
    {
        PluginInstance.Call("sendLog", msj);
    }
    public override string GetAllLogs()
    {
        return PluginInstance.Call<string>("getAllLogs");
    }

    public override void ShowAlertWindow(string msg)
    {
        using(var playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            using(var pluginClass = new AndroidJavaClass("com.coccialautaro.lclogger.SuperLoggerPopUp"))
            {
                pluginClass.CallStatic<AndroidJavaObject>("getInstance")
                    .Call("ShowAlertWindow", new object[] { activity, msg });
            }
        }
        Debug.Log("SuperLoggerPopUp.string msg(" + msg + ")");
    }

    public override void Save(string msg)
    {
        SaveLoadLogs.SaveLogs(this);
    }

    public override void  Load()
    {
        LogsData data = SaveLoadLogs.LoadLogs();
        logs = data.allLogs;
    }
    public override void manejodearchivos(string msg, float dato)
    {
        PluginInstance.Call("existearchivo");
    }
    
}
