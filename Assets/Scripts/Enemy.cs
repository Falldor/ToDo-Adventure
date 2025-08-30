using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float velocidade = 2;
    [SerializeField] private int vida = 2;

    private Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        EventsManager.instance.tarefaDeletada += ataque;
    }

    public IEnumerator MoveToPosition(float posXFinal)
    {
        animator.SetBool("walking", true);
        /*for (int i = 0; i < unidadesAvancadas; i ++){
            transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
            yield return new WaitForSeconds(0.01f);
        }*/
        while (transform.position.x > posXFinal)
        {
            transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
            Debug.Log(transform.position);
            yield return new WaitForSeconds(0.01f);
        }
        animator.SetBool("walking", false);
    }

    private void ataque()
    {
        StartCoroutine(MoveToPosition(transform.position.x + 2));
        animator.SetTrigger("atacando");
        StartCoroutine(MoveToPosition(transform.position.x - 2));
    }

    public void DanoRecebido(int valor)
    {
        Debug.Log("colidiu");
        animator.SetTrigger("dano");
        vida -= valor;
    }

    public void Dano()
    {
        if (vida <= 0)
        {
            animator.SetTrigger("morreu");
        }
    }

    public void morte()
    {
        Destroy(this.gameObject);
        EnemyController.instance.CreateEnemy();
    }
}
