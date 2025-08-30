using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private string _EstatisticaPath;
    void Start()
    {
        _EstatisticaPath = Application.persistentDataPath + "/Estatistica";
        if (!Directory.Exists(_EstatisticaPath))
        {
            Directory.CreateDirectory(_EstatisticaPath);
            Debug.Log($"Pasta criada: {_EstatisticaPath}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
