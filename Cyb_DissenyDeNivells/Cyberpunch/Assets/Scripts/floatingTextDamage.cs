using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingTextDamage : MonoBehaviour
{
    private string text;
    public Animator animator;
    private Text numberText;

    private void Awake()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        numberText = animator.GetComponent<Text>();
    }

    void Update()
    {
        text = floatingTextControllerDamage.textt;
        numberText.text = text;
    }
}
