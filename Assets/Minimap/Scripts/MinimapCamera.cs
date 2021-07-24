using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArenaMinimap
{
    public class MinimapCamera : MonoBehaviour
    {
        private Camera _camera;

        //Initializes camera by setting the culling mask
        public void MInitialize(LayerMask p_layerMask)
        {
            _camera = GetComponent<Camera>();
            _camera.cullingMask = p_layerMask;
        }

        //Applies the Render Texture to which the camera will be rendered
        public void ApplyRenderTexture(RenderTexture p_texture)
        {
            _camera.targetTexture = p_texture;
        }
    }
}

