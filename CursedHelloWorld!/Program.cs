using System;
namespace CursedHelloWorld
{
    class Output
    {
        public string helloworld { get; set; }
        protected int i = -1;
        protected int I
        {
            get 
            {
                i++;
                return i; 
            }
            set
            {
                i = value;
            }
        }
        public virtual void Write() 
        {
            Console.WriteLine();
        }
    }
    class H : Output
    {
        public override void Write()
        {
            Console.Write(helloworld[I]);
        }
    }
    class HE : H
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HEL : HE
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELL : HEL
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO : HELL
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO_ : HELLO
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO_W : HELLO_
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO_WO : HELLO_W
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO_WOR : HELLO_WO
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO_WORL : HELLO_WOR
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO_WORLD : HELLO_WORL
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO_WORLDI : HELLO_WORLD
    {
        public override void Write()
        {
            base.Write();
            Console.Write(helloworld[I]);
        }
    }
    class HELLO_WORLDINEXT : HELLO_WORLDI
    {
        public override void Write()
        {
            base.Write();
            Console.WriteLine();
        }
    }
    class CursedHelloworld
    {
        public static void Main()
        {
            HELLO_WORLDINEXT hw = new HELLO_WORLDINEXT();
            hw.helloworld = "Hello World!";
            hw.Write();
        }
    }
}