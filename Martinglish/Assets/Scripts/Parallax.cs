using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    [SerializeField] float parallax;
    Material mat;
    Transform cam;
    Vector3 initialPosition;
    void Start()
    {

        mat = GetComponent<SpriteRenderer>().material;
        cam = Camera.main.transform;
        initialPosition = transform.position;

    }



    void Update()
    {
        transform.position = new Vector3(cam.position.x, initialPosition.y, initialPosition.z);
        mat.mainTextureOffset = new Vector2(cam.position.x * parallax, 0);
    }




}
