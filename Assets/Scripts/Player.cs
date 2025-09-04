using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _magiaPrefab;
    [SerializeField] private GameObject _pontoMagia;

    public int dano;

    private Animator animator;

    void Start()
    {
        dano = 1;
        animator = GetComponent<Animator>();
        EventsManager.instance.tarefaConcluida += ataque;
    }
    public void StartRun()
    {
        animator.SetBool("walking", true);
    }

    public void EndRun()
    {
        animator.SetBool("walking", false);
    }

    public void ataque()
    {
        animator.SetBool("atacando", true);
    }

    public void SetDano(int dano)
    {
        this.dano = dano;
    }

    public void CreateMagic()
    {
        GameObject magia = Instantiate(_magiaPrefab, _pontoMagia.transform);
        magia.GetComponent<Magia>().setDano(dano);
        animator.SetBool("atacando", false);
    }
}
