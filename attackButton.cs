using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class attackButton : MonoBehaviour
{
    public Button startat;
    public int test = 0;
    public Animator anim;

    public void attackk()
    {
        Invoke("att", 0.5f);
        startat.interactable = false;
        anim.SetTrigger("attack");
    }

    void att()
    {
        startat.interactable = true;
        test = 0;
    }
}
