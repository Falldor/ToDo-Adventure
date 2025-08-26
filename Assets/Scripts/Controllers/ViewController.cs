using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewController : MonoBehaviour
{
    public static ViewController Instance;
    [SerializeField] private ChaveObjeto[] _prefabsArqs;
    [SerializeField] private objetoButton _viewAtual;

    private Dictionary<nomesPrefabs, GameObject> _prefabs;
    void Awake()
    {
        Instance = this;
        GetPrefabs();
    }

    private void GetPrefabs()
    {
        _prefabs = new Dictionary<nomesPrefabs, GameObject>();
        foreach (ChaveObjeto chaveObjeto in _prefabsArqs)
        {
            _prefabs.Add(chaveObjeto.chave, Instantiate(chaveObjeto.objeto, transform));
            _prefabs[chaveObjeto.chave].SetActive(false);
        }
    }

    public void OpenView(nomesPrefabs nomeView, Button button)
    {
        if (_viewAtual.objeto == null)
        {
            _viewAtual.objeto = _prefabs[nomeView];
            _viewAtual.button = button;
        }
        else
        {
            _viewAtual.objeto.SetActive(false);
            _viewAtual.button.interactable = true;
            _viewAtual.objeto = _prefabs[nomeView];
            _viewAtual.button = button;
        }
        _viewAtual.objeto.SetActive(true);
        _viewAtual.button.interactable = false;
    }

    public void CloseView()
    {
        _viewAtual.objeto.SetActive(false);
        _viewAtual.button.interactable = true;
        _viewAtual = new objetoButton();
    }

    public GameObject GetViewAtual()
    {
        return _viewAtual.objeto;
    }
      

}
