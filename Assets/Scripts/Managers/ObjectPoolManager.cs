public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    /// <summary>
    /// ������Ʈ Ǯ��
    /// </summary>
    /// <param name="T"> ������Ʈ Ǯ���� ������Ʈ�� root class �� interface�� �����ؼ� ����ϸ�˴ϴ�.</param>
    /// <param name="T"> T�� �ش�  where T : MonoBehaviour, IObjectPoolAble<T> ���� ������ ������ �ֽ��ϴ�.</param>
    /// 
    /// private ObjectPoolingContainer<T> objectRootClass = new ObjectPoolingContainer<T>();
    ///public ObjectPoolingContainer<T> ObjectRootClass { get => objectRootClass; }

}
