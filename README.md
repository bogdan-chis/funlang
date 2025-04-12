# FunLang
A schema inspired, interpreted language written in C#.

## Types
- `list` : ordered, heterogeneous collection  
- `number` : integer or float  
- `char` : a char  
- `string` : list of chars  
- `function` : lambda function  

## Variable definition
```
define a 5 // one number
define (a b c) (4.5 "hey" 6) // a bunch of numbers and strings
define l (3 4 5) // a list
define (l1 l2) ((2 3) (4 "a")) // a bunch of lists
```

## If block
```
if (== 1 0) then (+ 2 3) else (- 4 5)
if 9 then 4 else 5
```
An if expression always returns the last element of the list that it evaluated. For example, if 1 (3 4) (9 0) will return 4.

## Function call
```
define f lambda x => (1000 * 2 x)
f 15
(f 15)
```
A function call can or cannot be surrounded by parantheses. If it is surrounded, it will not be considered a list. In order to create a list with the result of a function call, surround it twice: ((f x)).
A function always returns the last element of the list that it evaluated. For example, f 4 will return 8, even though the list it evaluated turned out to be (1000 8).

### Example
```
(

define map lambda (f l) => (
	if l then (
		(push f first l map $f rest l)
	) else (
		()
	)
)

define filter lambda (f l) => (
	if l then (
		if (f first l) then (
			(push first l filter $f rest l)
		) else (
			(filter $f rest l)
		)
	) else (
		()
	)
)

println map $lambda x => (+ 5 x) filter $lambda x => (== 0 % x 2) (1 2 5 3 4 5 1 2 3 4 5 6 7 8 5 5 24)

)
```
This will output (7 9 7 9 11 13 29)

## List of functions
Basic Operations
 ```+ a b```
 ```- a b```
 ```* a b```
 ```/ a b```
divides a by b and returns a float (regardless if a and b are integers)

```% a b```
a and b must be integers

```== a b```

```!= a b```

```> a b```

```>= a b```

``` < a b```

``` <= a b ```

``` not a```
negates the logical value of a

```or a b```
logical or

```and a b```
logical and

For all operations (apart from modulo), if one of the numbers is a float and the other is an integer, the integer gets promoted to a float. If one of them is a char, it gets converted to its ASCII code.

## Standard functions
 ```push e l``` : inserts e to the front of l and returns the new list

 ```append e l``` : appends e to the end of l and returns the new list

 ```range n``` : returns the list (0 1 2 ... n-1)

 ```println s``` : prints s to stdout, followed by a new line

 ```error e``` : prints e to stderr and halts the program

``` readln``` : reads string from stdin and returns it

 ```first l``` : returns the first element of l, error if l is empty

 ```second l``` : returns the second element of l, error if l has one element or less

 ```third l``` : returns the third element of l, error if l has two elements or less

 ```last l``` : returns the last element of l, error if l is empty

 ```tail l``` : returns everything after the first element of l (the last n-1 elements), error if l is empty

 ```head l``` : returns everything before the last element of l (the first n-1 elements), error if l is empty

 ```length l``` : returns the length of l

 ```empty l``` : checks if l is empty
