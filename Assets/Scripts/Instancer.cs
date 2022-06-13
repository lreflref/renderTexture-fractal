using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Unity.Mathematics.math;
using quaternion = Unity.Mathematics.quaternion;

public class Instancer : MonoBehaviour
{
   
    public int instances;

    [HideInInspector]
    public Vector3[] positions;

    [HideInInspector]
    public quaternion[] rotations;

    [HideInInspector]
    public Vector3[] scales;

    public Mesh mesh;

    public Material material;


    public RenderTexture rendTex;

    private List<List<Matrix4x4>> batches = new List<List<Matrix4x4>>();

    [SerializeField]
    int layer;

    public void RenderBatches()
    {
        foreach(var batch in batches)
        {
            Graphics.DrawMeshInstanced(mesh, 0, material, batch, null, UnityEngine.Rendering.ShadowCastingMode.On, true, layer);
        }
    }




    public void SetMatrix()
    {
        int addedMatricies = 0;

        batches = new List<List<Matrix4x4>>();

        for (int i=0; i< instances; i++)
        {
            if(addedMatricies < instances && batches.Count !=0)
            {

                batches[batches.Count -1].Add(Matrix4x4.TRS(positions[i], rotations[i], scales[i]));
                addedMatricies += 1;
            }

            else
            {
                batches.Add(new List<Matrix4x4>());
                batches[0].Add(Matrix4x4.TRS(positions[0], rotations[0], scales[0]));
                addedMatricies = 0;
            }
        }
    }


    public void setTex()
    {
        material.SetTexture("_MainTex", rendTex);
    }


}
