namespace EX1._4
{
    public abstract class Expr {}

    public class CstI : Expr
    {
        public int Value { get; }

        public CstI(int i)
        {
            Value = i;            
        }
    }

    public class Var : Expr
    {
        public string Variable { get; }

        public Var(string variable)
        {
            Variable = variable;   
        }
    }

    public abstract class Binop : Expr 
    {
        public char Operator { get; }

        protected readonly Expr _expr1;

        protected readonly Expr _expr2; 

        public Binop(char opr, Expr expr1, Expr expr2)
        {
            Operator = opr;   
            _expr1 = expr1;
            _expr2 = expr2;
        }

        
    }

    public class Add : Binop
    {
        public Add(Expr expr1, Expr expr2)
            : base('+', expr1, expr2)
        {}

        public override string ToString()
        {
            return $"{_expr1} + {_expr2}";
        }
    }

    public class Mul : Binop
    {
        public Mul(Expr expr1, Expr expr2)
            : base('*', expr1, expr2)
        {}

        public override string ToString() => $"{_expr1} * {_expr2}";
    }

    public class Sub : Binop
    {
        public Sub(Expr expr1, Expr expr2)
            : base('-', expr1, expr2)
        {}

        public override string ToString() => $"{_expr1} - {_expr2}";
    }
}