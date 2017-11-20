using UnityEngine;
using System.Collections;
using System.IO;

namespace MoreFun
{
		public class CameraUtil
		{
		
		
				public static byte[] CameraToBytes (Camera camera)
				{
						return CameraToBytes (camera, 75);
			
				}

				public static byte[] CameraToBytes (Camera camera, int quality)
				{
						Canvas canvas;
			
						int width = (int)camera.pixelWidth;
						int height = (int)camera.pixelHeight;
			
						Texture2D resultTex = new Texture2D (width, height, TextureFormat.RGB24, false);
			
			
			
			
						RenderTexture renderTex = RenderTexture.GetTemporary (width, height);
			
			
						RenderTexture backupRenderTextureActive = RenderTexture.active;
						RenderTexture backupCameraTargetTexture = camera.targetTexture;
			
						camera.targetTexture = renderTex;
						camera.Render ();
						//camera.targetTexture = null;
			
						RenderTexture.active = renderTex;
						resultTex.ReadPixels (new Rect (0, 0, width, height), 0, 0, false);
			
						resultTex.Apply ();
			
						RenderTexture.active = backupRenderTextureActive;
						camera.targetTexture = backupCameraTargetTexture;
			
			
			
						byte[] resultBytes = resultTex.EncodeToJPG (quality);
			
			
			
						RenderTexture.ReleaseTemporary (renderTex);
						return resultBytes;
			
				}
		
				public static bool CameraToFile (Camera camera, string fileName)
				{
						return CameraToFile (camera, fileName, 75);
			
				}

				public static bool CameraToFile (Camera camera, string fileName, int quality)
				{

						byte[] resultBytes = CameraToBytes (camera, quality);



						if (null == resultBytes) {
								return false;
						}

						FileStream resultFs = null;

						try {
				
								if (File.Exists (fileName)) {
										resultFs = File.OpenWrite (fileName);
								} else {
										resultFs = File.Create (fileName);
								}
				
						} catch (System.Exception ex) {
								return false;
						}

						if (null != resultFs) {
								resultFs.Write (resultBytes, 0, resultBytes.Length);
						}

						resultFs.Close ();
						return true;

				}
		}

}