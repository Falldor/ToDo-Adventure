using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TarefasController : MonoBehaviour
{
    [SerializeField] private Dictionary<int, GameObject> _tarefas;
    private int lastId;
    [SerializeField] private GameObject _areaTarefas;
    [SerializeField] private GameObject _cardTarefaPrefab;

    public static TarefasController Instance;

    void Awake() => Instance = this;

    void Start()
    {
        lastId = 0;
        _tarefas = new Dictionary<int, GameObject>();
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
        Debug.Log($"{data[0]}/{data[1]}/{data[2]} {horario[0]}:{horario[1]}");
        DateTime date = DateTime.ParseExact($"{data[0]}/{data[1]}/{data[2]} {horario[0]:00}:{horario[1]:00}",
        "dd/MMM/yyyy HH:mm", new CultureInfo("pt-BR"));
        tarefa.transform.GetComponent<Tarefa>().CreateTarefa(lastId, textoInput, date);

        _tarefas.Add(lastId, tarefa);
        lastId++;
    }

    public void CreateCard(string textoInput, int[] horario, string[] data, int[] horarioNotificacao)
    {
        GameObject tarefa = Instantiate(_cardTarefaPrefab, _areaTarefas.transform);
        DateTime date = DateTime.ParseExact($"{data[0]}/{data[1]}/{data[2]} {horario[0]:00}:{horario[1]:00}",
        "dd/MMM/yyyy HH:mm", new CultureInfo("pt-BR"));
        tarefa.transform.GetComponent<Tarefa>().CreateTarefa(lastId, textoInput, date, horarioNotificacao);
        _tarefas.Add(lastId, tarefa);
        lastId++;
    }

    public void TarefaComplete(int idTarefa)
    {
        _tarefas.Remove(idTarefa);
    }

    public void EditTarefa(int id, string textoTarefa, DateTime horario, DateTime notificacao, Button button)
    {
        ViewController.Instance.OpenView(nomesPrefabs.EditarTarefa, button);
        ViewController.Instance.GetViewAtual().GetComponent<CriarTarefa>().StartEdit(id, textoTarefa, horario, notificacao);
    }

}