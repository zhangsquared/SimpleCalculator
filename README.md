# Simple calculator

Infix and postfix expressions

can process add, reduce, multiply, devide and parenthesis

[Algo Description](https://web.stonehill.edu/compsci/CS104/Stuff/Infix%20and%20%20postfix%20expressions.pdf)

## Postfix Evaluation
 1. read a character
 2. if the character is a digit, convert to int and push
 3. if the character is an operator
	pop the stack twice obtaining the two operands
	perform the operation
	push the result

Pop the final value from the stack.

## Infix into Postfix
1. read the next character in the infix string
2. if the character is an operand, append the character to the postfix expression
3. if the character is an operator @
	while the stack is not empty and an operator of greater or equal priority is on the stack
	pop the stack and append the operator to the postfix
	push @
4. if the character is a left parenthesis (, 
	push the parenthesis onto the stack
5. if the character is a right parenthesis )
	while the top of the stack is not a matching left parenthesis (
	pop the stack and append the operator to postfix
pop the stack and discard the returned left parenthesis 
