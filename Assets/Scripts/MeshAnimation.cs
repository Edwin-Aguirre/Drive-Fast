using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAnimation : MonoBehaviour
{
    //This script takes an array of meshes and then cycles through them to play an animation
    //Used for all the powerups
    [SerializeField]
    private Mesh[] frames = new Mesh[0];
    [SerializeField]
    private float animationSpeed = .1f;

    private float animationStartTime;
    private int currentFrame;

    void Start()
    {
        currentFrame = 0;
        animationStartTime = Time.time;
    }

    void Update()
    {
        currentFrame = Mathf.FloorToInt((Time.time - animationStartTime) / animationSpeed);
        currentFrame = currentFrame % frames.Length;
        UpdateMesh();
    }

    void UpdateMesh()
    {
        GetComponent<MeshFilter>().mesh = frames[currentFrame];
    }
}
