using System;
using System.Collections;
using System.Collections.Generic;

namespace coroutineTest {

    public class program  
    {  
        static void Main()  
        {  
            enumerable myEnumObj = new enumerable();
            foreach (var i in myEnumObj.getEnumerable()) {
                Console.WriteLine(i);
            }

            Console.Read();
        }  
    }

    /******************************************************/
    public class enumerable { 

        /// <summary>
        /// 获取一个迭代器, yield return返回的东西竟然是一个IEnumerable!!!
        /// </summary>
        /// <returns></returns>
        public IEnumerable getEnumerable() { 
            yield return 1;
            yield return "hello";
            yield return 3;
            yield return 4;
            yield break;
            yield return "can't reach here, because break before!";
        }
    }

    /*************************************************************/
    public class CoroutineYieldInstruction {
        public virtual bool IsDone() {
            return true;
        }
    }

    public class CoroutineWaitForSeconds : CoroutineYieldInstruction {
            TimeSpan m_waitTime;
            DateTime m_startTime;
            public CoroutineWaitForSeconds(long waitSeconds) {                
                m_startTime = DateTime.Now;
                m_waitTime = TimeSpan.FromSeconds(waitSeconds);
        }

        public override bool IsDone() {
            return DateTime.Now > (m_startTime + m_waitTime);
        }
    }
    public class CoroutineDemo {
        public void Start() { 
            Console.WriteLine("start..");
            StartCoroutine(SelfCoroutine());            
            Console.WriteLine("start over..");
        }
        IEnumerator SelfCoroutine() {
            Console.WriteLine("Self coroutine begin at time : ");
            yield return new CoroutineWaitForSeconds(5);
            Console.WriteLine("Self coroutine begin at time : ");
        }
    }
}
