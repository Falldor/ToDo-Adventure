using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _magiaPrefab;
    [SerializeField] private GameObject _pontoMagia;

    private Animator animator;

    void Start()
    {
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

    public void CreateMagic()
    {
        Instantiate(_magiaPrefab, _pontoMagia.transform);
        animator.SetBool("atacando", false);
    }
}
