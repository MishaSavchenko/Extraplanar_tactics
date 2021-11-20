using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Renderer rend;
    private Color originalColor;
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        originalScale = this.transform.localScale;
        enlargedScale = this.transform.localScale / 0.81f;
    }

    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    // ...the red fades out to cyan as the mouse is held over...
    void OnMouseOver()
    {

        this.transform.localScale = enlargedScale;
        rend.material.color -= new Color(0.1F, 0, -0.1f) * Time.deltaTime;
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        rend.material.color = originalColor;
        this.transform.localScale = originalScale;
    }
}
