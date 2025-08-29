using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    void Awake() => instance = this;
    
    public event Action tarefaConluida()
}
