using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haccp_MES
{
    public sealed class MainInstance
    {
        public MainInstance() { }

        private static MainInstance _instance = null;
        private static readonly object padlock = new object();

        public static MainInstance Instance
        {
            get
            {
                lock(padlock)
                {
                    if (_instance is null)
                    {
                        _instance = new MainInstance();
                    }
                    return _instance;
                }
                
            }
        }

        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }


        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

    }
}
