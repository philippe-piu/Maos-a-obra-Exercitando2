using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    // Referência ao componente Rigidbody2D do jogador
    private Rigidbody2D rbd;

    // Quantidade de vida do jogador
    public int vida;

    // Velocidade de movimento do jogador
    public float velocidade;

    // Força do pulo do jogador
    public int forcePulo;

    // Start é chamado antes da primeira atualização do frame
    void Start()
    {
        // Obtém o componente Rigidbody2D do jogador
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update é chamado a cada frame
    void Update()
    {
        // Chama a função de movimento do jogador
        Movimento();

        // Chama a função de pulo do jogador
        Jump();
    }

    // Função responsável pelo movimento horizontal do jogador
    public void Movimento()
    {
        // Define a velocidade na direção horizontal mantendo a velocidade vertical
        rbd.linearVelocity = new Vector2(velocidade, rbd.linearVelocity.y);
    }

    // Função responsável pelo pulo do jogador
    public void Jump()
    {
        // Verifica se a tecla espaço foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Aplica a força do pulo na direção vertical mantendo a velocidade horizontal
            rbd.linearVelocity = new Vector2(rbd.linearVelocity.x, forcePulo);
        }
    }

    // Função chamada quando o jogador entra em contato com um trigger
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto com o qual colidiu tem a tag "Life"
        if (collision.gameObject.CompareTag("Life"))
        {
            // Aumenta a vida do jogador
            vida++;

            // Destroi o objeto coletado (Life)
            Destroy(collision.gameObject);
        }
    }

    // Função chamada quando o jogador colide com um objeto sólido
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto com o qual colidiu tem a tag "Espinho"
        if (collision.gameObject.CompareTag("Espinho"))
        {
            // Reduz a vida do jogador
            vida--;
        }
    }
}
