using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LogsData 
{
    public string allLogs; 

    public LogsData(SuperLogger logger)
    {
        allLogs = logger.GetAllLogs();
    }
    
}
