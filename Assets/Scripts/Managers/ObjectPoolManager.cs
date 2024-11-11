public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    /// <summary>
    /// 오브젝트 풀링
    /// </summary>
    /// <param name="T"> 오브젝트 풀링할 오브젝트의 root class 및 interface를 지정해서 사용하면됩니다.</param>
    /// <param name="T"> T는 해당  where T : MonoBehaviour, IObjectPoolAble<T> 제약 조건을 가지고 있습니다.</param>
    /// 
    /// private ObjectPoolingContainer<T> objectRootClass = new ObjectPoolingContainer<T>();
    ///public ObjectPoolingContainer<T> ObjectRootClass { get => objectRootClass; }

}
