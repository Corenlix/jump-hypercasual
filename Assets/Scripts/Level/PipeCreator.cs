using UnityEngine;

namespace Level
{
    [CreateAssetMenu]
    public class PipeCreator : ScriptableObject{
        [SerializeField] private Pipe pipeTemplate;

        public Pipe Create(Vector3 position, float height, float additiveHeight = 0f)
        {
            height += additiveHeight;
            Pipe pipe = Instantiate(pipeTemplate, position - Vector3.up * (additiveHeight/2f - additiveHeight), Quaternion.identity);
            pipe.transform.localScale = new Vector3(pipe.transform.localScale.x, height, pipe.transform.localScale.z);
            
            return pipe;
        }
    }
}