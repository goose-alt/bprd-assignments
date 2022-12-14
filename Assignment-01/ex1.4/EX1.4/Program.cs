using EX1._4;

Expr expr = new Add(new Var("x"), new Var("z"));
Expr expr1 = new Add(new CstI(17), new Var("z"));
Expr expr2 = new Mul(new Var("y"), new CstI(2));
Expr expr3 = new Sub(expr1, expr2);

Expr simplifyExample = new Mul(new Add(new CstI(1), new CstI(0)), new Add(new Var("x"), new CstI(0)));

System.Console.WriteLine(expr);
System.Console.WriteLine(expr1);
System.Console.WriteLine(expr2);
System.Console.WriteLine(expr3);

System.Console.WriteLine($"Before Simplification: {simplifyExample}");
System.Console.WriteLine($"After Simplification: {simplifyExample.Simplify()}");

System.Console.WriteLine($"Example of no simplification: {expr1.Simplify()}");