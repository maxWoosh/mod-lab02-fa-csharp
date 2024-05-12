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
  }


  public class FA1
{
    public static State a = new State()
    {
        Name = "a",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public State b = new State()
    {
        Name = "b",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public State c = new State()
    {
        Name = "c",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public State d = new State()
    {
        Name = "d",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = a;

    public FA1()
    {
        a.Transitions['0'] = b;
        a.Transitions['1'] = a;
        b.Transitions['0'] = c;
        b.Transitions['1'] = b;
        c.Transitions['0'] = c;
        c.Transitions['1'] = d;
        d.Transitions['0'] = c;
        d.Transitions['1'] = d;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s)
        {
            if (!current.Transitions.ContainsKey(c))
            {
                return null; // вернуть null в случае отсутствия перехода
            }
            current = current.Transitions[c];
        }
        return current.IsAcceptState;
    }
}

public class FA2
{
    public static State q0 = new State()
    {
        Name = "q0",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public State q1 = new State()
    {
        Name = "q1",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public State q2 = new State()
    {
        Name = "q2",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = q0;

    public FA2()
    {
        q0.Transitions['0'] = q1;
        q0.Transitions['1'] = q0;
        q1.Transitions['0'] = q2;
        q1.Transitions['1'] = q0;
        q2.Transitions['0'] = q1;
        q2.Transitions['1'] = q2;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s)
        {
            if (!current.Transitions.ContainsKey(c))
            {
                return null; // вернуть null в случае отсутствия перехода
            }
            current = current.Transitions[c];
        }
        return current.IsAcceptState;
    }
}

public class FA3
{
    public static State q0 = new State()
    {
        Name = "q0",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public State q1 = new State()
    {
        Name = "q1",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public State q2 = new State()
    {
        Name = "q2",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    public State q3 = new State()
    {
        Name = "q3",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = q0;

    public FA3()
    {
        q0.Transitions['0'] = q0;
        q0.Transitions['1'] = q1;
        q1.Transitions['0'] = q0;
        q1.Transitions['1'] = q2;
        q2.Transitions['0'] = q0;
        q2.Transitions['1'] = q3;
        q3.Transitions['0'] = q0;
        q3.Transitions['1'] = q3;
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s)
        {
            if (!current.Transitions.ContainsKey(c))
            {
                return null; // вернуть null в случае отсутствия перехода
            }
            current = current.Transitions[c];
        }
        return current.IsAcceptState;
    }
}

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
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
