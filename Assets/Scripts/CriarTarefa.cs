using System;
using TMPro;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CriarTarefa : MonoBehaviour
{
    public static CriarTarefa instance;

    [SerializeField] private TMP_InputField _textoTarefaInput;

    [SerializeField] private toggle toggle_addTempoLimite;
    [SerializeField] private toggle toggle_addNotificacao;

    [SerializeField] private int[] _horario;
    [SerializeField] private string[] _data;

    [SerializeField] private int[] _horarioNotificacao;
    private int _id;

    [SerializeField] private Button buttonCriar;
    [SerializeField] private Button buttonSalvar;

    void Awake() => instance = this;
    void Start()
    {
        _data = new string[3];
    }

    void OnEnable()
    {
        if (_textoTarefaInput.text.Length > 1)
        {
            buttonSalvar.gameObject.SetActive(true);
        }
        else { buttonSalvar.gameObject.SetActive(false); }
    }

    public void SetHorarioNotificacao(int[] horario)
    {
        _horarioNotificacao = horario;
    }

    public void submit()
    {
        if (toggle_addTempoLimite.GetState())
        {
            _data = GetComponentInChildren<GeradorCalendario>().submit();
            _horario = GetComponentInChildren<GeradorHorario>().submit();
            if (toggle_addNotificacao.GetState())
            {
                _horarioNotificacao = transform.GetComponentInChildren<notificacao>().submit();
                TarefasController.Instance.CreateCard(_textoTarefaInput.text, _horario, _data, _horarioNotificacao);
            }
            else {TarefasController.Instance.CreateCard(_textoTarefaInput.text, _horario, _data); }
        }
        else
        {
            TarefasController.Instance.CreateCard(_textoTarefaInput.text);
        }
        _textoTarefaInput.text = "";
        CloseView();
    }

    public void salvarAlteracao()
    {
        if (toggle_addTempoLimite.GetState())
        {
            _data = GetComponentInChildren<GeradorCalendario>().submit();
            _horario = GetComponentInChildren<GeradorHorario>().submit();
            if (toggle_addNotificacao.GetState())
            {
                _horarioNotificacao = transform.GetComponentInChildren<notificacao>().submit();
                TarefasController.Instance.EditCard(_id, _textoTarefaInput.text, _horario, _data, _horarioNotificacao);
            }
            else { TarefasController.Instance.EditCard(_id, _textoTarefaInput.text, _horario, _data, new int[0]); }
        }
        else
        {
            TarefasController.Instance.EditCard(_id, _textoTarefaInput.text, new int[0], new string[0], new int[0]);
        }
        CloseView();
    }

    public void StartEdit(int id, string tarefaTexto, DateTime horario, int[] horarioNotificacao, Button button)
    {
        this._textoTarefaInput.text = tarefaTexto;
        ViewController.Instance.OpenView(nomesPrefabs.CriarTarefa, button);
        this._id = id;
        
        if (horario.Year != 0001)
        {
            toggle_addTempoLimite.setStateTrue();
            GetComponentInChildren<GeradorCalendario>().SetInformations(horario);
            GetComponentInChildren<GeradorHorario>().SetInformations(horario);
        }
        if (horarioNotificacao.Length > 0)
        {
            toggle_addNotificacao.change();
            GetComponentInChildren<notificacao>().SetInformations(horarioNotificacao);
        }
    }

    public void CloseView()
    {
        _textoTarefaInput.text = "";
        if (toggle_addTempoLimite.GetState())
        {
            GetComponentInChildren<GeradorCalendario>().SetInformations(DateTime.Now);
            GetComponentInChildren<GeradorHorario>().SetInformations(DateTime.Now);
        }
        _id = new int();
        buttonCriar.gameObject.SetActive(true);
        buttonSalvar.gameObject.SetActive(false);
        ViewController.Instance.CloseView();
    }
}