using UnityEngine;
using UnityEngine.UI;

public class My_Button : MonoBehaviour
{
   private void OpenView(nomesPrefabs nomeView)
   {

      ViewController.Instance.OpenView(nomeView, transform.GetComponent<Button>());
   }

   public void CriarTarefaView() => OpenView(nomesPrefabs.CriarTarefa);
   public void EditarTarefaView() => OpenView(nomesPrefabs.EditarTarefa);
}
