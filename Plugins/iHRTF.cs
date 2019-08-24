using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class iHRTF : MonoBehaviour
{

    [DllImport("iHRTF-Spatializer")]
    public static extern int iHRTF_loadSOFA(string path);

    [DllImport("iHRTF-Spatializer")]
    public static extern void iHRTF_selectSOFA(int id);

    [DllImport("iHRTF-Spatializer")]
    public static extern void iHRTF_removeSOFA(int id);

    [DllImport("iHRTF-Spatializer")]
    public static extern void iHRTF_clearSOFA();

    [DllImport("iHRTF-Spatializer")]
    public static extern void config(bool interpolation, float gain_db);

}
