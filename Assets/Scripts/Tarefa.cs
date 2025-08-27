using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public class Tarefa : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textoTarefa;
    [SerializeField] private int _id;
    [SerializeField] DateTime _tempoRestante;
    [SerializeField] int[] _tempoNotificao;

    public void CreateTarefa(string textoTarefa, int id)
    {

        this._textoTarefa.text = textoTarefa;
        this._id = id;
    }

    public void CreateTarefa(int id, string textoTarefa, DateTime data)
    {
        this._textoTarefa.text = textoTarefa;
        this._id = id;
        _tempoRestante = data;
        Debug.Log(_tempoRestante);
    }

    public void CreateTarefa(int id, string textoTarefa, DateTime data, int[] horarioNotificacao)
    {
        this._textoTarefa.text = textoTarefa;
        this._id = id;

        _tempoRestante = data;
        _tempoNotificao = horarioNotificacao;
        gameObject.AddComponent<sendNotification>();
        GetComponent<sendNotification>().createNotification(textoTarefa, calculaData(data, horarioNotificacao));
    }



    void FixedUpdate()
    {
        if (_tempoRestante.Year != 0001)
        {
            if (DateTime.Now.ToString("HH:mm") == _tempoRestante.ToString("HH:mm"))
            {
                Destroy(gameObject);// add que quando destruir inimigos ficam mais forte
            }
        }
    }


    public void TarefaConcluida()
    {
        //lojaController.Instance.AddDinheiro(1);
        //TarefasController.Instance.SetNumTarefasConcluidas(1);
        delete();
    }

    public void delete()
    {
        TarefasController.Instance.TarefaComplete(_id);
        Destroy(gameObject);
    }

    public void EditTarefa(Button button)
    {
        ViewController.Instance.OpenView(nomesPrefabs.CriarTarefa, button);
        ViewController.Instance.GetViewAtual().GetComponent<CriarTarefa>().StartEdit(_id, _textoTarefa.text, _tempoRestante, _tempoNotificao);
    }

    public void SetInformation(string textoTarefa, DateTime data, int[] horarioNotificacao)
    {
        this._textoTarefa.text = textoTarefa;
        if (_tempoRestante != null || horarioNotificacao.Length > 0)
        {
            if (data.Year != 0001)
            {
                if (horarioNotificacao.Length > 0)
                {
                    _tempoNotificao = horarioNotificacao;
                    GetComponent<sendNotification>().createNotification(textoTarefa, calculaData(data, horarioNotificacao));
                }
                else
                {
                    Destroy(GetComponent<sendNotification>());
                    _tempoNotificao = new int[0];
                }
            }
            else
            {
                Destroy(GetComponent<sendNotification>());
                _tempoNotificao = new int[0];
            }
            _tempoRestante = data;
        }

    }

    private DateTime calculaData(DateTime data, int[] horarioNotifica)
    {
        data = data.AddDays(-horarioNotifica[0]);
        data = data.AddHours(-horarioNotifica[1]);
        data = data.AddMinutes(-horarioNotifica[2]);
        return data;
    }

    public string GetTarefaTexto()
    {
        return _textoTarefa.text;
    }

    public string GetTempoRestante()
    {
        if (_tempoRestante.Year != 0001)
        {
            string tempoRestante = _tempoRestante.ToString();
            return tempoRestante; 
        }else { return "null"; }
        
    }

    public string GetTempoNotificacao()
    {
        if (_tempoNotificao.Length > 0)
        {
            string notificacao = $"{_tempoNotificao[0]},{_tempoNotificao[1]},{_tempoNotificao[2]}";
            return notificacao;
        } else { return "null"; }
    }

    

}