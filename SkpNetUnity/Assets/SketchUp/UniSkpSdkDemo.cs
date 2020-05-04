using PgSkpDK.SketchupRef;
using PgSkpDK.SketchupWrapper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEditor;
using UnityEngine.TaskExtension;

public class UniSkpSdkDemo : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SkpModel model = new SkpModel("./../testskp/test.skp");
            model.LoadModel();
        }
    }
}
 