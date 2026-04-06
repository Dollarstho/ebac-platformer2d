using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Ebac.Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{

    public enum VFXType
    {
        Jump,
        FireFly
    }
    
    public List<VFXManagerSetup> vfxSetups;

    public void PlayVFXByType(VFXType vfxType, Vector2 position)
    {
        foreach(var i in vfxSetups)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item, 2f);
                break;
            }
        }
    }

    [System.Serializable]
    public class VFXManagerSetup
    {
        public VFXManager.VFXType vfxType;
        public GameObject prefab;
    }

}
