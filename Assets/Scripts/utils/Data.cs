using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Data
{
    public string[] textoTarefas;
    public string[] temposRestante;

    public string[] tempoNotificoes;

    public Data(Dictionary<int, GameObject> tarefasCards)
    {
        int tamanhoDicionario = tarefasCards.Count;
        textoTarefas = new string[tamanhoDicionario];
        temposRestante = new string[tamanhoDicionario];
        tempoNotificoes = new string[tamanhoDicionario];
        int contador = 0;
        foreach (GameObject tarefa in tarefasCards.Values)
        {
            textoTarefas[contador] = tarefa.GetComponent<Tarefa>().GetTarefaTexto();
            temposRestante[contador] = tarefa.GetComponent<Tarefa>().GetTempoRestante();
            tempoNotificoes[contador] = tarefa.GetComponent<Tarefa>().GetTempoNotificacao();
            contador++;
        }

        Debug.Log(textoTarefas[0]);
    }
 }