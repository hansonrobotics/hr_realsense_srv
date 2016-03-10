﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HR_RealSense_Srv1
{
    class Program
    {
        static void Main(string[] args)
        {
            PXCMSession session = PXCMSession.CreateInstance();
            if (session == null) { Console.WriteLine("Could not start session."); return; }
                Config config = new Config(session);
            if (!config.readConfig()) { Console.WriteLine("Could not read config. Aborting"); session.Dispose(); return; }
            //
            
            Faces fc = new Faces(config);
            var thread = new Thread(fc.callOnceInLoop);
            thread.Start();
            Thread.Sleep(10);
            //

            Hand hand = new Hand(config);
            var threadH = new Thread(hand.callOnceInLoop);
            threadH.Start();
            //
            Thread.Sleep(10);
            while (true)
            {
                Thread.Sleep(5);
            }
            //session.Dispose();
        }
    }
}
