namespace Common
{
    //Singleton泛型壳
    //线程安全
    //使用方法:
    //class TestClass : Singleton<TestClass>
    //{
    //	......
    //{
    //
    //注意:无法保证外部使用者不new,失去了Singleton的不允许new的校验
    //优点只是少写点代码

    public abstract class Singleton<T> where T : class, new()
    {
        public static T Instance;
        static Singleton()
        {
            Instance = new T();
        }
    }
}