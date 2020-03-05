using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public delegate void ManaRefilled();
    public static event ManaRefilled OnManaFull;

    public Image bar;
    public int refillAmountPerSecond = 1;
    public int dashCost = 100;
    private bool refillMana = false;
    private bool refillingMana = false;
    private float mana;
    void Start()
    {
        GameController.checkNull(bar, "Image Bar",  gameObject);
        mana = 100;
        Player.OnManaUse += UseMana;
    }
    private void Update()
    {
        bar.fillAmount = mana/100;
        
    }

    public void UseMana()
    {
        mana -= dashCost;
        refillMana = true;
        if(!refillingMana)
            StartCoroutine("RefillMana");
    }

    IEnumerator RefillMana()
    {
        while (refillMana)
        {
            if (mana < 100)
            {
                refillingMana = true;
                mana += refillAmountPerSecond;
                bar.fillAmount = mana/100;
            }
            else
            {
                refillMana = false;
                refillingMana = false;
                OnManaFull?.Invoke();
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnDestroy()
    {
        Player.OnManaUse -= UseMana;
    }
}
