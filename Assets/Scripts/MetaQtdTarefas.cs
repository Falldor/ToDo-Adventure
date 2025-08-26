using TMPro;
using UnityEngine;

public class MetaQtdTarefas : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputQtdTarefasMeta;
    void Start()
    {
        _inputQtdTarefasMeta.text = "3";
    }

    public void SalvarQtdMetaTarefas()
    {
        //TarefasController.Instance.SetQtdMetaTarefas(int.Parse(_inputQtdTarefasMeta.text));
    }
    
    

}
