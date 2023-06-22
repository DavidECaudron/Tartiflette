using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera m_cameraA;
    public Camera m_cameraB;

    public Material m_cameraATexture;
    public Material m_cameraBTexture;

    public RenderTexture m_renderTextureA;
    public RenderTexture m_renderTextureB;

    private void Start()
    {
        m_renderTextureA = new RenderTexture(Screen.width, Screen.height, 24);
        m_renderTextureB = new RenderTexture(Screen.width, Screen.height, 24);
        if (m_cameraA != null)
        {
            if (m_cameraA.targetTexture != null)
            {
                m_cameraA.targetTexture.Release();
            }
            m_cameraA.targetTexture = m_renderTextureA;
            m_cameraATexture.mainTexture = m_cameraA.targetTexture;
        }
        if (m_cameraB != null)
        {
            if (m_cameraB.targetTexture != null)
            {
                m_cameraB.targetTexture.Release();
            }
            m_cameraB.targetTexture = m_renderTextureB;
            m_cameraBTexture.mainTexture = m_cameraB.targetTexture;
        }
    }
}