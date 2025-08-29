using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TarefasController : MonoBehaviour
{
    public static TarefasController Instance;
    [SerializeField] private Dictionary<int, GameObject> _tarefas;
    private int lastId;
    [SerializeField] private GameObject _areaTarefas;
    [SerializeField] private GameObject _cardTarefaPrefab;

    private string _savePath = "tarefas";

    void Awake() => Instance = this;

    void Start()
    {
        lastId = 0;
        _tarefas = new Dictionary<int, GameObject>();
        CarregaTarefas();

    }

    public void CreateCard(string textoInput)
    {
        GameObject tarefa = Instantiate(_cardTarefaPrefab, _areaTarefas.transform);
        tarefa.transform.GetComponent<Tarefa>().CreateTarefa(textoInput, lastId);
        _tarefas.Add(lastId, tarefa);
        lastId++;
    }

    public void CreateCard(string textoInput, int[] horario, string[] data)
    {
        GameObject tarefa = Instantiate(_cardTarefaPrefab, _areaTarefas.transform);
        DateTime date = convertToDateTime(horario, data);
        tarefa.transform.GetComponent<Tarefa>().CreateTarefa(lastId, textoInput, date);
        _tarefas.Add(lastId, tarefa);
        lastId++;
    }

    public void CreateCard(string textoInput, int[] horario, string[] data, int[] horarioNotificacao)
    {
        GameObject tarefa = Instantiate(_cardTarefaPrefab, _areaTarefas.transform);
        DateTime date = convertToDateTime(horario, data);
        Debug.Log(date);
        tarefa.transform.GetComponent<Tarefa>().CreateTarefa(lastId, textoInput, date, horarioNotificacao);
        _tarefas.Add(lastId, tarefa);
        lastId++;
    }

    public void TarefaComplete(int idTarefa)
    {
        _tarefas.Remove(idTarefa);
    }

    public void EditCard(int id, string textoTarefa, int[] horario, string[] data, int[] notificacao)
    {
        if (horario.Length > 0 && data.Length > 0)
        {
            DateTime date = convertToDateTime(horario, data);
            _tarefas[id].GetComponent<Tarefa>().SetInformation(textoTarefa, date, notificacao);
        }
        else { _tarefas[id].GetComponent<Tarefa>().SetInformation(textoTarefa, new DateTime(0001, 01, 01), notificacao); }

    }

    private DateTime convertToDateTime(int[] horario, string[] data)
    {
        Debug.Log($"{data[0]}/{data[1]}/{data[2]} {horario[0]:00}:{horario[1]:00}");
        return DateTime.ParseExact($"{data[0]}/{data[1]}/{data[2]} {horario[0]:00}:{horario[1]:00}",
        "dd/MMM/yyyy HH:mm", new CultureInfo("pt-BR"));
    }

    void OnApplicationQuit()
    {
        
        Data dados = new DataTarefa(_tarefas);
        SaveSystem.Salvar(dados, _savePath);
    }

    private void CarregaTarefas()
    {
        if (SaveSystem.Load(_savePath) != null)
        {
            DataTarefa dados = (DataTarefa)SaveSystem.Load(_savePath);
            for (int i = 0; i < dados.tarefasTextos.Length; i++)
            {
                if (dados.temposRestantes[i] != "null")
                {
                    if (dados.tempoNotificacao[i] != "null")
                    {
                        string[] dataHorario = dados.temposRestantes[i].Split(" ");
                        int[] horario = Array.ConvertAll(dataHorario[1].Split(":"), int.Parse);
                        string[] data = dataHorario[0].Split("/");
                        CreateCard(dados.tarefasTextos[i],horario,data);
                    }
                    else
                    {
                        CreateCard(dados.tarefasTextos[i],
                        Array.ConvertAll(dados.temposRestantes[i].Split(" ")[1].Split(":"), int.Parse),
                        dados.temposRestantes[i].Split(" "));
                    }
                }
                else
                {
                    CreateCard(dados.tarefasTextos[i]);
                }
            }
        }
    } 

}