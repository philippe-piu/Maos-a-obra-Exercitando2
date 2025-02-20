using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    // Refer�ncia ao componente Rigidbody2D do jogador
    private Rigidbody2D rbd;

    // Quantidade de vida do jogador
    public int vida;

    // Velocidade de movimento do jogador
    public float velocidade;

    // For�a do pulo do jogador
    public int forcePulo;

    // Start � chamado antes da primeira atualiza��o do frame
    void Start()
    {
        // Obt�m o componente Rigidbody2D do jogador
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update � chamado a cada frame
    void Update()
    {
        // Chama a fun��o de movimento do jogador
        Movimento();

        // Chama a fun��o de pulo do jogador
        Jump();
    }

    // Fun��o respons�vel pelo movimento horizontal do jogador
    public void Movimento()
    {
        // Define a velocidade na dire��o horizontal mantendo a velocidade vertical
        rbd.linearVelocity = new Vector2(velocidade, rbd.linearVelocity.y);
    }

    // Fun��o respons�vel pelo pulo do jogador
    public void Jump()
    {
        // Verifica se a tecla espa�o foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Aplica a for�a do pulo na dire��o vertical mantendo a velocidade horizontal
            rbd.linearVelocity = new Vector2(rbd.linearVelocity.x, forcePulo);
        }
    }

    // Fun��o chamada quando o jogador entra em contato com um trigger
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

    // Fun��o chamada quando o jogador colide com um objeto s�lido
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
