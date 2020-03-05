using UnityEngine;

public class GameController : MonoBehaviour
{
    public static void checkNull<T>(T obj, string objTxt, GameObject go) // Recebe um argumento generico obj para verificar se é null e um gameObject para saber de onde veio.
    {
        if (obj == null)
        {
            Debug.LogError( objTxt + " está nulo em " + go.ToString()); // Causa um erro caso o objeto esteja nulo e identifica de qual GameObject vem o erro.
        }
    }
}
