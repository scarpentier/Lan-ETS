namespace SPACEBAR.Patterns.Singleton
{
    /// <summary>
    /// Singleton Design Pattern. This is a thread safe implementation.
    /// This is public domain code, grabbed from wikipedia. 
    /// </summary>
    /// <typeparam name="T">Singleton class</typeparam>
    public class ThreadSafeSingleton<T> where T : class, new()
    {
        /// <summary>
        /// Sync lock object.
        /// </summary>
        private static readonly object syncLock = new object();
        /// <summary>
        /// Template Instance.
        /// </summary>
        private static T instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="Singleton"/> class.
        /// </summary>
        protected ThreadSafeSingleton() { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// Singleton Design Pattern. This is a lazy and threadsafe singleton without using locks.
    /// Grabbed from the public domain on this website: http://www.yoda.arachsys.com/csharp/singleton.html
    /// Modified to a template. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NoLockSingleton<T> where T : new()
    {
        static readonly T instance = new T();


        /// <summary>
        /// Initializes the <see cref="NoLockSingleton&lt;T&gt;"/> class.
        /// Explicit static constructor to tell C# compiler
        /// not to mark type as beforefieldinit
        /// </summary>
        static NoLockSingleton()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoLockSingleton&lt;T&gt;"/> class.
        /// </summary>
        NoLockSingleton()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                return instance;
            }
        }
    }

    /// <summary>
    /// Singleton Design Pattern. This is the laziest singleton. Not threadsafe!
    /// Grabbed from the public domain on this website: http://www.yoda.arachsys.com/csharp/singleton.html
    /// Modified to a template. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LazySingleton<T> where T : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LazySingleton&lt;T&gt;"/> class.
        /// </summary>
        LazySingleton() { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get { return nested.instance; }
        }

        class nested
        {
            static nested() { }

            internal static readonly T instance = new T();
        }
    }

}
