using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private string _EstatisticaPath;

    [SerializeField] private SistemaDialogo dialogo;

    [SerializeField] Conversa[] conversas;

    private bool primeiraExecucao;


    void Start()
    {
        _EstatisticaPath = Application.persistentDataPath + "/Estatistica";
        if (!Directory.Exists(_EstatisticaPath))
        {
            primeiraExecucao = true;
            Directory.CreateDirectory(_EstatisticaPath);
            Debug.Log($"Pasta criada: {_EstatisticaPath}");
        }

        if (!PlayerPrefs.HasKey("TutorialFeito") || primeiraExecucao == true)
        {
            dialogo.IniciarDialogo(conversas[0]);
            EventsManager.instance.tarefaConcluida += TutorialEficiencia;
        }else{}
    }

    private void TutorialEficiencia()
    {
        if(primeiraExecucao == true){
            dialogo.IniciarDialogo(conversas[1]);
            primeiraExecucao = false;
        }
        
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("TutorialFeito", 1);
        //PlayerPrefs.DeleteAll();
    }

}
