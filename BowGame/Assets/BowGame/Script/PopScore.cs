using UnityEngine;

public class PopScore : MonoBehaviour
{
    // private variables:
    Vector3 crds_delta;
    float alpha;
    float life_loss;
    public Color color = Color.white;

    void Start()
    {
        alpha = 1f;
        crds_delta = new Vector3(0f, 1f, 0f);
        life_loss = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        // move upwards :
        transform.Translate(crds_delta * Time.deltaTime, Space.World);

        // change alpha :
        alpha -= Time.deltaTime * life_loss;
        GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, alpha);

        // if completely faded out, die:
        if (alpha <= 0f) Destroy(gameObject);
    }
}
