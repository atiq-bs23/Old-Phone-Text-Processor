**OldPhoneTextProcessor:**
 A .NET 8 console app that converts old phone keypad inputs to text.  
 
Class DigitToText has a method ProcessInput takes a string of characters (digits, '*', '#', ' ') as input and return output text based on old phone keypad press.  

**Requirements:**
 .NET 8 SDK

**How to Run:**
1. Clone the repo.
2. Open TextProcessor.sln in Visual Studio.
3. Build the solution.
4. Run the application.

**Solution Complexity:**
##### Space Complexity: O(N) 
- Constant dictionary **O(1)**
- Storing output text **O(N)**
##### Time Complexity: O(N)
- Dictionary TryGetValue **O(1)**
- Input character travers **O(N)**

**Example Run**

Enter the number of test: 3  
Enter the input: 2222#  
Output text: A  
Enter the input: 33#  
Output text: E  
Enter the input: 33*2 844477#  
Output text: ATIQ  
