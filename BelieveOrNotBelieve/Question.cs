using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelieveOrNotBelieve
{
    [Serializable]
    public class Question
    {
        

        public string text { get; set; }
        public bool trueFalse { get; set; }
        public Question()
        {
        }
        public Question(string text, bool trueFalse)
        {
            this.text = text;
            this.trueFalse = trueFalse;
        }

    }
}
