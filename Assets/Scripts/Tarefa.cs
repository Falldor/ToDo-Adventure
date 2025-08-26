using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public class Tarefa : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textoTarefa;
    [SerializeField] private int _id;
    [SerializeField] DateTime _tempoRestante;
    [SerializeField] DateTime _tempoNotificao;
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
        _tempoNotificao = calculaData(data, horarioNotificacao);
        gameObject.AddComponent<sendNotification>();
        GetComponent<sendNotification>().createNotification(textoTarefa, _tempoNotificao);
    }

    public void CreateTarefa(string textoTarefa, int id)
    {
        
        this._textoTarefa.text = textoTarefa;
        this._id = id;
    }

    void FixedUpdate()
    {
        if (_tempoRestante != null)
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
        TarefasController.Instance.EditTarefa(_id, _textoTarefa.text, _tempoRestante, _tempoNotificao, button);
    }

    public void SetInformation(string textoTarefa, DateTime data, int[] horarioNotificacao)
    {
        this._textoTarefa.text = textoTarefa;
        if (data != null)
        {
            _tempoRestante = data;
            if (horarioNotificacao != null)
            {
              _tempoNotificao = calculaData(data, horarioNotificacao);  
            }
        }
        
    }
    
    private DateTime calculaData(DateTime data, int[] horarioNotifica)
    {
        data = data.AddDays(-horarioNotifica[0]);
        data = data.AddHours(-horarioNotifica[1]);
        data = data.AddMinutes(-horarioNotifica[2]);
        return data;
    }

    

}