using System;
using System.Runtime.Remoting;

namespace ClientDemonstration
{
    public class ExampleFactory
    {
        public IDemonstrable GetExample(int i)
        {
            var handle = Activator.CreateInstance(Type.GetType("ClientDemonstration.Example" + i));
            return handle as IDemonstrable;
        }
    }
}