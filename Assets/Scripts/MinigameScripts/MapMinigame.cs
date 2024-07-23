using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacuationMinigame : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player_icon;
    [SerializeField] public int step = 0;
    [SerializeField] private int stepcomp = 0;
    [SerializeField] EventReference mapDraw;
    private bool finished = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.GetChild(21).gameObject.SetActive(false);
        }
        if (!finished)
        {
            if (this.transform.GetChild(20).GetComponent<map_step5>().done)
            {
                Destroy(player_icon);
                animator.Play("MinigameMoveDown");
                GetComponentInParent<MinigameWin>().Win();
                finished = !finished;
            }
        }
        if (step != stepcomp)
        {
            AudioManager.instance.PlayOneShot(mapDraw, this.transform.position);
            step = stepcomp;
        }
    }
}
