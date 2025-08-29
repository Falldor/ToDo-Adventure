
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataTarefa : Data
{
    public string[] tarefasTextos;
    public string[] temposRestantes;

    public string[] tempoNotificacao;

    public DataTarefa(Dictionary<int, GameObject> tarefas)
    {
        int contador = 0;
        tarefasTextos = new string[tarefas.Count];
        temposRestantes = new string[tarefas.Count];
        tempoNotificacao = new string[tarefas.Count];
        foreach (GameObject gameObject in tarefas.Values)
        {
            Tarefa tarefa = gameObject.GetComponent<Tarefa>();
            tarefasTextos[contador] = tarefa.GetTarefaTexto();
            temposRestantes[contador] = tarefa.GetTempoRestante();
            tempoNotificacao[contador] = tarefa.GetTempoNotificacao();
            Debug.Log(tempoNotificacao[contador]);
            contador++;
        }

        
    }
}