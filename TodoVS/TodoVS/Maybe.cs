using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoVS
{
    public abstract class Maybe<T> {
    }

    public class Some<T>: Maybe<T> {
        public T Value {get; private set;}

        public Some(T value) {
            this.Value = value;
        }
    }

    public class Nothing<T>: Maybe<T> {
    }
}
