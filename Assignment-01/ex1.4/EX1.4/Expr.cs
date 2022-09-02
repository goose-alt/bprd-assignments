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

        protected Expr _expr1;

        protected Expr _expr2; 

        public Binop(char opr, Expr expr1, Expr expr2)
        {
            Operator = opr;   
            _expr1 = expr1;
            _expr2 = expr2;
        }

        public override Expr Simplify() 
        {
            // Perform a bottom-up approach
            _expr1 = _expr1.Simplify();
            _expr2 = _expr2.Simplify();


            return SimplifyExpression(); // Perform the actual simplification of the current expression
        }

        public override string ToString() => $"({_expr1} {Operator} {_expr2})";

        /// <summary>
        /// Simplifies this expression by looking at the other expressions.
        /// If this cannot be simplified then nothing is going to change
        /// </summary>
        /// <returns>A simplified version of the following expression if possible</returns>
        protected abstract Expr SimplifyExpression();
    }

    public class Add : Binop
    {
        public Add(Expr expr1, Expr expr2)
            : base('+', expr1, expr2)
        {}

        public override int Eval(Stack<(string Name, int Value)> env) => _expr1.Eval(env) + _expr2.Eval(env);

        protected override Expr SimplifyExpression() => (_expr1, _expr2) switch
        {
            (CstI val, Expr ex) when (val.Value == 0) => ex,
            (Expr ex, CstI val) when (val.Value == 0) => ex,
            _ => this
        };
    }

    public class Mul : Binop
    {
        public Mul(Expr expr1, Expr expr2)
            : base('*', expr1, expr2)
        {}

        public override int Eval(Stack<(string Name, int Value)> env) => _expr1.Eval(env) * _expr2.Eval(env);

        

        protected override Expr SimplifyExpression() => (_expr1, _expr2) switch
        {
            (CstI c, Expr ex) when (c.Value == 1) => ex,
            (Expr ex, CstI c) when (c.Value == 1) => ex,
            (CstI c, Expr ex) when (c.Value == 0) => new CstI(0),
            (Expr ex, CstI c) when (c.Value == 0) => new CstI(0),
            _ => this
        };
    }

    public class Sub : Binop
    {
        public Sub(Expr expr1, Expr expr2)
            : base('-', expr1, expr2)
        {}

        public override int Eval(Stack<(string Name, int Value)> env) => _expr1.Eval(env) - _expr2.Eval(env);
        
        protected override Expr SimplifyExpression()=> (_expr1, _expr2) switch 
        {
            (CstI c1, CstI c2) when (c1.Value == c2.Value) => new CstI(0),
            (Expr ex, CstI val) when (val.Value == 0) => ex,
            _ => this
        };
    }
}