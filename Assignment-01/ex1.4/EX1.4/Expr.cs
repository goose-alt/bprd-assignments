namespace EX1._4
{
    public abstract class Expr 
    {
        public abstract int Eval(Stack<(string Name, int Value)> env);

        public abstract Expr Simplify();
    }

    public class CstI : Expr
    {
        public int Value { get; }

        public CstI(int i)
        {
            Value = i;            
        }

        public override string ToString() => Value.ToString();

        public override int Eval(Stack<(string Name, int Value)> env) => Value;

        public override Expr Simplify() => this;
    }

    public class Var : Expr
    {
        public string Variable { get; }

        public Var(string variable)
        {
            Variable = variable;   
        }

        public override string ToString() => Variable;

        public override int Eval(Stack<(string Name, int Value)> env) => env.First(x => x.Name == Variable).Value;

        public override Expr Simplify() => this;
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

        public override int Eval(Stack<(string Name, int Value)> env) => _expr1.Eval(env) + _expr2.Eval(env);

        public override Expr Simplify() => (_expr1, _expr2) switch
        {
            (CstI val, Expr ex) when (val.Value == 0) => ex.Simplify(),
            (Expr ex, CstI val) when (val.Value == 0) => ex.Simplify(),
            _ => this
        };

        public override string ToString() => $"({_expr1} + {_expr2})";
    }

    public class Mul : Binop
    {
        public Mul(Expr expr1, Expr expr2)
            : base('*', expr1, expr2)
        {}

        public override int Eval(Stack<(string Name, int Value)> env) => _expr1.Eval(env) * _expr2.Eval(env);

        public override string ToString() => $"({_expr1} * {_expr2})";
    }

    public class Sub : Binop
    {
        public Sub(Expr expr1, Expr expr2)
            : base('-', expr1, expr2)
        {}

        public override int Eval(Stack<(string Name, int Value)> env) => _expr1.Eval(env) - _expr2.Eval(env);

        public override Expr Simplify() => (_expr1, _expr2) switch 
        {
            (Expr ex, CstI val) when (val.Value == 0) => ex.Simplify(),
            _ => SimplifyExpressions()
        };

        private Expr SimplifyExpressions()
        {
            _expr1.Simplify();
            _expr2.Simplify();

            return this;
        }

        public override string ToString() => $"({_expr1} - {_expr2})";
    }
}