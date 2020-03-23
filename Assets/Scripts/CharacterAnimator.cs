using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private GameController.Characters selectedCharacter;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        GameController.checkNull(anim, "Animator", gameObject);
        GameController.checkNull(sprite, "SpriteRenderer", gameObject);
    }
    public void SetCharacter(GameController.Characters selectedChar)
    {
        selectedCharacter = selectedChar;
    }
}
