using UnityEngine;
using System.Collections;

public class VictimScript : MonoBehaviour {
    public GameObject meatPrefab;
    public int numMeatChunks = 40;
    public bool triggerDeath = false;
    public bool stayDead = false;

    public float explosionForce = 40f;
    public float explosionRadius = 5f;

    public GameObject goreHolder;

    void Update()
    {
        if (triggerDeath)
        {
            explode();
            triggerDeath = false;
        }
    }
    public void explode() {
        // Create a ton of meat prefabs and send them out.
        for (int i = 0; i < numMeatChunks; i++)
        {
            GameObject go = (GameObject) GameObject.Instantiate(meatPrefab, this.transform.position + Random.insideUnitSphere + Vector3.up*2.0f, Random.rotation);
            go.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, explosionRadius);
        }

        Debug.Log("KABOOM");
        // TODO: Create an explosives prefab.  Detonator?
        // TODO: Put a ton of blood on the walls by enabling a hidden gameobject.
        goreHolder.SetActive(true);

        if (stayDead)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}