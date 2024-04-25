using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private float animationSpeed = 0.05f;
    // Start is called before the first frame update
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += 
            (Vector2.right * animationSpeed * Time.deltaTime);
    }
}
