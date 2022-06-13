using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FractalManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        CreateJobs();
    }

    // Update is called once per frame
    void Update()
    {
        RunJobUpdate();
    }



    public virtual void RunJobUpdate()
    {
        GetComponent<Instancer>().RenderBatches();
        GetComponent<Instancer>().SetMatrix();
    }

    public virtual void CreateJobs()
    {
        GetComponent<SetReference>().SetRef();
        GetComponent<Instancer>().setTex();
    }
}