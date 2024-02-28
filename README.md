# Water-Jug-Challenge
C# program that finds the least amount of steps required to fill a jug with the required amount.


# Algorithmic Approach
This program is based on the mathematical equation called 'linear Diophantine', in which if:
* The greatest common divisor of the capacity of jug X and Y divides to the capacity of jug Z (Z % GCD(X, Y)).
* And the largest capacity between X and Y is greater than Z.

Then a solution is possible. The solution reached is attained using two situations:
* The first jug is used to fill the second jug (X to Y).
* The second jug is used to fill the first jug (Y to X).

And one of these has to be the one with the fewest steps possible.
The program ask the user, via the terminal, the required values for the jugs; starting from X, Y and finally Z. If any of the values are not numerical, then a warning will alert the user to enter only numbers and to try again; or if the values are negative, it will alert the user to enter only positive, or greater than zero, numbers. Afterward, the solution will be shown via the terminal and through a JSON file located in the 'Solution' folder.

# Test Cases for Validation
### 1st example
Jug X = 3, jug Y = 5, jug Z = 4. The solution is as follow:
![image](https://github.com/Unusual-Waffles-Situation/Water-Jug-Challenge/assets/62034860/ce9e6469-b332-48b6-a603-69f3972b830a)

### 2nd example
Jug X = 10, jug Y = 2, jug Z = 4. The solution is as follow:
![image](https://github.com/Unusual-Waffles-Situation/Water-Jug-Challenge/assets/62034860/1efaf7f0-ca82-40ad-b365-a4979868a3bd)

### 3rd example
Jug X = 35, jug Y = 45, jug Z = 55. The solution is as follow:
![image](https://github.com/Unusual-Waffles-Situation/Water-Jug-Challenge/assets/62034860/6c596f47-2f0e-4332-a413-ca1f9b350ca2)

# Instruction
To run the program, simply clone/download the source code, and open it in, preferably, Visual Studio/Code. No dependencies are required. It uses .NET version 8.0.100.
