using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockHighlight : MonoBehaviour
{
    public Material DefaultMaterial;
    public Material HighlightMaterial;

    public Renderer LockRenderer;
    public int MaterialIndex = 0;

    private int length = -1;

    public void Start()
    {

        if (LockRenderer == null)
        {
            LockRenderer = GetComponent<Renderer>();
        }

        if (LockRenderer != null)
        {
            length = LockRenderer.materials.Length;
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
            Material[] materials = new Material[length];

            materials = LockRenderer.materials;
            materials[MaterialIndex] = HighlightMaterial;

            LockRenderer.materials = materials;
        }
    }

    public void Unhighlight()
    {
        if (LockRenderer != null && DefaultMaterial != null)
        {
            Material[] materials = new Material[length];

            materials = LockRenderer.materials;
            materials[MaterialIndex] = DefaultMaterial;

            LockRenderer.materials = materials;
        }
    }
}
