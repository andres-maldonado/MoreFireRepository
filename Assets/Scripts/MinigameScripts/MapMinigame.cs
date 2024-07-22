using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacuationMinigame : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player_icon;
    private Vector3 prev_pos;
    public int step = 0;
    [SerializeField] EventReference mapDraw;
    void OnTriggerEnter2D()
    {
        if (step == 0)
        {
            this.transform.GetChild(4).gameObject.SetActive(true);
            this.transform.GetChild(10).gameObject.SetActive(false);
            this.transform.GetChild(11).gameObject.SetActive(true);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-0.371f, -2.363f);
            AudioManager.instance.PlayOneShot(mapDraw, this.transform.position);
        }
        else if (step == 1)
        {
            this.transform.GetChild(5).gameObject.SetActive(true);
            this.transform.GetChild(11).gameObject.SetActive(false);
            this.transform.GetChild(12).gameObject.SetActive(true);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-2.096f, -2.398f);
            AudioManager.instance.PlayOneShot(mapDraw, this.transform.position);
        }
        else if (step == 2)
        {
            this.transform.GetChild(6).gameObject.SetActive(true);
            this.transform.GetChild(12).gameObject.SetActive(false);
            this.transform.GetChild(13).gameObject.SetActive(true);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-5.509f, -2.395f);
            AudioManager.instance.PlayOneShot(mapDraw, this.transform.position);
        }
        else if (step == 3)
        {
            this.transform.GetChild(7).gameObject.SetActive(true);
            this.transform.GetChild(13).gameObject.SetActive(false);
            this.transform.GetChild(14).gameObject.SetActive(true);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-5.491f, -3.529f);
            AudioManager.instance.PlayOneShot(mapDraw, this.transform.position);
        }
        else if (step == 4)
        {
            this.transform.GetChild(8).gameObject.SetActive(true);
            this.transform.GetChild(14).gameObject.SetActive(false);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-6.8f, -3.6f);
            AudioManager.instance.PlayOneShot(mapDraw, this.transform.position);
        }
        else if (step == 5)
        {
            this.transform.GetChild(9).gameObject.SetActive(true);
            AudioManager.instance.PlayOneShot(mapDraw, this.transform.position);
            Destroy(player_icon);
            step++;
            animator.Play("MinigameMoveDown");
            GetComponentInParent<MinigameWin>().Win();
        }
        step++;
    }
}
