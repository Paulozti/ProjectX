using UnityEngine;

public class CharacterMoviment : MonoBehaviour
{
    
    public enum SelectedPlayer
    {
        Player1,
        Player2,
        Player3,
        Player4
    };

    public SelectedPlayer selectedPlayer;
    public int moveSpeed = 3000;
    public int maxSpeed = 4;
    public float stopForce = 0.5f;
    public int jumpForce = 500;
    

    private Rigidbody2D player_rg;
    private string jump = "", fire = "", dash = "", horizontal = "";
    

    void Start()
    {
        setControls();
        player_rg = GetComponent<Rigidbody2D>();
        checkNull(player_rg);
    }

    void Update()
    {
        Jump();
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
                break;
            case SelectedPlayer.Player2:
                jump = "Jump2";
                fire = "Fire2";
                dash = "Dash2";
                horizontal = "Horizontal2";
                break;
            case SelectedPlayer.Player3:
                jump = "Jump3";
                fire = "Fire3";
                dash = "Dash3";
                horizontal = "Horizontal3";
                break;
            case SelectedPlayer.Player4:
                jump = "Jump4";
                fire = "Fire4";
                dash = "Dash4";
                horizontal = "Horizontal4";
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

            //Controle de velocidade

            if (player_rg.velocity.x > maxSpeed) // Se o eixo X estiver acima da velocidade limite, a velocidade agora é a velocidade limite.
                player_rg.velocity = new Vector2(maxSpeed, player_rg.velocity.y);
            if (player_rg.velocity.x < maxSpeed*-1)
                player_rg.velocity = new Vector2(maxSpeed*-1, player_rg.velocity.y);
        }   
        else
        {
            //Desacelerando personagem caso o player não pressione eixo x
            if (player_rg.velocity.x != 0) 
            {
                if (player_rg.velocity.x > 0)
                {
                    player_rg.velocity = new Vector2(player_rg.velocity.x - stopForce, player_rg.velocity.y);
                    if (player_rg.velocity.x < 0) // caso a redução tenha sido o suficiente para inverter o eixo X, pare o personagem.
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
        Debug.Log("Velocity: " + player_rg.velocity.x.ToString());
    }

    private void Jump()
    {
        if (Input.GetButtonDown(jump))
        {
            player_rg.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void checkNull<T>(T obj) // Método para verificar se o objeto passado é nulo, o objeto passado pode ser de qualquer tipo, é um metodo genérico.
    {
        if(obj == null)
        {
            Debug.LogError(obj.ToString() + " está nulo em " + selectedPlayer.ToString()); // Causa um erro caso o objeto esteja nulo e identifica de qual player vem o erro.
        }
    }
}
