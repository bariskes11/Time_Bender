using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CutCalculator : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    [Range(100, 1000)]
    int VertexCountlimitForBreak;
    #endregion

    #region Fields

    #endregion
    #region Properties
    private int vertextCount;
    public int VertextCount
    {
        get => this.vertextCount;
        set => this.vertextCount = value;
    }
    #endregion
    #region Unity Methods
    private void Start()
    {
        var mesh = this.GetComponent<MeshFilter>();
        if (!mesh)
            return;

        int rslt = mesh.mesh.vertexCount;
        this.vertextCount = rslt;
        //  Debug.Log($"Created object Vertex Count  {rslt} Name {this.gameObject.name} ", this.gameObject);
        if (rslt < VertexCountlimitForBreak)
        {
            this.transform.DOScale(Vector3.zero, 0.5F).OnComplete(() => Destroy(this.gameObject));
        }
    }
    #endregion

}
