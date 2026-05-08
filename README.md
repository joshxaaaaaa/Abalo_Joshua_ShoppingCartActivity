# Abalo_Joshua_ShoppingCartActivity
Quiz 2 and Quiz 3

PART 1

SUMMARY OF CHANGES 
Commit 1: 
Product Class: 
Since this is the first day of coding this project, I started on this class named Product and added their fields/properties. Also, with this class, I added methods such as displayProduct as stated on the requirement. 
Main Class: 
This Main class is the second class I created containing the arrays of the objects, constructors, and initial switch cases. Also, I assigned product names and the values of each property on this class. Lastly, I created a user dashboard to identify the all-possible user actions may occur. 
Commit 2: 
Products Class: 
I only added methods on this class such as getCartTotal (functions for computing the subtotal of the chosen product), enoughStock (functions for determining if there is available stocks), and lastly, the deductStock (functions that deduct the quantity input by the user to the remaining stock that the product has). 
CartItems Class: 
On the second day of coding, I created this class to serve as a storage of the Cart Items. 
Main Class: 
On this Main class, I added case number 2 and 3. Also, I included all the possible validation so that the system prevents users from entering invalid input. I finished these cases comprehensively so that I will not get back to these cases to edit/change. 
Commit 3: 
Products Class: 
No Changes
CartItems Class: 
No Changes
Main Class: 
On this Main class, I added case number 4. Also, I noticed that some of the outputs didn't met the requirement specifically requirement number 6 and 8 in the Main Class section. That is why I revised those and implemented on my project. 
Final Commit: 
Products Class: 
No Changes
CartItems Class: 
No Changes
Main Class: 
Added line dividers for aesthetics
Note: 
I used draw.io in creating this flowchart. 

AI USAGE IN THIS PROJECT 
Commit 1: 
I spent my time using AI to explore this platform. Since this is my first semester using Github, I frequently asked AI anything about repositories and how it works. Also, not only about this platform, I asked AI about the requirement prompting, "How to use int.TryParse() and why is it better than Convert.ToInt32()?" to know its usage in this project. Lastly, my overall code on this project was from the previous discussions and online video tutorials on YT (specifically Bro Code), and I applied these learnings to create this project. 
Commit 2: 
Upon revisions and adding codes, the time I used AI is only when I cannot call the Product class and its methods. That is why I asked AI on how to call the Product class and the method “enoughStocks” on my Main Class. Once responded, I applied these responses to all of my codes that uses/calling different class and its methods. 
Commit 3: 
I used AI with regards to the requirement 6 and 8. I've asked AI what lines or block of codes should I focused on to meet these requirements. After responding, I implement and optimize my code so that the changes will apply. 
Final Commit:
None for this Final Commit 
Note: 
Since I know to myself that I cannot implement this project completely with myself, AI helps me to debug and understand things that I didn’t know in programming. Also, through asking AI, my code now is fully optimized and waste no lines to unnecessary block codes. 

PART 2

FEATURES
This system allows users to: 
1.	View all, view by category, search, and add to cart the products
2.	View all, update quantity, remove item, clear cart, and checkout carts 
3.	Validate payment and compute change
4.	View receipt number, date/time, payment, and change 
5.	View products with stock <= 5 after checkout
6.	View the stored and displayed completed transactions 
7.	Experience strict validation for all menu and Y/N, Enter, and X inputs. 

SUMMARY OF CHANGES 
Development 1: 
Requirements: 
For the first 2 days of development, I added the following features: 
A.	Cart Management Menu 
• View Cart 
• Remove Item 
• Update Item Quantity 
• Clear Cart 
• Checkout Products
B.	Product Search 
For this requirement, I just added another switch cases in the product dashboard where user can search through inputting product name. 
C.	Product Categories 
Lastly, I added a Category field to the Product class and do the following additions and changes in the constructors and objects which I used in a case 2 in a product dashboard. The products have 4 main categories as of the moment: Gadgets, Accessories, Peripherals, and Audio. 
Structural Changes: 
A.	Additions of AddToCart Class 
During the development, I noticed that there’s too much codes on my Program.cs. That’s why I created this class to make my Program.cs more organize. I transferred the “Add to Cart” block of codes into the AddToCart Class and cartProcess method so that I can easily call this method whenever I need it on my Program.cs. 
B.	Transferring a Block of Codes into CartItems Class 
On this class, I simply transferred the “View Cart” block of codes and make a method for this. 
C.	Changes in Dashboards 
For these changes, I created main dashboard, product dashboard, cart dashboard, and order history dashboard. These changes allow users to navigate and do a lot of tasks/actions on this system. Also, I ensure that the actions are inlined with the requirements. 
Development 2: 
Requirements: 
A.	Stock Re-order Alert 
For this requirement, I just added a block of codes on the Cart Dashboard, Checkout Product, as stated on the requirement. 
B.	Receipt Number and Date
Since I have existing codes that generate receipts, together with its components (Purchased Items, Grand Total, Discount, Final Total, Payment, and Change), I added a new components receipt number and date. Also, added variable “receiptNumber” at the top part of Program.cs
Structural Changes: 
No changes as of the moment. 
Development 3: 
Requirements: 
A.	Order History 
For this requirement, I just added a block of codes on the Main Dashboard, Order History, which can store completed transactions in an array and user can view order history as stated on the requirement. On the code/program logic, I created an array which can store up to 100 past orders for the purpose of order history limitations even its not stated on the requirements. Also, I created a block of codes which save the transaction upon checkout and display all of these on the Order History in Main Dashboard. 
Structural Changes: 
A.	Added Line Dividers 

AI USAGE IN THIS PROJECT 
Development 1: 
For this development, I used AI when there are methods, classes, or functions that I cannot call again, specifically the new class “AddToCart” class. I prompt “How can I call the AddToCart class on my main program?” Once responded, I apply and notice that AI suggests using by reference or “ref int cartCount” upon passing, then after that, I asked AI on how to use this passing by reference. 
Also, during the progress of implementing an updating the quantity of an item in a cart, I asked AI to help me about this. Upon responding, the changes and revisions are now fully implemented. Through AI, now I know how to use a Math.Abs(); methods on creating this updating a quantity of an item in a cart. 
Lastly, most of the time, I frequently used AI on how to use GitHub in making a Pull Request and creating a branch. Mostly, there are unfamiliar navigations of GitHub that I cannot fully utilize. That is why instead of watching YT videos, I always ask AI on using this platform about Pull requests and such. 
Development 2: 
As of Day 3 of development, I only used and asked AI prompting “What are the functions, libraries, or codes may I use that extract time and date?” Upon responding, I applied DateTime.Now.ToString("MMMM dd, yyyy h:mm tt") on my code since this code wasn’t discussed during our classes. Also, I learned about string formatting in AI such as Format “D4” and Format "MMMM dd, yyyy h:mm tt". 
Development 3: 
None for this final commit. 
