using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public bool lookingRight = true;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool dashing = false;
    
    public SpriteRenderer iaraJumpEffect;
    public SpriteRenderer iaraDasheffect;

    public RuntimeAnimatorController[] controllers;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        GameController.checkNull(anim, "Animator", gameObject);
        GameController.checkNull(sprite, "SpriteRenderer", gameObject);
    }
    public void SetCharacter(GameController.Characters selectedChar)
    {
        switch (selectedChar)
        {
            case GameController.Characters.Curupira:
                anim.runtimeAnimatorController = controllers[0] as RuntimeAnimatorController;
                break;
            case GameController.Characters.Iara:
                anim.runtimeAnimatorController = controllers[0] as RuntimeAnimatorController;
                break;
            case GameController.Characters.Lobisomen:
                anim.runtimeAnimatorController = controllers[0] as RuntimeAnimatorController;
                break;
            case GameController.Characters.Saci:
                anim.runtimeAnimatorController = controllers[0] as RuntimeAnimatorController;
                break;
        }
    }

    public void OnMove() //true = right / false = left
    {
        anim.Play("Move");
    }

    public void Flip()
    {
        if (lookingRight)
        {
            sprite.flipX = true;
            iaraJumpEffect.flipX = false;
            iaraDasheffect.flipY = true;
            iaraDasheffect.transform.position = new Vector2(transform.position.x + 0.35f, iaraDasheffect.transform.position.y);
            lookingRight = false;
        }
        else
        {
            sprite.flipX = false;
            iaraJumpEffect.flipX = true;
            iaraDasheffect.flipY = false;
            iaraDasheffect.transform.position = new Vector2(transform.position.x - 0.35f, iaraDasheffect.transform.position.y);
            lookingRight = true;
        }
            
    }

    public void OnIddle()
    {
        anim.Play("Iddle");
        dashing = false;
        iaraJumpEffect.enabled = false;
        iaraDasheffect.enabled = false;
    }

    public void OnJump()
    {
        anim.Play("Jump");
        iaraJumpEffect.enabled = true;
    }

    public void OnDash()
    {
        if (!dashing)
        {
            iaraJumpEffect.enabled = false;
            iaraDasheffect.enabled = true;
            anim.Play("Dash");
            dashing = true;
        }
    }
}
