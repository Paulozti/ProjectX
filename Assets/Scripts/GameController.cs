using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum Characters { 
        Iara,
        Lobisomen,
        Curupira,
        Saci
    };

    public static Characters player1, player2, player3, player4;

    public static void checkNull<T>(T obj, string objTxt, GameObject origin) // Recebe um argumento generico obj para verificar se é null e um gameObject para saber de onde veio.
    {
        if (obj == null)
        {
            Debug.LogError( objTxt + " está nulo em " + origin.ToString()); // Causa um erro caso o objeto esteja nulo e identifica de qual GameObject vem o erro.
        }
    }
}
