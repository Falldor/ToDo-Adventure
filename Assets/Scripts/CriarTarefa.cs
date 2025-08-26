using System;
using TMPro;
using UnityEngine;

public class CriarTarefa : MonoBehaviour
{

    [SerializeField] private TMP_InputField _textoTarefaInput;
    [SerializeField] private int[] _horario;
    [SerializeField] private string[] _data;

    [SerializeField] private int[] _horarioNotificacao;
    private int _id;
    void Start()
    {
        _data = new string[3];
    }

    public void SetHorarioNotificacao(int[] horario)
    {
        _horarioNotificacao = horario;
    }

    public void submit()
    {
        if (GetComponentInChildren<GeradorCalendario>() != null)
        {
            Debug.Log("aqui");
            _data = GetComponentInChildren<GeradorCalendario>().submit();
            _horario = GetComponentInChildren<GeradorHorario>().submit();
            if (transform.GetComponentInChildren<notificacao>() == null)
            {
                Debug.Log("aqui não");
                _horarioNotificacao = transform.GetComponentInChildren<notificacao>().submit();
                TarefasController.Instance.CreateCard(_textoTarefaInput.text, _horario, _data, _horarioNotificacao);
            }
            else {Debug.Log("aqui sim"); TarefasController.Instance.CreateCard(_textoTarefaInput.text, _horario, _data); }
        }
        else
        {
            Debug.Log(GetComponentInChildren<GeradorCalendario>());
            TarefasController.Instance.CreateCard(_textoTarefaInput.text);
        }
        _textoTarefaInput.text = "";
        CloseView();
    }

    public void StartEdit(int id, string tarefaTexto, DateTime horario, DateTime horarioNotificacao)
    {
        this._id = id;
        this._textoTarefaInput.text = tarefaTexto;
        if (horario.Year == 0001)
        {
            Debug.Log("vazio hora");
        }

        if (horarioNotificacao.Year == 0001)
        {
            Debug.Log("vazio notifica");
        }
    }

    public void CloseView()
    {
        ViewController.Instance.CloseView();
    }
}