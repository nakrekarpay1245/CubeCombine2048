using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value;
    public int ID;
    public GameObject nextCube;

    public int instantiateForce;

    public GameObject cubeParticle;
    public TrailRenderer trail;

    public bool passed;
    private void Awake()
    {
        ID = GetInstanceID();
        trail = GetComponentInChildren<TrailRenderer>();
        trail.startColor = GetComponent<MeshRenderer>().material.color;
        trail.endColor = GetComponent<MeshRenderer>().material.color;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            Pass();
            trail.enabled = false;
            // Debug.Log("Cube");
            if (other.gameObject.TryGetComponent(out Cube cube))
            {
                if (cube.nextCube)
                {
                    // Debug.Log("Cube value tryget");
                    if (cube.value == this.value)
                    {
                        // Debug.Log("Cube value equal");

                        if (other.gameObject.GetComponent<Cube>().ID > this.ID)
                        {
                            // Debug.Log("Cube id control");

                            GameObject currentNextCube = Instantiate(nextCube, transform.position, Quaternion.identity);
                            currentNextCube.GetComponent<Rigidbody>().AddForce((Vector3.up + Vector3.forward) * instantiateForce * 100 * Time.deltaTime);
                            Destroy(gameObject);
                            Destroy(other.gameObject);
                            GameObject currentCubeParticle = Instantiate(cubeParticle);
                            currentCubeParticle.transform.position = transform.position;
                            Destroy(currentCubeParticle, 1.15f);
                            SoundPlayer.soundPlayer.PlayPopSound();
                            Manager.manager.Score(nextCube.GetComponent<Cube>().value);
                        }
                    }
                }
            }
        }
    }

    public void Pass()
    {
        passed = true;
    }
}
