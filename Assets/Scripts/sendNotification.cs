using System;
using UnityEngine;

public class sendNotification : MonoBehaviour
{
    public DateTime tempoNotificacao;
    public string textTarefa;

    public void createNotification(string textoTarefa, DateTime tempoNotificacao)
    {
        this.textTarefa = textoTarefa;
        this.tempoNotificacao = tempoNotificacao;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DateTime.Now.ToString("HH:mm") == tempoNotificacao.ToString("HH:mm"))
        {
            NotificacaoController.Instance.sendNotification(textTarefa);
            Destroy(this);
        }
    }
}
