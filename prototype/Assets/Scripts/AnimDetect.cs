using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDetect : MonoBehaviour
{
    public Animator animator;
    public float fadeDelay = 0.1f;
    public FadetoWhite whiteFade;

    private bool hasFaded = false;

    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        if (!hasFaded && state.IsName("moveArm") && state.normalizedTime >= 1f)
        {
            hasFaded = true;
            Invoke(nameof(TriggerFade), fadeDelay);
        }
    }

    void TriggerFade()
    {
        whiteFade.FadeToWhite();
    }
}
