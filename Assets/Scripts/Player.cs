using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public enum SelectedPlayer
    {
        Player1,
        Player2,
        Player3,
        Player4
    };
    public SelectedPlayer selectedPlayer;

    public delegate void ManaUse();
    public static event ManaUse OnManaUse;

    public int moveSpeed = 3000;
    public int maxSpeed = 4;
    public float stopForce = 0.5f;
    public int jumpForce = 500;
    public int dashForce = 900;
    public int dashMaxSpeed = 18;
    public float dashTime = 0.1f;
    

    private Rigidbody2D player_rg;
    private string jump = "", fire = "", dash = "", horizontal = "", vertical = "";
    private bool isGrounded = true;
    private bool canDash = true;
    private bool dashing = false;
    private Vector2 direction;



    void Start()
    {
        setControls();
        player_rg = GetComponent<Rigidbody2D>();
        //ManaBar.OnManaFull += DashUnlock;
        GameController.checkNull(player_rg, "Player RigidBody", gameObject); //Verificando se foi possivel pegar o componente, caso não, emitir um erro
    }

    void Update()
    {
        Jump();
        Dash();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void setControls()
    {
        switch (selectedPlayer)
        {
            case SelectedPlayer.Player1:
                jump = "Jump1";
                fire = "Fire1";
                dash = "Dash";
                horizontal = "Horizontal";
                vertical = "Vertical";
                break;
            case SelectedPlayer.Player2:
                jump = "Jump2";
                fire = "Fire2";
                dash = "Dash2";
                horizontal = "Horizontal2";
                vertical = "Vertical2";
                break;
            case SelectedPlayer.Player3:
                jump = "Jump3";
                fire = "Fire3";
                dash = "Dash3";
                horizontal = "Horizontal3";
                vertical = "Vertical3";
                break;
            case SelectedPlayer.Player4:
                jump = "Jump4";
                fire = "Fire4";
                dash = "Dash4";
                horizontal = "Horizontal4";
                vertical = "Vertical4";
                break;
        }
    }

    private void Move()
    {
        if (Input.GetButton(horizontal))
        {
            float direction = Input.GetAxis(horizontal);

            //Invertendo impulso do player caso ele troque de direção
            if (player_rg.velocity.x > 0 && direction < 0 || player_rg.velocity.x < 0 && direction > 0) 
                player_rg.velocity = new Vector2(player_rg.velocity.x * -1, player_rg.velocity.y);

            //Adicionando força de movimento
            player_rg.AddForce(new Vector2(direction, 0) * moveSpeed * Time.deltaTime);

            int max; // uma variavel temporaria que vai armazenar a velocidade maxima atual

            if (dashing)
                max = dashMaxSpeed; // esta realizando dash, velocidade maxima maior
            else
                max = maxSpeed;  // não esta em dash, velocidade maxima menor

            //Controle de velocidade maxima

            if (player_rg.velocity.x > max) // Se o eixo X estiver acima da velocidade limite, a velocidade agora é a velocidade limite.
                player_rg.velocity = new Vector2(max, player_rg.velocity.y);
            if (player_rg.velocity.x < max * -1)// Se o eixo X estiver abaixo da velocidade limite * -1 (mesma velocidade só que negativa), a velocidade agora é a velocidade limite * -1.
                player_rg.velocity = new Vector2(max * -1, player_rg.velocity.y);
            if (dashing)
            {
                if (player_rg.velocity.y > max)
                    player_rg.velocity = new Vector2(player_rg.velocity.x, max);
                if (player_rg.velocity.y < max * -1)
                    player_rg.velocity = new Vector2(player_rg.velocity.x, max * -1);
            }
            
        }   
        else
        {
            //Desacelerando personagem caso o player não pressione eixo x
            if (player_rg.velocity.x != 0) 
            {
                if (player_rg.velocity.x > 0)
                {
                    player_rg.velocity = new Vector2(player_rg.velocity.x - stopForce, player_rg.velocity.y);
                    if (player_rg.velocity.x < 0) // caso a redução tenha sido o suficiente para inverter o eixo X, pare o personagem. Mantenha velocidade y.
                        player_rg.velocity = new Vector2(0, player_rg.velocity.y);
                }
                else
                {
                    player_rg.velocity = new Vector2(player_rg.velocity.x + stopForce, player_rg.velocity.y);
                    if (player_rg.velocity.x > 0)
                        player_rg.velocity = new Vector2(0, player_rg.velocity.y);
                }
            }
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown(jump) && isGrounded)
        {
            player_rg.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void Dash()
    {
        if(Input.GetButtonDown(dash) && !isGrounded && canDash && (Input.GetAxisRaw(horizontal) != 0 || Input.GetAxisRaw(vertical) != 0)) 
        {
            player_rg.velocity = new Vector2(0,0);
            direction = new Vector2(Input.GetAxisRaw(horizontal) * dashForce, Input.GetAxisRaw(vertical) * dashForce);
            player_rg.AddForce(direction);
            canDash = false;
            dashing = true;
            player_rg.gravityScale = 0;
            StartCoroutine("StopDashing");
            //OnManaUse?.Invoke();
        }
    }

    /*public void DashUnlock()
    {
        canDash = true;
    }*/

    IEnumerator StopDashing() // Coroutine que vai parar o dash depois do dashTime estabelecido
    {
        while (dashing)
        {
            yield return new WaitForSeconds(dashTime/2);
            player_rg.AddForce((direction*-1)/2);
            yield return new WaitForSeconds(dashTime);
            dashing = false;
            player_rg.gravityScale = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
            canDash = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    


    private void OnDestroy()
    {
        //ManaBar.OnManaFull -= DashUnlock;
    }
}
