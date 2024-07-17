using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacuationMinigame : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player_icon;
    private Vector3 prev_pos;
    public int step = 0;
    private float scale = 2.83f;
    void OnTriggerEnter2D()
    {
        player_icon.GetComponent<TrailRenderer>().emitting = true;
        if (step == 0)
        {
            player_icon.GetComponent<TrailRenderer>().AddPosition(prev_pos);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-0.4f, -2.35f);
            this.transform.GetChild(3).gameObject.transform.position = new Vector2 (-0.4f * scale, -2.35f * scale);
        }
        else if (step == 1)
        {
            Vector3[] temp = {prev_pos, new Vector3 (-1.9f * scale,-1.4f * scale,0), new Vector3 (-0.38f * scale,-1.4f * scale,0)};
            player_icon.GetComponent<TrailRenderer>().AddPositions(temp);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-2.1f, -2.5f);
            this.transform.GetChild(3).gameObject.transform.position = new Vector2 (-2.1f * scale, -2.5f * scale);
        }
        else if (step == 2)
        {
            player_icon.GetComponent<TrailRenderer>().AddPosition(prev_pos);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-5.5f, -2.5f);
            this.transform.GetChild(3).gameObject.transform.position = new Vector2 (-5.5f * scale, -2.5f * scale);
        }
        else if (step == 3)
        {
            player_icon.GetComponent<TrailRenderer>().AddPosition(prev_pos);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-5.5f, -3.5f);
            this.transform.GetChild(3).gameObject.transform.position = new Vector2 (-5.5f * scale, -3.5f * scale);
        }
        else if (step == 4)
        {
            player_icon.GetComponent<TrailRenderer>().AddPosition(prev_pos);
            this.GetComponent<BoxCollider2D>().offset = new Vector2 (-7f, -3.6f);
            this.transform.GetChild(3).gameObject.transform.position = new Vector2 (-7f * scale, -3.6f * scale);
        }
        else if (step == 5)
        {
            player_icon.GetComponent<TrailRenderer>().AddPosition(prev_pos);
            player_icon.GetComponent<TrailRenderer>().emitting = false;
            player_icon.GetComponent<TrailRenderer>().Clear();
            Destroy(player_icon);
            step++;
            animator.Play("MinigameMoveDown");
            GetComponentInParent<MinigameWin>().Win();
        }
        prev_pos = new Vector3 (player_icon.transform.position.x, player_icon.transform.position.y, 2896.903f);
        step++;
    }
    void OnTriggerExit2D()
    {
        player_icon.GetComponent<TrailRenderer>().emitting = false;
    }
    void Start()
    {
        prev_pos = new Vector3 (player_icon.transform.position.x, player_icon.transform.position.y, 2896.903f);
    }
}
