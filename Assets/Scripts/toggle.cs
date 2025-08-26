using UnityEngine;
using UnityEngine.UI;

public class toggle : MonoBehaviour
{
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;

    [SerializeField] private GameObject[] objetos;


    private bool stateObject;
    private Toggle button;

    void Awake()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(false);
        }
        stateObject = false;
        button = GetComponent<Toggle>();
    }
    public void change()
    {
        if (button.isOn)
        {
            GetComponentInChildren<Image>().sprite = on;
        }
        else
        {
            GetComponentInChildren<Image>().sprite = off;
        }
    }

    public void changeActiveObject()
    {
        if (stateObject == false)
        {
            for (int i = 0; i < objetos.Length; i++)
            {
                objetos[i].SetActive(true);
            }
            stateObject = true;
        }
        else
        {
            for (int i = 0; i < objetos.Length; i++)
            {
                objetos[i].SetActive(false);
            }
            stateObject = false;
        }
    }

    public void setToggleOff()
    {
        GetComponentInChildren<Image>().sprite = off;
        if (stateObject != false)
        {
           button.isOn = false; 
        }
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(false);
        }
        stateObject = false;
    }

    public void OnDisable()
    {
        GetComponentInChildren<Image>().sprite = off;
        button.isOn = false;
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(false);
        }
        stateObject = false;
    }
}
