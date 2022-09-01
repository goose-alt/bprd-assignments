using EX1._4;

Expr expr = new Add(new Var("x"), new Var("z"));
Expr expr1 = new Add(new CstI(17), new Var("z"));
Expr expr2 = new Mul(new Var("y"), new CstI(2));
Expr expr3 = new Sub(expr1, expr2);

System.Console.WriteLine(expr);
System.Console.WriteLine(expr1);
System.Console.WriteLine(expr2);
System.Console.WriteLine(expr3);