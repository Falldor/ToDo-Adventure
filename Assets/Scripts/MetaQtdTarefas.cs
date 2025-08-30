using TMPro;
using UnityEngine;

public class MetaQtdTarefas : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputQtdTarefasMeta;
    void OnEnable()
    {
        if (PlayerPrefs.HasKey("MetaTarefas"))
        {
            _inputQtdTarefasMeta.text = PlayerPrefs.GetString("MetaTarefas");
        }else {_inputQtdTarefasMeta.text = "3";}
        
        SalvarQtdMetaTarefas();
    }

    public void SalvarQtdMetaTarefas()
    {
        PlayerPrefs.SetString("MetaTarefas", _inputQtdTarefasMeta.text);
        MetaController.instance.SetMeta(_inputQtdTarefasMeta.text);
    }

    public void CloseView()
    {
        ViewController.Instance.CloseView();
    }
    
    

}
