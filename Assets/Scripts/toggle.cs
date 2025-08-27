using UnityEngine;
using UnityEngine.UI;

public class toggle : MonoBehaviour
{
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    [SerializeField] private GameObject[] objetos;
    private Sprite buttonImage;
    private bool state;
    private Button button;

    void Start()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(false);
        }
        state = false;
        button = GetComponent<Button>();
    }

    public void change()
    {
        if (!state)
        {
            gameObject.GetComponent<Image>().sprite = on;

            state = true;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = off;
            state = false;
        }
        changeObjectsState();
    }

    private void changeObjectsState()
    {

        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(state);
        }
    }

    public void setStateTrue()
    {
        this.state = true;
        gameObject.GetComponent<Image>().sprite = on;
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(true);
        }
    }

    public bool GetState()
    {
        return state;
    }

    void OnDisable()
    {
        if (state)
        {
            state = false;
            gameObject.GetComponent<Image>().sprite = off;
            changeObjectsState();
        }
    }
}
