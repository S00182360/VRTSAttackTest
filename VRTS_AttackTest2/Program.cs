using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRTS_AttackTest2
{

    public enum SIGN { Rock, Paper, Scissor, Lizard, Spock };

    class Program
    {

        public static float[,] SignModifier = new float[5, 5]
        {
                { 1.0f,     1.25f,  0.85f,  1.25f,  0.85f },
                { 0.85f,    1.0f,   1.25f,  1.25f,  0.85f },
                { 1.25f,    0.85f,  1.0f,   0.85f,  1.25f },
                { 1.25f,    0.85f,  1.25f,  1.0f,   0.85f },
                { 0.85f,    1.25f,  1.25f,  0.85f,  1.0f  }
        };

        public static float[,] LevelModifier = new float[5, 5]
        {
                { 1.0f,     1.15f,  1.3f,   1.5f,   1.6f  },
                { 0.85f,    1.0f,   1.15f,  1.3f,   1.5f  },
                { 0.6f,     0.85f,  1.0f,   1.15f,  1.3f  },
                { 0.5f,     0.6f,   0.85f,  1.0f,   1.15f },
                { 0.3f,     0.5f,   0.6f,   0.85f,  1.0f  }
        };
        //0.3f, 0.5f, 0.6f, 0.85f, 1.0f, 1.15f, 1.3f, 1.5f


        static void Main(string[] args)
        {
        }
    }
}
