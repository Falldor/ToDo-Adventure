using TMPro;
using UnityEngine;
using System.IO;
using System.Diagnostics;



public class NotificacaoController : MonoBehaviour
{
    public static NotificacaoController Instance;

    void Awake() { Instance = this;}

    public void sendNotification(string nomeTarefa)
    {
        string json = JsonUtility.ToJson(new notification("Ta acabando o tempo para fazer " + nomeTarefa, "vai você consegue"), true);
        File.WriteAllText(Path.Combine(Application.dataPath, "notification.json"), json);
        ProcessStartInfo process = new ProcessStartInfo();
        process.FileName = "notification.exe";
        process.CreateNoWindow = true;
        process.WorkingDirectory = Path.Combine(Application.dataPath, "StremingAssets", "notification");
        Process.Start(process);
    }
    
    private class notification
    {
        public string titulo;
        public string msg;

        public notification(string titulo, string texto)
        {
            this.titulo = titulo;
            this.msg = texto;
        }
    }
}
