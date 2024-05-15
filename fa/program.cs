using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;

        public State(string name, bool state)
        {
            Name = name;
            IsAcceptState = state;
            Transitions = new Dictionary<char, State>();
        }
    }


    public class FA1
    {
        public static State A = new State("a", false);
        public State B = new State("b", true);
        public State C = new State("c", false);
        public State D = new State("d", false);
             
        State InitialState = A;

        public FA1()
        {
            A.Transitions['1'] = C;
            A.Transitions['0'] = B;
            B.Transitions['1'] = B;
            B.Transitions['0'] = D;
            C.Transitions['1'] = C;
            C.Transitions['0'] = B;
            D.Transitions['1'] = D;
            D.Transitions['0'] = D;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public static State A = new State("a", false);
        public State B = new State("b", false);
        public State C = new State("c", true);

        State InitialState = A;

        public FA2()
        {
            A.Transitions['1'] = B;
            A.Transitions['0'] = C;
            B.Transitions['1'] = B;
            B.Transitions['0'] = C;
            C.Transitions['1'] = C;
            C.Transitions['0'] = B;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State A = new State("a", false);
        public State B = new State("b", false);
        public State C = new State("c", true);

        State InitialState = A;

        public FA3()
        {
            A.Transitions['1'] = B;
            A.Transitions['0'] = A;
            B.Transitions['1'] = C;
            B.Transitions['0'] = A;
            C.Transitions['1'] = C;
            C.Transitions['0'] = C;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "001000111111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
