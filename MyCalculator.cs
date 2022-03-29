using System;
using System.Text;
using System.Collections.Generic;

namespace Calculator
{
	public class MyCalculator
	{
		private int GetPriority(char c)
		{
			if (c == '+' || c == '-') return 1;
			if (c == '*' || c == '/') return 2;
			return -1;
		}
		
		public decimal EvaluateInfix(string infix)
		{
			return EvaluatePostfix(InfixToPostfix(infix));
		}
		
		// postfix won't have parenthesis
		public decimal EvaluatePostfix(string postfix)
		{
			Stack<object> stack = new Stack<object>();
			decimal operand = 0;
			int mult = 10;
			for (int i = 0; i < postfix.Length; i++)
			{
				char c = postfix[i];
				if (char.IsDigit(c)) // operand
				{
					int digit = int.Parse(c.ToString());
					operand = operand * mult + digit;
					if (i == postfix.Length - 1 || !char.IsDigit(postfix[i + 1]))
					{
						stack.Push(operand);
						operand = 0;
					}
				}
				else if (c == '+')
				{
					stack.Push((decimal)stack.Pop() + (decimal)stack.Pop());
				}
				else if (c == '-')
				{
					decimal temp = (decimal)(stack.Pop());
					stack.Push((decimal)stack.Pop() - temp);
				}
				else if (c == '*')
				{
					stack.Push((decimal)stack.Pop() * (decimal)stack.Pop());
				}
				else if (c == '/')
				{
					decimal temp = (decimal)(stack.Pop());
					stack.Push((decimal)stack.Pop() / temp);
				}
			}
			return (decimal)stack.Pop();
		}
		
		public string InfixToPostfix(string infix)
		{
			StringBuilder sb = new StringBuilder();
			Stack<char> stack = new Stack<char>();
			decimal operand = 0;
			int mult = 10;
			for (int i = 0; i < infix.Length; i++)
			{
				char c = infix[i];
				if (char.IsDigit(c)) // operand
				{
					int digit = int.Parse(c.ToString());
					operand = operand * mult + digit;
					if (i == infix.Length - 1 || !char.IsDigit(infix[i + 1]))
					{
						sb.Append(operand.ToString() + ' ');
						operand = 0;
					}
				}
				else if (c == '+' || c == '-' || c == '*' || c == '/') // operator
				{
					if (stack.Count == 0 || GetPriority(stack.Peek()) < GetPriority(c))
					{
						stack.Push(c);
					}
					else
					{
						sb.Append(stack.Pop().ToString() + ' ');
						stack.Push(c);
					}
				}
				else if (c == '(')
				{
					stack.Push(c);
				}
				else if (c == ')')
				{
					while (stack.Peek() != '(')
					{
						sb.Append(stack.Pop().ToString() + ' ');
					}
					stack.Pop();
				}
			}
				
			while (stack.Count > 0) 
			{
				sb.Append(stack.Pop().ToString() + ' ');
			}
			if (sb.Length > 0 && sb[sb.Length - 1] == ' ') sb.Length--;
			return sb.ToString();
		}
	}
}
					
