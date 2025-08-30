using System;
using TMPro;
using UnityEngine;

public class MetaController : MonoBehaviour
{
    public static MetaController instance;
    [SerializeField] private TextMeshProUGUI _textMeta;
    [SerializeField] private string _qtdMeta;

    [SerializeField] private int _qtdMetaAtual;
    [SerializeField] private int _qtdTarefasCriadas;
    [SerializeField] private int _qtdTarefasDeletada;

    private string pathSave = "Estatistica/";

    void Awake() => instance = this;

    void Start()
    {
        pathSave += DateTime.Today.ToString("dd-MM-yyyy");
        Debug.Log(pathSave);
        EventsManager.instance.tarefaConcluida += AddTarefaConcluida;
        EventsManager.instance.tarefaDeletada += AddTarefaDeletada;
        EventsManager.instance.tarefaCriada += AddTarefaCriada;
        if (SaveSystem.Load(pathSave) != null)
        {
            DataEstatistica data = (DataEstatistica)SaveSystem.Load(pathSave);
            _qtdMetaAtual = data.qtdTarefasConcluidas;
            _qtdTarefasCriadas = data.qtdTarefasCriadas;
            _qtdTarefasDeletada = data.qtdTarefasDeletadas;
            this._textMeta.text = $"{_qtdMetaAtual}/{_qtdMeta}";
        }
        
    }

    public void SetMeta(string valor)
    {
        this._qtdMeta = valor;
        this._textMeta.text = $"{_qtdMetaAtual}/{valor}";
    }

    private void AddTarefaConcluida()
    {
        _qtdMetaAtual += 1;
        this._textMeta.text = $"{_qtdMetaAtual}/{_qtdMeta}";
    }

    private void AddTarefaDeletada()
    {
        _qtdTarefasDeletada += 1;
    }

    private void AddTarefaCriada()
    {
        _qtdTarefasCriadas += 1;
    }

    void OnApplicationQuit()
    {
        DataEstatistica data = new DataEstatistica(_qtdTarefasCriadas, _qtdTarefasDeletada, _qtdMetaAtual);
        SaveSystem.Salvar(data, pathSave); // ajeitar pq a pasta não existe
    }
}
