using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeThrower : MonoBehaviour
{
    [SerializeField]
    private List<Cube> cubes;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private int throwForce;

    private bool isHaveCube;

    private GameObject currentCube;
    private Vector3 cubePosition;

    private void Awake()
    {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !isHaveCube)
        {
            //Debug.Log("Down");
            isHaveCube = true;
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 20))
            {
                //Debug.Log("Raycast");

                currentCube = Instantiate(cubes[Random.Range(0, cubes.Count)].gameObject, raycastHit.point, Quaternion.identity);
                cubePosition = new Vector3(raycastHit.point.x, 1, -6);
                currentCube.gameObject.transform.position = cubePosition;
            }
        }

        else if (Input.GetMouseButton(0) && isHaveCube)
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 20))
            {
                cubePosition = new Vector3(raycastHit.point.x, 0.1f, -6);
                currentCube.gameObject.transform.position = cubePosition;
                currentCube.GetComponent<Cube>().enabled = false;
            }
        }

        else if (Input.GetMouseButtonUp(0) && isHaveCube)
        {
            isHaveCube = false;
            currentCube.GetComponent<Rigidbody>().AddForce(Vector3.forward * 250 * throwForce * Time.deltaTime);
            currentCube.GetComponent<Cube>().enabled = true;
        }

        cubePosition = new Vector3(Mathf.Clamp(cubePosition.x, -2, 2), cubePosition.y, cubePosition.z);
    }
}
