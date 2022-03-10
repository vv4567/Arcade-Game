using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockHighlight : MonoBehaviour
{
    public Material DefaultMaterial;
    public Material HighlightMaterial;

    public Renderer LockRenderer;
    public int MaterialIndex = 0;

    public void Start()
    {
        if (LockRenderer == null)
        {
            LockRenderer = GetComponent<Renderer>();
        }

        if (DefaultMaterial == null && LockRenderer != null)
        {
            DefaultMaterial = LockRenderer.materials[MaterialIndex];
        }
    }

    public void Highlight()
    {
        if (LockRenderer != null && HighlightMaterial != null)
        {
            LockRenderer.materials[MaterialIndex] = HighlightMaterial;
        }
    }

    public void Unhighlight()
    {
        if (LockRenderer != null && DefaultMaterial != null)
        {
            LockRenderer.materials[MaterialIndex] = DefaultMaterial;
        }
    }
}
