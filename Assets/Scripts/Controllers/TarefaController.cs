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
        return DateTime.ParseExact($"{data[0]}/{data[1]}/{data[2]} {horario[0]:00}:{horario[1]:00}",
        "dd/MMM/yyyy HH:mm", new CultureInfo("pt-BR"));
    }

    void OnApplicationQuit()
    {
        Data dados = new Data(_tarefas);
        SaveSystem.Salvar(dados, _savePath);
    }

    private void CarregaTarefas()
    {
        if (SaveSystem.Load(_savePath) != null)
        {
            Data dados = SaveSystem.Load(_savePath);
            for (int i = 0; i < dados.textoTarefas.Length; i++)
            {
                if (dados.temposRestante[i] != "null")
                {
                    if (dados.tempoNotificoes[i] != "null")
                    {
                        CreateCard(dados.textoTarefas[i],
                        Array.ConvertAll(dados.temposRestante[i].Split(" ")[1].Split(":"), int.Parse),
                        dados.temposRestante[i].Split(" "), Array.ConvertAll(dados.tempoNotificoes[i].Split(","), int.Parse));
                    }
                    else
                    {
                        CreateCard(dados.textoTarefas[i],
                        Array.ConvertAll(dados.temposRestante[i].Split(" ")[1].Split(":"), int.Parse),
                        dados.temposRestante[i].Split(" "));
                    }
                }
                else
                {
                    CreateCard(dados.textoTarefas[i]);
                }
            }
        }
    }

}