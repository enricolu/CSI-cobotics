using PiXYZ.Utils;
using UnityEditor;
using UnityEngine;

namespace PiXYZ {

    public class PreprocessedSourceEditor : MonoBehaviour {

        [InitializeOnLoadMethod]
        static void Connect() {
            PreprocessedSourceProvider.Current = new PreprocessedSource();
        }
    }

}