using System;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Estatisticas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDia;
    [SerializeField] private TextMeshProUGUI _textTotalCriadas;
    [SerializeField] private TextMeshProUGUI _textTotalConcluidas;
    [SerializeField] private TextMeshProUGUI _textTotalDeletadas;
    private string _pathFolder;
    private FileInfo[] _savesEstatistica;

    private int _index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        _pathFolder = $"{Application.persistentDataPath}/Estatistica";
        _index = 0;
        getArquivos();
    }
    void OnEnable()
    {
        SetEstatistica(_index);
    }

    private void getArquivos()
    {
        DirectoryInfo pasta = new DirectoryInfo(_pathFolder);
        _savesEstatistica = pasta.GetFiles();
    }

    public void SetEstatistica(int index)
    {
        string dia = _savesEstatistica[index].Name.ToString().Replace(".sv", "");
        _textDia.text = dia;
        DataEstatistica data = (DataEstatistica)SaveSystem.Load($"Estatistica/{dia}");

        _textTotalCriadas.text = $"Total de tarefas criadas: {data.qtdTarefasCriadas}";
        _textTotalConcluidas.text = $"Total de tarefas concluidas: {data.qtdTarefasConcluidas}";
        _textTotalDeletadas.text = $"Total de tarefas deletadas: {data.qtdTarefasDeletadas}";
    }

    public void AltDia(int sentido)
    {
        if (sentido > 0)
        {
            _index++;
            if (_index < _savesEstatistica.Length)
                SetEstatistica(_index);
        }
        else
        {
            _index--;
            if (_index >= 0)
                SetEstatistica(_index);
        }
    }



    public void CloseView()
    {
        ViewController.Instance.CloseView();
    }
}
