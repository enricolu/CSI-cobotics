using PiXYZ.Utils;
using UnityEngine;

namespace PiXYZ {

    public class PreprocessedSource : IPreprocessedSource {

        [RuntimeInitializeOnLoadMethod]
        static void Connect() {
            PreprocessedSourceProvider.Current = new PreprocessedSource();
        }

        public Shader GetDefaultShader() {
            Shader shader = null;
#if UNITY_2019_1_OR_NEWER
            if (UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset) {
                shader = UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset.defaultShader;
            }
#else
            if (UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset) {
                shader = UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset.GetDefaultShader();
            }
#endif
            if (shader == null)
                shader = Shader.Find("Standard");
            return shader;
        }
    }
}