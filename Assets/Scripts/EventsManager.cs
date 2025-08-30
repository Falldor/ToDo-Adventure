using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    void Awake() => instance = this;

    public event Action tarefaConcluida;
    public void TarefaConcluida() => tarefaConcluida?.Invoke();

    public event Action tarefaDeletada;
    public void TarefaDeletada() => tarefaDeletada?.Invoke();

    public event Action tarefaCriada;
    public void TarefaCriada() => tarefaCriada?.Invoke();
}
